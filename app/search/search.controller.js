(function () {
    'use strict';

    angular
        .module('app')
        .controller('SearchController', SearchController);

    SearchController.$inject = ['PropertyFactory', 'UserFactory', 'localStorageService']

    function SearchController(PropertyFactory, UserFactory,  localStorageService
    ) {
        var vm = this;
        vm.title = 'searchController';        
        vm.searchObject = {};
        vm.userObject = {};
        vm.searchObject.bedrooms = 0;
        vm.searchObject.bathrooms = 0;
        vm.searchObject.minRent = 0;
        vm.searchObject.maxRent = 0;
        vm.searchObject.city = "";
        vm.searchObject.zipCode = 0;
        vm.userObject.userName = "";
        vm.userObject.email = "";
        vm.showResults = false;
        vm.propertyOwner = false;
        vm.signedIn = true;

        vm.propertySearch = function (searchObject) {

            PropertyFactory
                .propSearch(searchObject)
                .then(function (response) {

                    searchResults(response.data);
                    console.log(response);
                    vm.showResults = true;

                }, function (error) {
                    console.log(error);
                })
        }



        vm.login = function (loginObject) {
            UserFactory
                .searchUsers(loginObject)
                .then(function (returned) {
                    alert("Logged In");
                    localStorageService.set('userName', returned.data.userName);
                    var name = localStorageService.get('userName');
                    vm.propertyOwner = returned.data.propertyOwner;
                    vm.signedIn = false;
                    console.log(returned);
                }, function (error) {
                    console.log(error);
                })
        }

        function searchResults(results) {
            // console.log(results);
            // for (var i = 0; i < results.length; i++) {
               vm.foundProperty = results;
                console.log(vm.foundProperty);
                console.log(results.data);
           // }
        };


    }
})();