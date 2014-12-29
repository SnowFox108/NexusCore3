(function () {
    "use strict";
    angular.module("nexusCore.Admin").factory("apiCall", function ($q, $http) {
        return function (apiCalls) {
            var i = apiCalls.length;
            while (i-- > 0) {
                if (angular.isUndefined(apiCalls[i].postMethod)) {
                    apiCalls[i].postMethod = "GET";
                }
                if (angular.isUndefined(apiCalls[i].params)) {
                    apiCalls[i].params = {};
                }
                if (angular.isUndefined(apiCalls[i].data)) {
                    apiCalls[i].data = {};
                }
            }

            var call = apiCalls.map(function (callHeader) {
                var deffered = $q.defer();
                $http({
                    url: callHeader.url,
                    method: callHeader.postMethod,
                    params: callHeader.params,
                    data: callHeader.data
                }).success(function (data) {
                    return deffered.resolve(data);
                }).error(function (error) {
                    return deffered.reject(error);
                });
                return deffered.promise;
            });
            return $q.all(call);
        };
    });
})();