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





        $scope.getEnrollmentForActivity = function (activity_id, slot_id) {
            activityService.getEnrollment(activity_id).then(function (response) {
                var enrollments = response.data;
                for (i = 0; i < enrollments.length; i++) {
                    if (enrollments[i].timeslot === slot_id) return true;
                }
                return false;

                //loadEvents();
            }).catch(function (fallback) {
                $log.log(fallback);
            });
        }


        $(function () {
            getActivity(selectedId);





        });

    }]);


})();