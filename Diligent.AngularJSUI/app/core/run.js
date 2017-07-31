(function (undefined) {

    'use strict';

    var core = angular.module('app.core');

    core.run(runConfig);

    runConfig.$inject = ['$rootScope', '$cookies'];

    function runConfig($rootScope, $cookies) {
        if ($cookies.get('isLoggedIn') == false) {
            $cookies.put('isLoggedIn', 'false');
        }

        $rootScope.isLoggedIn = $cookies.get('isLoggedIn');
        $rootScope.currentUser = $cookies.getObject('currentUser');
    }
})();