(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Register', Register);

    Register.$inject = ['$scope', 'userResource', 'utility', 'account', '$state'];

    function Register($scope, userResource, utility, account, $state) {
        var vm = this;
        vm.clientErrorMessages = [];

        vm.submit = function (user, isValid) {
            utility.clearErrorMessages(vm);
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
                utility.triggerFormValidations($scope.registerForm);
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        }
    }

})();