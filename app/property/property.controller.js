(function () {
    'use strict';

    angular
        .module('app')
        .controller('PropertyController', PropertyController);

    PropertyController.$inject = ['PropertyFactory','localStorageService'];

    function PropertyController(PropertyFactory,localStorageService) {
        var vm = this;

        vm.propObject = {};
        vm.propObject.userId=1;
        vm.propObject.propertyName = "";
        vm.propObject.address1 = "";
        vm.propObject.address2 = "";
        vm.propObject.city = "";
        vm.propObject.state = "";
        vm.propObject.zipCode = 0;
        vm.propObject.phoneNumber = "";
        vm.propObject.rentMonth = 0;
        vm.propObject.squareFoot = 0;
        vm.propObject.bedrooms =0;
        vm.propObject.bathrooms = 0;
        vm.propObject.leaseTerms = 0;
        vm.propObject.imagePath = "/imagepath";
        vm.propObject.pets = false;


        ////////////////

         vm.addProperty = function(propertyInfo) {
   
            PropertyFactory
                .postProperty(propertyInfo)
                .then(function (response) {
                    console.log(response);
                    toastr.success("New property added");
                    //goSomewhere();
                }, function (error) {
                    console.log(error);
                })
         };

        //function goSomewhere() {
               // $state.go('searchGrid');
        //};
    };
})();