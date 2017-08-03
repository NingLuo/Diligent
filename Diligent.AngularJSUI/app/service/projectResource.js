(function (undefined) {

    'use strict';

    angular
        .module('app.service')
        .factory('projectResource', projectResource);

    projectResource.$inject = ['$resource', 'appSettings'];

    function projectResource($resource, appSettings) {
        return $resource(appSettings.serverPath + '/api/user/:userId/project/:id', {userId: '@userId', id:'@id'});
    };

})();