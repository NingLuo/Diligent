(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('utilityService', utilityService);

    utilityService.$inject = [];

    function utilityService() {
        var service = {
            clearErrorMessages: clearErrorMessages
        }

        return service;
        ///////////////////////////

        function clearErrorMessages(viewModel) {
            viewModel.serverErrorMessages = [];
            viewModel.clientErrorMessages = [];
        }
    }

})();