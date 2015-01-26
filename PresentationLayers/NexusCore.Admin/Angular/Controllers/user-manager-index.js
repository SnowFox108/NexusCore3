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

        $scope.itemPerPageSetPage = function() {
            $scope.searchFilter.Filter.Paging.CurrentPage = 1;
            $scope.searchFilter.Filter.Paging.ItemsPerPage = $scope.model.Paging.ItemsPerPage;
            $scope.querySearch();
        };

        $scope.paginationSetPage = function () {
            $scope.searchFilter.Filter.Paging.CurrentPage = $scope.model.Paging.CurrentPage;
            $scope.querySearch();
        };

        $scope.sortOrderInit = function () {
            $scope.sortOrderResetPage();
            if ($scope.table.Columns.indexOf($scope.searchFilter.Filter.Sorting.SortOrder) > -1) {
                $scope.table[$scope.searchFilter.Filter.Sorting.SortOrder] = tableFilter.sortOrderInit($scope.searchFilter.Filter.Sorting.SortDirection);
            }
        }

        $scope.sortOrderSetPage = function (column) {
            $scope.sortOrderResetPage();

            if ($scope.table.Columns.indexOf(column) > -1) {
                var sortOrder = tableFilter.sortOrder(column,
                    $scope.searchFilter.Filter.Sorting.SortOrder,
                    $scope.searchFilter.Filter.Sorting.SortDirection);

                $scope.searchFilter.Filter.Sorting.SortOrder = column;
                $scope.searchFilter.Filter.Sorting.SortDirection = sortOrder.sortDirection;
                $scope.table[column] = sortOrder.css;

                $scope.querySearch();
            }
        }

        $scope.sortOrderResetPage = function () {
            var i = $scope.table.Columns.length;
            while (i-- > 0) {
                $scope.table[$scope.table.Columns[i]] = tableFilter.sortOrderDefaultCss;
            }
        }

    });
})();