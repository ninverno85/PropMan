(function() {
'use strict';

    angular
        .module('app')
        .factory('LocalStorageFactory', LocalStorageFactory);

    LocalStorageFactory.inject = ['$http'];
    function LocalStorageFactory($http) {
        var service = {
            propSearch:propSearch
        };
        return service
    }
})();