(function (undefined) {

    'use strict';

    angular
        .module('app.user')
        .controller('Logout', Logout);

    Logout.$inject = ['$state', 'account'];

    function Logout($state, account) {
        var vm = this;

        active();

        function active() {
            account.logout();
            $state.go('login');
        }
    }

})();