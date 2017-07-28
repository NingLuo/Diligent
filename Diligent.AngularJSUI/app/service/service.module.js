(function (undefined) {

    'use strict';

    angular
        .module('app.service', ['ngResource'])
        .constant('appSettings',
            {
                serverPath: "http://localhost:9535/"
            });

})();