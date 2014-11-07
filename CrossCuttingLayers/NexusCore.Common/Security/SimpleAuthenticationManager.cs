using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Helper;
using NexusCore.Infrasructure.Security;
using NexusCore.Infrasructure.Security.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace NexusCore.Common.Security
{
    public class SimpleAuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordValidator _passwordValidator;

        public SimpleAuthenticationManager(IUnitOfWorkAsyncFactory unitOfWorkFactory, IPasswordValidator passwordValidator)
        {
            _unitOfWork = unitOfWorkFactory.Create();
            _passwordValidator = passwordValidator;
        }

        public IActivationToken CreateUser(string title, string userName, string email,  string firstName, string lastName, string phoneNumber)
        {
            if (_unitOfWork.Repository<User>().Get(u => u.Email == email).Any())
                throw new ValidationException("Email address is already registered");

            _unitOfWork.Repository<User>().Insert(new User
            {
                Email = email,
                UserName = GetFriendlyUserName(userName, firstName, lastName),
                Title = title,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                LastActivityDate = DateTime.Now,
                PasswordSalt = GenerateSalt()
            });

            _unitOfWork.SaveChanges();
            return ResetUserPassword(email);
        }

        public int UpdateUser(Guid userId, string title, string userName, string email, string firstName, string lastName, string phoneNumber)
        {
            int recordsAffected = 0;
            var user = _unitOfWork.Repository<User>().Get(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.Title = title;
                user.UserName = GetFriendlyUserName(userName, firstName, lastName);
                user.FirstName = firstName;
                user.LastName = lastName;
                user.PhoneNumber = phoneNumber;

                _unitOfWork.Repository<User>().Update(user);
                recordsAffected = _unitOfWork.SaveChanges();
            }

            return recordsAffected;
        }

        public bool Authenticate(string userEmail, string password)
        {
            var user = GetUserByEmail(userEmail);

            if (user == null || user.PasswordHash != EncodePassword(password, user.PasswordSalt) || !user.IsActive)
                return false;

            user.LastActivityDate = DateFormater.DateTimeNow;
            _unitOfWork.Repository<User>().Update((User)user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public IUser LoginAuthenticate(string userEmail, string password)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(Guid userId)
        {
            return _unitOfWork.Repository<User>().Get(u => u.Id == userId).Single();
        }

        public IUser GetUserByEmail(string email)
        {
            return _unitOfWork.Repository<User>().Get(u => u.Email == email.ToLower()).Single();
        }

        public IUser GetUserByExternalUserName(string userName, string providerName)
        {
            return
                _unitOfWork.Repository<User>()
                    .Get(u => u.UserExternalLogins.Any(el => el.ProviderName == providerName))
                    .SingleOrDefault();
        }

        public bool IsUserExist(string email)
        {
            return _unitOfWork.Repository<User>().Get(u => u.Email == email).Any();
        }

        public IActivationToken ResetUserPassword(Guid userId)
        {
            var user = GetUser(userId);
            return ResetUserPassword(user);
        }

        public IActivationToken ResetUserPassword(string email)
        {
            var user = GetUserByEmail(email);
            return ResetUserPassword(user);
        }

        private IActivationToken ResetUserPassword(IUser user)
        {
            SetPassword(user, Guid.NewGuid().ToString());
            user.IsActive = false;
            _unitOfWork.Repository<User>().Update((User)user);
            _unitOfWork.SaveChanges();
            return new ActivationToken(user.Email, user.PasswordHash);
        }

        public IActivationToken ChangeUserEmail(string oldEmail, string newEmail)
        {
            var user = GetUserByEmail(oldEmail);
            if (user == null)
                throw new Exception("User not exist in system.");
            if (IsUserExist(newEmail))
                throw new Exception("User email already exist in system.");
            
            user.Email = newEmail;
            user.IsActive = false;
            _unitOfWork.Repository<User>().Update((User)user);
            _unitOfWork.SaveChanges();
            return new ActivationToken(user.Email, user.PasswordHash);
        }

        public void UpdatePassword(string email, string newPassword)
        {
            var user = GetUserByEmail(email);
            SetPassword(user, newPassword);
            _unitOfWork.Repository<User>().Update((User)user);
            _unitOfWork.SaveChanges();
        }

        public bool ActivateUser(IActivationToken token, string newPassword)
        {
            using (var tx = new TransactionScope())
            {
                var user =
                    _unitOfWork.Repository<User>()
                        .Get(u => u.Email == token.Email && u.PasswordHash == token.PasswordHash)
                        .SingleOrDefault();

                var canActivate = user != null && !user.IsActive;

                if (canActivate)
                {
                    user.IsActive = true;
                    //_unitOfWork.Repository<User>().Update(user);
                    //_unitOfWork.SaveChanges();
                    UpdatePassword(token.Email, newPassword);
                }

                tx.Complete();
                return canActivate;
            }
        }

        public bool SetNewPassword(IActivationToken token, string newPassword)
        {
            var user =
                _unitOfWork.Repository<User>()
                    .Get(u => u.Email == token.Email && u.PasswordHash == token.PasswordHash)
                    .SingleOrDefault();
            var canSet = user != null && !user.IsActive;

            if (canSet)
            {
                user.IsActive = true;
                UpdatePassword(token.Email, newPassword);
            }

            return canSet;
        }

        public void CreateRole(string roleName, string description)
        {
            if (_unitOfWork.Repository<Role>().Get(r => r.RoleName == roleName).Any())
                throw new ValidationException("Role name is already exist");

            _unitOfWork.Repository<Role>().Insert(new Role
            {
                RoleName = roleName,
                Description = description
            });
            _unitOfWork.SaveChanges();
        }

        public IRole GetRoleById(Guid id)
        {
            return _unitOfWork.Repository<Role>().Get(r => r.Id == id).FirstOrDefault();
        }

        public IRole GetRoleByName(string roleName)
        {
            return _unitOfWork.Repository<Role>().Get(r => r.RoleName.ToLower() == roleName.ToLower()).FirstOrDefault();
        }

        public IEnumerable<IRole> GetUserRoles(Guid userId)
        {
            var user = GetUser(userId);
            return GetUserRoles(user);
        }

        public IEnumerable<IRole> GetUserRoles(string email)
        {
            var user = GetUserByEmail(email);
            return GetUserRoles(user);
        }

        private IEnumerable<IRole> GetUserRoles(IUser user)
        {
            var userEntity = (User)user;
            return userEntity == null ? new Role[] { } : userEntity.Roles.ToArray();
        }

        public void AddUesrToRole(Guid userId, Guid roleId)
        {
            AddUserToRole(GetUser(userId), roleId);
        }

        public void AddUserToRole(string email, Guid roleId)
        {
            AddUserToRole(GetUserByEmail(email), roleId);
        }

        private void AddUserToRole(IUser user, Guid roleId)
        {
            var userEntity = (User) user;
            var role = _unitOfWork.Repository<Role>().Get(r => r.Id == roleId).SingleOrDefault();

            if (role != null && userEntity.Roles.All(r => r.Id != roleId))
            {
                userEntity.Roles.Add(role);
                _unitOfWork.SaveChanges();
            }
        }

        public bool IsUserInRole(string email, Guid roleId)
        {
            return IsUserInRole(GetUserByEmail(email), roleId);           
        }

        public bool IsUserInRole(Guid userId, Guid roleId)
        {
            return IsUserInRole(GetUser(userId), roleId);
        }

        private bool IsUserInRole(IUser user, Guid roleId)
        {
            var userEntity = (User)user;
            return userEntity.Roles.Any(r => r.Id == roleId);
        }

        private void SetPassword(IUser user, string password)
        {
            var validationResult = _passwordValidator.ValidatePassword(password);

            if (!string.IsNullOrWhiteSpace(validationResult))
                throw new ValidationException(validationResult);

            user.PasswordHash = EncodePassword(password, user.PasswordSalt);
        }

        private string GetFriendlyUserName(string userName, string firstName, string lastName)
        {
            return userName ?? string.Format("{0} {1}", firstName, lastName);
        }

        private string EncodePassword(string pass, string salt)
        {
            var passBytes = Encoding.Unicode.GetBytes(pass);
            var saltBytes = Convert.FromBase64String(salt);

            var keyedHashAlgorithm = (KeyedHashAlgorithm)HashAlgorithm.Create("HMACSHA256");

            if (keyedHashAlgorithm == null)
            {
                throw new NotSupportedException();
            }

            var keyArray = new byte[keyedHashAlgorithm.Key.Length];
            var dstOffset = 0;

            while (dstOffset < keyArray.Length)
            {
                var count = Math.Min(saltBytes.Length, keyArray.Length - dstOffset);
                Buffer.BlockCopy(saltBytes, 0, keyArray, dstOffset, count);
                dstOffset += count;
            }

            keyedHashAlgorithm.Key = keyArray;

            var result = keyedHashAlgorithm.ComputeHash(passBytes);

            return Convert.ToBase64String(result);
        }

        private string GenerateSalt()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString().Substring(16)));
        }
    }
}
