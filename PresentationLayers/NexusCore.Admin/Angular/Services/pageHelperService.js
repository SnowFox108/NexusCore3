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
        return {
            sortOrderDefaultCss: "fa-sort",
            sortOrderInit: function (sortDirection) {
                if (sortDirection == 0) {
                    return "fa-sort-asc";
                } else {
                    return "fa-sort-desc";
                }
            },
            sortOrder: function (newColumn, oldColumn, sortDirection) {
                var sortOrder = {
                    sortDirection: 0,
                    css: "fa-sort-asc"
                };
                if (newColumn == oldColumn) {
                    sortOrder.sortDirection = sortDirection == 0 ? 1 : 0;
                    if (sortOrder.sortDirection == 0) {
                        sortOrder.css = "fa-sort-asc";
                    } else {
                        sortOrder.css = "fa-sort-desc";
                    }
                }
                return sortOrder;
            }
        };
    });
})();

(function() {
    "use strict";
    angular.module("nexusCore.Admin").factory("messageBuilder", function () {
        return {
            modalErrorSummary: function(error) {
                var messages = "";
                for (var i = 0; i < error.length; i++) {
                    messages += "<li>" + error[i].ErrorMessage + "</li>";
                }
                return "<ul>" + messages + "</ul>";
            }
        }
    });
})();