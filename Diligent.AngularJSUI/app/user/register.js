(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Register', Register);

    Register.$inject = ['$scope', 'userResource'];

    function Register($scope, userResource) {
        var vm = this;
        vm.clientErrorMessages = [];

        vm.submit = function (user, isValid) {
            if (isValid) {
                userResource.save(user,
                    function(data) {
                        console.log(data);
                        vm.clearErrorMessages();
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

        vm.clearErrorMessages = function() {
            vm.serverErrorMessages = null;
            vm.clientErrorMessages = null;
        };

        vm.triggerAllValidations = function() {
            angular.forEach($scope.registerForm.$error, function(field) {
                angular.forEach(field,function(errorField) {
                    errorField.$setTouched();
                });
            });
        };
    }

})();