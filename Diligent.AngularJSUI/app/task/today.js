(function (undefined) {

    'use strict';

    angular
        .module('app.task')
        .controller('Today', Today);

    Today.$inject = ['$rootScope'];

    function Today($rootScope) {
        var vm = this;
        vm.today = new Date();

        vm.addTask = function(task) {
            console.log(task);
        }
    }

})();