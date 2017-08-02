(function (undefined) {

    'use strict';

    var core = angular.module('app.core');

    core.config(configure);

    configure.$inject = ['$stateProvider', '$urlMatcherFactoryProvider', '$urlRouterProvider',
                         '$locationProvider', '$compileProvider'];

    function configure($stateProvider, $urlMatcherFactoryProvider, $urlRouterProvider, $locationProvider, $compileProvider) {
        $urlRouterProvider.otherwise('/login');
        $urlMatcherFactoryProvider.caseInsensitive(true);

        var registerState = {
            name: 'register',
            url: '/register',
            templateUrl: 'app/user/register.html',
            controller: 'Register',
            controllerAs: 'vm'
        };

        var loginState = {
            name: 'login',
            url: '/login',
            templateUrl: 'app/user/login.html',
            controller: 'Login',
            controllerAs: 'vm'
        };

        var logoutState = {
            name: 'logout',
            url: '/logout',
            controller: 'Logout',
            controllerAs: 'vm'
        }

        var todayState = {
            name: 'today',
            url: '/today',
            templateUrl: 'app/task/today.html',
            controller: 'Today',
            controllerAs: 'vm'
        }

        $stateProvider.state(registerState);
        $stateProvider.state(loginState);
        $stateProvider.state(logoutState);
        $stateProvider.state(todayState);

        $locationProvider.html5Mode(true);
        // Remove ng-scope div
        $compileProvider.debugInfoEnabled(false);
    }
})();