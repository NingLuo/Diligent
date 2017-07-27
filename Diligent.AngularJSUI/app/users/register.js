(function (undefined) {

    'use strict';

    angular
        .module('app.users')
        .controller('Register', Register);

    function Register() {
        var vm = this;

        activate();

        function activate() {
            console.log('register controller');
        }
    }

})();