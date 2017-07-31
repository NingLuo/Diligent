(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Register', Register);

    Register.$inject = ['$scope', 'userResource', 'utilityService', 'account', '$state'];

    function Register($scope, userResource, utilityService, account, $state) {
        var vm = this;
        vm.clientErrorMessages = [];

        vm.submit = function (user, isValid) {
            utilityService.clearErrorMessages(vm);
            if (isValid) {               
                account.register(user).then(
                    function (data) {
                        account.setCurrentUser(data);
                        $state.go('today');
                    },
                    function (error) {
                        vm.serverErrorMessages = error.data.modelState;
                    }
                );
            }
            else {
                utilityService.triggerFormValidations($scope.registerForm);
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        }
    }

})();