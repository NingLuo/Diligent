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
                utilityService.triggerFormValidations($scope.registerForm);
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        }
    }

})();