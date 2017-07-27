(function (undefined) {

    'use strict';

    angular
        .module('app.users')
        .controller('Login', Login);

    function Login() {
        var vm = this;

        activate();

        function activate() {
            console.log('Login controller');
        }
    }

})();