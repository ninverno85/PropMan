(function () {
    'use strict';

    angular
        .module('app')
        .factory('UserFactory', UserFactory)

    UserFactory.$inject = ['$http', 'localApi'];

    function UserFactory($http, localApi) {
        var service = {
            postRegistration: postRegistration,
            searchUsers: searchUsers
        };

        return service;

        function postRegistration(registration) {
            console.log(registration);
            return $http({
                method: 'POST',
                url: localApi + '/users',
                dataType: "json",
                data: registration,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }

            }).then(function (info) {
                return info;
            }, function (error) {
                return error;
            })
        }

        function searchUsers(details){
        return $http ({
            method: 'GET',
            url: localApi+'/Users/UserSearch',
            params: details,
        }).then (function(returned){
            return returned;
        }, function (error){
            console.log("Error"+ error);
            return error;
        });
        }
    }
})();

