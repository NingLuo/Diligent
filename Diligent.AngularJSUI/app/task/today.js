(function (undefined) {

    'use strict';

    angular
        .module('app.task')
        .controller('Today', Today);

    Today.$inject = [];

    function Today() {
        console.log('today ctrl');
    }

})();