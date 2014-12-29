(function () {
    'use strict';

    angular.module('nexusCore.Admin').controller("userManager", function ($scope, apiCall, dateConverter) {

        $scope.init = function () {
            apiCall([
                { url: "/ModelBuilder/UserSearchFilter" }
            ]).then(function (data) {
                $scope.searchFilter = data[0];
                $scope.queryUserList();
            });
        };

        $scope.applySearchFilter = function () {
            $scope.queryUserList();
        };

        $scope.queryUserList = function () {
            apiCall([
                { postMethod: "POST", url: "/UserManager/GetUserList", data: { searchFilter: $scope.searchFilter } }
            ]).then(function (data) {
                $scope.userManager = data[0];
                $scope.friendlyDisplay();
                console.log($scope.userManager);
            });
        };

        $scope.friendlyDisplay = function () {
            var i = $scope.userManager.Users.length;
            while (i-- > 0) {
                $scope.userManager.Users[i].CreatedDate = dateConverter($scope.userManager.Users[i].CreatedDate);
                $scope.userManager.Users[i].LastActivityDate = dateConverter($scope.userManager.Users[i].LastActivityDate);
                $scope.userManager.Users[i].UpdatedDate = dateConverter($scope.userManager.Users[i].UpdatedDate);
                $scope.userManager.Users[i].UserStatus = {
                    Text: $scope.userManager.Users[i].IsActive ? "Active"
                        : $scope.userManager.Users[i].IsAnonymous ? "Anonymous"
                        : $scope.userManager.Users[i].IsDelete ? "Deleted"
                        : "InActive",
                    Css: $scope.userManager.Users[i].IsActive ? "label-success" : $scope.userManager.Users[i].IsAnonymous ? "label-warning" : $scope.userManager.Users[i].IsDelete ? "label-danger" : "label-danger"
                }
            }
        };
    });
})();