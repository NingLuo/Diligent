(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Login', Login);

    function Login() {
        var vm = this;

        activate();

        function activate() {
            console.log('Login controller');
        }
    }

})();