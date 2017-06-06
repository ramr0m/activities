(function () {
    var app = angular.module('ActivityApp');

    app.controller('activityController', ['$http', '$log', '$scope', '$stateParams', 'activityService', 'alertService', function ($http, $log, $scope, $stateParams, activityService, alertService) {
        var id = $stateParams.id;
        


        $scope.addEnrollment = function (activity_id) {
            activityService.getEmtpyEnrollment().then(function (response) {
                var enrollment = response.data;
                enrollment.reg = activity_id;
                enrollment.timeslot = $scope.selectedSlot.id;
                enrollment.user = 999;

                activityService.updateEnrollment(enrollment).then(function (response_enroll) {

                    alertService.show('info', "Ingeschreven!");

                    //loadEvents();

                }).catch(function (fallback_enroll) {
                    $log.log(fallback_enroll);
                });


                //$scope.$parent.loadEvents();

                getActivity(activity_id);
            }).catch(function (fallback) {
                $log.log(fallback);
            });
        }

        $scope.addEvent = function () {

            activityService.getEmtpyEvent().then(function (response) {
                $scope.selectedEvent = response.data;
                $log.log("Empty event loaded.");

                //$scope.$parent.loadEvents();
            }).catch(function (fallback) {
                $log.log(fallback);
            });

        }


        $scope.selectSlot = function (slot) {
            $scope.selectedSlot = slot;
        }

        $scope.addSlot = function () {
            activityService.getEmtpySlot().then(function (response) {
                var newslot = response.data;
                if ($scope.selectedEvent.slots == null) {
                    $scope.selectedEvent.slots = [];
                }
                $scope.selectedEvent.slots.push(newslot);
                $log.log("Empty event loaded.");

                //loadEvents();
            }).catch(function (fallback) {
                $log.log(fallback);
            });
        }


        $scope.saveEvent = function () {

            activityService.updateEvent($scope.selectedEvent).then(function (response) {

                alertService.show('info', "Saved event:" + $scope.selectedEvent.name);

                loadEvents();

            }).catch(function (fallback) {
                $log.log(fallback);
            });
        }

        $scope.deleteActivity = function (activity) {

            activityService.deleteEvent(activity.id).then(function (response) {
                alertService.show('info', "Event verwijderd");
                loadEvents();
            }).catch(function (fallback) {
                $log.log(fallback);
            });

        }

        $scope.modifySlot = function (slot) {
            $scope.isSlotEdit = !$scope.isSlotEdit;
        }


        $scope.removeSlot = function (slot) {

            for (var i = 0; i < $scope.selectedEvent.slots.length; i++)
                if ($scope.selectedEvent.slots[i].id === slot.id) {
                    $scope.selectedEvent.slots.splice(i, 1);
                    break;
                }

        }


        $scope.getActivity = function (id) {

            activityService.getActivity(id).then(function (response) {
                $scope.selectedActivity = response.data[0];

            }).catch(function (fallback) {
                $log.log(fallback);
            });

        }



    }]);


})();