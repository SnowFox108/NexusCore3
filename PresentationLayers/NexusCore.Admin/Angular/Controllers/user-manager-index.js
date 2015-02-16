(function () {
    'use strict';

    angular.module('nexusCore.Admin').controller("userManager", function ($scope, apiCall, dataConverter, tableFilter) {

        $scope.table = {
            Columns: ["Email", "FirstName", "LastName", "LastActivityDate"],
            Email: "",
            FirstName: "",
            LastName: "",
            LastActivityDate: ""
        };

        $scope.init = function () {
            apiCall([
                { url: "/ModelBuilder/UserSearchFilter" }
            ]).then(function (data) {
                $scope.searchFilter = data[0];
                $scope.sortOrderInit();
                $scope.querySearch();
            });
        };

        $scope.applySearchFilter = function () {
            $scope.querySearch();
        };

        $scope.querySearch = function () {
            apiCall([
                { postMethod: "POST", url: "/UserManager/GetUserList", data: { searchFilter: $scope.searchFilter } }
            ]).then(function (data) {
                $scope.model = data[0];
                $scope.friendlyDisplay();
                //console.log($scope.model);
            });
        };

        $scope.friendlyDisplay = function () {
            var i = $scope.model.Users.length;
            while (i-- > 0) {
                $scope.model.Users[i].CreatedDate = dataConverter.date($scope.model.Users[i].CreatedDate);
                $scope.model.Users[i].LastActivityDate = dataConverter.date($scope.model.Users[i].LastActivityDate);
                $scope.model.Users[i].UpdatedDate = dataConverter.date($scope.model.Users[i].UpdatedDate);
                $scope.model.Users[i].UserStatus = {
                    Text: $scope.model.Users[i].IsActive ? "Active"
                        : $scope.model.Users[i].IsAnonymous ? "Anonymous"
                        : $scope.model.Users[i].IsDelete ? "Deleted"
                        : "InActive",
                    Css: $scope.model.Users[i].IsActive ? "label-success" : $scope.model.Users[i].IsAnonymous ? "label-warning" : $scope.model.Users[i].IsDelete ? "label-danger" : "label-danger"
                }
            }
        };

        // Table Paging and Sorting        
        $scope.itemPerPageSetPage = function () {
            tableFilter.itemPerPageSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.ItemsPerPage);
            $scope.querySearch();
        };

        $scope.paginationSetPage = function () {
            tableFilter.paginationSetPage($scope.searchFilter.Filter.Paging, $scope.model.Paging.CurrentPage);
            $scope.querySearch();
        };

        $scope.sortOrderInit = function () {
            tableFilter.sortOrderResetPage($scope.table);
            tableFilter.sortOrderInit($scope.table, $scope.searchFilter.Filter.Sorting);
        };

        $scope.sortOrderSetPage = function (column) {
            tableFilter.sortOrderResetPage($scope.table);
            if (tableFilter.sortOrder($scope.table, $scope.searchFilter.Filter.Sorting, column)) {
                $scope.querySearch();
            }
        }

    });
})();