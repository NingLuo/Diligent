(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('utility', utility);

    utility.$inject = [];

    function utility() {
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