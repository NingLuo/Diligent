(function () {

    'use strict';

    angular
        .module('app.layout')
        .controller('Sidebar', Sidebar);

    Sidebar.$inject = ['projectResource', 'account'];

    function Sidebar(projectResource, account) {
        var vm = this;
        vm.userId = 0;
        vm.project = {};
        vm.getProjects = getProjects;
        vm.addProject = addProject;
        vm.projectFormSwitch = false;
        vm.showProjectForm = showProjectForm;
        vm.hideProjectForm = hideProjectForm;

        activate();

        function activate() {
            vm.userId = account.getCurrentUser().id;
            getProjects();
        }
      
        /////////////////////////////////////////

        function getProjects() {
            //use query for collection of objects, use get for one object           
            projectResource.query({ userId: vm.userId },
                function (data) {
                    vm.projects = data;
                },
                function (error) {
                    console.log(error);
                }
            );
        }

        function addProject() {
            vm.project.userId = vm.userId;

            projectResource.save(vm.project,
                function(data) {
                    hideProjectForm();
                    getProjects();
                },
                function(error) {
                    console.log(error);
                }
            );
        };

        function showProjectForm() {
            vm.projectFormSwitch = true;
        }

        function hideProjectForm() {
            vm.project = {};
            vm.projectFormSwitch = false;
        }
    };
})();