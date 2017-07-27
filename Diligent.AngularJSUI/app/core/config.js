(function (undefined) {

    'use strict';

    var core = angular.module('app.core');

    core.config(['$stateProvider', '$urlMatcherFactoryProvider', function ($stateProvider, $urlMatcherFactoryProvider) {
        $urlMatcherFactoryProvider.caseInsensitive(true);
        

        var registerState = {
            name: 'register',
            url: '/register',
            templateUrl: 'app/users/register.html',
            controller: 'Register',
            controllerAs: 'vm'
        }

        $stateProvider.state(registerState);
    }]);
})();