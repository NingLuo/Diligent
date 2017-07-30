(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Login', Login);

    Login.$inject = ['$scope', 'userResource', 'utilityService'];

    function Login($scope, userResource, utilityService) {
        var vm = this;
        vm.clientErrorMessages = [];
        vm.serverErrorMessages = [];

        vm.submit = function (user, isValid) {
            utilityService.clearErrorMessages(vm);
            if (isValid) {             
                userResource.login(user, function (data) {
                    console.log(data);
                },function(error) {
                    vm.serverErrorMessages = error.data.modelState;
                });                
            }
            else {
                utilityService.triggerFormValidations($scope.loginForm);
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        };
    }

})();