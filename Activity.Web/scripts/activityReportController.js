(function () {
    var app = angular.module('ActivityApp');

    app.controller('activityReportController', ['$http', '$log', '$scope', '$stateParams', 'activityService', 'alertService', function ($http, $log, $scope, $stateParams, activityService, alertService) {
        var selectedId = $stateParams.id;

        function getActivity(id) {

            activityService.getActivity(id).then(function (response) {
                $scope.selectedActivity = response.data[0];

            }).catch(function (fallback) {
                $log.log(fallback);
            });

        }


        $(function () {
            getActivity(selectedId);





        });

    }]);


})();