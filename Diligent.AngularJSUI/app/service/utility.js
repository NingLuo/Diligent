(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('utilityService', utilityService);

    utilityService.$inject = [];

    function utilityService() {
        var service = {
            clearErrorMessages: clearErrorMessages,
            triggerFormValidations: triggerFormValidations
        }

        return service;
        ///////////////////////////

        function clearErrorMessages(viewModel) {
            viewModel.serverErrorMessages = [];
            viewModel.clientErrorMessages = [];
        }

        function triggerFormValidations(form) {
            angular.forEach(form.$error, function (field) {
                angular.forEach(field, function (errorField) {
                    errorField.$setTouched();
                });
            });
        }
    }

})();