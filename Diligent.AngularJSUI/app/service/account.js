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
            setCurrentUser: setCurrentUser
        }

        return service;
        ///////////////////////////

        function register(user) {
            return userResource.save(user).$promise;
        }

        function login(user) {
            return userResource.login(user).$promise;
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
    }

})();