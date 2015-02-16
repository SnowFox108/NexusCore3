using NexusCore.Common.Data.Entities.Membership;
using NexusCore.Common.Data.Infrastructure;
using NexusCore.Common.Data.Models.Infrastructure;
using NexusCore.Common.Data.Models.Memberships;
using NexusCore.Common.Data.Specifications;
using NexusCore.Common.Helper.Extensions;
using NexusCore.Common.Services.MembershipServices;
using NexusCore.Core.Services.Infrastructure;
using NexusCore.Infrasructure.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NexusCore.Core.Services.MembershipComponent.Primitive
{
    public class UserPrimitive : BasePrimitiveService, IUserPrimitive
    {
        public UserPrimitive(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public int GetUserCount(UserSearchFilter searchFilter)
        {
            return UnitOfWork.Repository<User>()
                .Get(MembershipSpecifications.GetUser(searchFilter)).Count();
        }

        public IEnumerable<User> GetUsers(UserSearchFilter searchFilter)
        {
            return UnitOfWork.Repository<User>()
                .Get(MembershipSpecifications.GetUser(searchFilter),
                    u => u.OrderBy(searchFilter.Filter.Sorting.SortOrder, searchFilter.Filter.Sorting.SortDirection),
                    pageNumber: searchFilter.Filter.Paging.CurrentPage,
                    pageSize: searchFilter.Filter.Paging.ItemsPerPage);
        }

        public IEnumerable<User> GetUsers(string sortColumn = "FirstName", SortDirection sortDirection = SortDirection.Asc, int pageNumber = 1, int pageSize = 10)
        {
            return UnitOfWork.Repository<User>()
                .Get(orderBy: u => u.OrderBy(sortColumn, sortDirection), pageNumber: pageNumber, pageSize: pageSize);
        }

        public User GetUser(Guid userId)
        {
            return UnitOfWork.Repository<User>().GetById(userId);
        }

        public void UpdateUser(User user)
        {
            UnitOfWork.Repository<User>().Update(user);
        }

        public void DeleteUser(User user)
        {
            user.IsActive = false;
            user.IsAnonymous = true;
            user.IsDelete = true;
            UnitOfWork.Repository<User>().Update(user);
        }


        public T MapToTrackableUser<T>(LogableModel tracker)
        {
            tracker.CreatedByUser = GetUser(tracker.CreatedBy).MapTo<CurrentUserModel>();
            return (T) (object) tracker;
        }

        public IEnumerable<T> MapToTrackableUser<T>(IEnumerable<LogableModel> trackers)
        {
            foreach (var tracker in trackers)
            {
                tracker.CreatedByUser = GetUser(tracker.CreatedBy).MapTo<CurrentUserModel>();
                yield return (T) (object) tracker;
            }
        }

        public T MapToTrackableUser<T>(TrackableModel tracker)
        {
            tracker.CreatedByUser = GetUser(tracker.CreatedBy).MapTo<CurrentUserModel>();
            tracker.UpdatedByUser = GetUser(tracker.UpdatedBy).MapTo<CurrentUserModel>();
            return (T) (object) tracker;
        }

        public IEnumerable<T> MapToTrackableUser<T>(IEnumerable<TrackableModel> trackers)
        {
            foreach (var tracker in trackers)
            {
                tracker.CreatedByUser = GetUser(tracker.CreatedBy).MapTo<CurrentUserModel>();
                tracker.UpdatedByUser = GetUser(tracker.UpdatedBy).MapTo<CurrentUserModel>();
                yield return (T) (object) tracker;
            }
        }

    }
}
