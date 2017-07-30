(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Login', Login);

    Login.$inject = ['$scope', 'userResource'];

    function Login($scope, userResource) {
        var vm = this;
        vm.clientErrorMessages = [];
        vm.serverErrorMessages = [];

        vm.submit = function(user, isValid) {
            if (isValid) {
                vm.clearErrorMessages();
                userResource.login(user, function (data) {
                    console.log(data);
                },function(error) {
                    vm.serverErrorMessages = error.data.modelState;
                });                
            }
            else {
                vm.triggerAllValidations();
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        };

        vm.clearErrorMessages = function () {
            vm.serverErrorMessages = null;
            vm.clientErrorMessages = null;
        };

        vm.triggerAllValidations = function () {
            angular.forEach($scope.loginForm.$error, function (field) {
                angular.forEach(field, function (errorField) {
                    errorField.$setTouched();
                });
            });
        };
    }

})();