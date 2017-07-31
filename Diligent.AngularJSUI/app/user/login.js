(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Login', Login);

    Login.$inject = ['$scope', 'userResource', 'utility', '$state', 'account'];

    function Login($scope, userResource, utility, $state, account) {
        var vm = this;
        vm.clientErrorMessages = [];
        vm.serverErrorMessages = [];

        vm.submit = function (user, isValid) {
            utility.clearErrorMessages(vm);
            if (isValid) {                             
                account.login(user).then(
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
                utility.triggerFormValidations($scope.loginForm);
                vm.clientErrorMessages.push("Please correct the validation errors.");
            }
        };
    }

})();