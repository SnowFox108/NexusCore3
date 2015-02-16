(function () {
    "use strict";
    angular.module("nexusCore.Admin").factory("dataConverter", function ($filter) {
        return {
            date: function (jsonDate, formater) {
                var date = new Date(parseInt(jsonDate.substr(6)));
                if (angular.isUndefined(formater)) {
                    return $filter('date')(date, "dd-MMM-yyyy");
                } else {
                    return $filter('date')(date, formater).toLowerCase();
                }
            }
        };
    });
})();

(function () {
    "use strict";
    angular.module("nexusCore.Admin").factory("tableFilter", function () {
        var sortOrderDefaultCss = "fa-sort";
        var sortOrderDirection = function(sortDirection) {
            if (sortDirection == 0) {
                return "fa-sort-asc";
            } else {
                return "fa-sort-desc";
            }
        }
        return {
            sortOrderInit: function (table, sorting) {
                if (table.Columns.indexOf(sorting.SortOrder) > -1) {
                    table[sorting.SortOrder] = sortOrderDirection(sorting.SortDirection);
                }
                return;
            },
            sortOrder: function (table, sorting, newColumn) {
                if (table.Columns.indexOf(newColumn) > -1) {
                    var sortOrder = {
                        sortDirection: 0,
                        css: "fa-sort-asc"
                    };
                    if (newColumn == sorting.SortOrder) {
                        sortOrder.sortDirection = sorting.SortDirection == 0 ? 1 : 0;
                        sortOrder.css = sortOrderDirection(sortOrder.sortDirection);
                    }
                    sorting.SortOrder = newColumn;
                    sorting.SortDirection = sortOrder.sortDirection;
                    table[newColumn] = sortOrder.css;
                    return true;
                }
                return false;
            },
            sortOrderResetPage: function (table) {
                var i = table.Columns.length;
                while (i-- > 0) {
                    table[table.Columns[i]] = sortOrderDefaultCss;
                }
                return;
            },
            itemPerPageSetPage: function (paging, itemPerPage) {
                paging.CurrentPage = 1;
                paging.ItemsPerPage = itemPerPage;
                return;
            },
            paginationSetPage: function (paging, currentPage) {
                paging.CurrentPage = currentPage;
                return;
            }
        };
    });
})();

(function () {
    "use strict";
    angular.module("nexusCore.Admin").factory("messageBuilder", function () {
        return {
            modalErrorSummary: function (error) {
                var messages = "";
                for (var i = 0; i < error.length; i++) {
                    messages += "<li>" + error[i].ErrorMessage + "</li>";
                }
                return "<ul>" + messages + "</ul>";
            }
        }
    });
})();