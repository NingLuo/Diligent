(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Register', Register);

    Register.$inject = ['$scope', 'userResource', 'utilityService'];

    function Register($scope, userResource, utilityService) {
        var vm = this;
        vm.clientErrorMessages = [];

        vm.submit = function (user, isValid) {
            utilityService.clearErrorMessages(vm);
            if (isValid) {
                userResource.save(user,
                    function (data) {
                        console.log(data);                       
                    },
                    function(error) {
                        vm.serverErrorMessages = error.data.modelState;
                    });
            }
            else {
                vm.triggerAllValidations();
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        }

        vm.triggerAllValidations = function() {
            angular.forEach($scope.registerForm.$error, function(field) {
                angular.forEach(field,function(errorField) {
                    errorField.$setTouched();
                });
            });
        };
    }

})();