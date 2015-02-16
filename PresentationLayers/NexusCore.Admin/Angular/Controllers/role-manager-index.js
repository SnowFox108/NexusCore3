(function () {
    'use strict';

    angular.module('nexusCore.Admin').controller("roleManager", function ($scope, apiCall, dataConverter, dialogs, messageBuilder, tableFilter) {

        $scope.table = {
            Columns: ["RoleName"],
            RoleName: ""
        };

        $scope.init = function () {
            apiCall([
                { url: "/ModelBuilder/RoleSearchFilter" }
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
                { postMethod: "POST", url: "/RoleManager/GetRoleList", data: { searchFilter: $scope.searchFilter } }
            ]).then(function (data) {
                $scope.model = data[0];
                $scope.friendlyDisplay();
                //console.log($scope.roleManager);
            });
        };

        $scope.friendlyDisplay = function() {
            var i = $scope.model.Roles.length;
            while (i-- > 0) {
                $scope.model.Roles[i].type = {
                    Text: $scope.model.Roles[i].IsSystemRole ? "System"
                        : "Custom",
                    Css: $scope.model.Roles[i].IsSystemRole ? "label-info" : "label-success"
                }
            }
        }

        $scope.deleteRole = function(role) {
            var dlg = dialogs.confirm("Confirm to Delete","Are you sure you want to delete '" + role.RoleName + "'?");
            dlg.result.then(function(btn) {
                apiCall([
                    { postMethod: "POST", url: "/RoleManager/DeleteRole", data: { roleId: role.Id } }
                ]).then(function (data) {
                    dialogs.notify("Infomation", data[0]);
                    $scope.itemPerPageSetPage();
                }, function (error) {
                    dialogs.error("Error", messageBuilder.modalErrorSummary(error));
                });
            });
        }

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