(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('account', account);

    account.$inject = ['$cookies', '$rootScope', 'userResource'];

    function account($cookies, $rootScope, userResource) {
        var service = {
            register: register,
            login: login,
            logout: logout,
            setCurrentUser: setCurrentUser,
            getCurrentUser: getCurrentUser
        }

        return service;
        ///////////////////////////

        function register(user) {
            return userResource.save(user).$promise;
        }

        function login(user) {
            return userResource.login(user).$promise;
        }

        function logout() {
            $cookies.put('isLoggedIn', 'false');
            $rootScope.isLoggedIn = $cookies.get('isLoggedIn');

            $cookies.putObject('currentUser', null);
            $rootScope.currentUser = $cookies.getObject('currentUser');
        }

        function setCurrentUser(user) {
            if (user) {
                $cookies.put('isLoggedIn', 'true');
                $rootScope.isLoggedIn = $cookies.get('isLoggedIn');

                $cookies.putObject('currentUser', user);
                $rootScope.currentUser = $cookies.getObject('currentUser');
            }
            else {
                console.log('Unable to set user profile', user);
            }
        }

        function getCurrentUser() {
            return $rootScope.currentUser;
        }
    }

})();