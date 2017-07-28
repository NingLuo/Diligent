(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Register', Register);

    Register.$inject = ['userResource'];

    function Register(userResource) {
        var vm = this;
        vm.username;
        vm.email;
        vm.password;

        vm.submit = function () {
            var newUser = {
                username: vm.username,
                email: vm.email,
                password: vm.password
            };
            userResource.save(newUser);
        }
    }

})();