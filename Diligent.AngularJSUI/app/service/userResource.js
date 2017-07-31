(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('userResource', userResource);

    userResource.$inject = ['$resource', 'appSettings'];

    function userResource($resource, appSettings) {
        return $resource(appSettings.serverPath + '/api/user/:id', null,
            {
                'login': {
                    url: appSettings.serverPath + '/api/user/login',
                    method: 'POST',
                    isArray: false
                }
            });
    };

})();