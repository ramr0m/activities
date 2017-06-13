(function () {
    var app = angular.module('ActivityApp');

    app.controller('activityController', ['$http', '$log', '$scope', '$stateParams', 'activityService', 'alertService', function ($http, $log, $scope, $stateParams, activityService, alertService) {
        var selectedId = $stateParams.id;
        $scope.selectedSlot = null;


        $scope.addEnrollment = function (activity_id) {
            activityService.getEmtpyEnrollment().then(function (response) {
                var enrollment = response.data;
                enrollment.reg = activity_id;
                enrollment.timeslot = $scope.selectedSlot.id;
                enrollment.user = 999;

                activityService.updateEnrollment(enrollment).then(function (response_enroll) {

                    alertService.show('info', "Ingeschreven!");

                    getActivity(activity_id);

                }).catch(function (fallback_enroll) {
                    $log.log(fallback_enroll);
                });


                //$scope.$parent.loadEvents();

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

        $scope.isSlotOccupied = function (slotid, selectedActivityId) {
            for (i = 0; i < $scope.occupiedSlots.length; i++) {
                if ($scope.occupiedSlots[i].timeslot === slotid && $scope.occupiedSlots[i].reg === parseInt(selectedActivityId))
                    return true;
            }
        }


        function getActivity(id) {

            activityService.getActivity(id).then(function (response) {
                $scope.selectedActivity = response.data[0];
                

                activityService.getEnrollment(id).then(function (responsE) {
                    $scope.occupiedSlots = responsE.data;
                    
                    
                    $scope.isEnrolledByCurrentUser = false;
                    //var slots = $scope.selectedActivity.slots;
                    //for (i = 0; i < slots.length; i++) {
                    //    if (slots[i].reg === parseInt(selectedActivityId) && slots[i].user === "999"){
                    //        $scope.isEnrolledByCurrentUser = true;
                    //        break;
                    //    }
                    //}
                    //loadEvents();
                }).catch(function (fallbackE) {
                    $log.log(fallbackE);
                });




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