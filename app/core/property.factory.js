(function () {
    'use strict';

    angular
        .module('app')
        .factory('PropertyFactory', PropertyFactory);

    PropertyFactory.$inject = ['$http', 'localApi'];

    function PropertyFactory($http, localApi) {
        var service = {
            propSearch: propSearch,
            postProperty: postProperty
        };

        return service;

        function propSearch(searchParameters) {


            return $http({
                Method: 'GET',
                url: localApi + 'Properties/PropertySearch',
                params: searchParameters
            }).then(function (response) {
                return response;
            }, function (error) {
                console.log("Error" + error);
                return error;
            });


        }

        function postProperty(propertyInfo) {
            console.log(propertyInfo);
            return $http({
                method: 'POST',
                url: localApi + '/Properties',
                dataType: "json",
                data: propertyInfo,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }

            }).then(function (info) {
                return info;
            }, function (error) {
                return error;
            })
        }
    }
})();