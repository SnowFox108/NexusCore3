(function () {
    "use strict";
    angular.module("nexusCore.Admin").factory("dateConverter", function ($filter) {
        return function (jsonDate, formater) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            if (angular.isUndefined(formater)) {
                return $filter('date')(date, "dd-MMM-yyyy");
            } else {
               return $filter('date')(date, formater).toLowerCase();                
            }
        };
    });
})();