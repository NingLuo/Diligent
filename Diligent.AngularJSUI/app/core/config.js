(function (undefined) {

    'use strict';

    var core = angular.module('app.core');

    core.config(configure);

    configure.$inject = ['$stateProvider', '$urlMatcherFactoryProvider', '$urlRouterProvider',
                         '$locationProvider'];

    function configure($stateProvider, $urlMatcherFactoryProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/register');
        $urlMatcherFactoryProvider.caseInsensitive(true);
        
        var registerState = {
            name: 'register',
            url: '/register',
            templateUrl: 'app/users/register.html',
            controller: 'Register',
            controllerAs: 'vm'
        }

        $stateProvider.state(registerState);

        $locationProvider.html5Mode(true);
    }
})();