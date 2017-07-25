(function (undefined) {

    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', Shell);

    Shell.$inject = [];

    function Shell(parameters) {
        var vm = this;

        activate();

        function activate() {
            console.log('Shell controller');
        }
    }
})();