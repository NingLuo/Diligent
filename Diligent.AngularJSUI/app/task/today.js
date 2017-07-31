(function (undefined) {

    'use strict';

    angular
        .module('app.task')
        .controller('Today', Today);

    Today.$inject = ['$rootScope'];

    function Today($rootScope) {
        console.log('today ctrl');
        console.log($rootScope.isLoggedIn, $rootScope.currentUser);
    }

})();