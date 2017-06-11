(function () {
    var app = angular.module('ActivityApp');

    app.controller('activityManageController', ['$http', '$log', '$scope', '$stateParams', 'activityService', 'alertService', function ($http, $log, $scope, $stateParams, activityService, alertService) {
        var selectedId = $stateParams.id;
        

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
                alertService.show('info', "Event deleted");
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


        function getActivity(id) {

            activityService.getActivity(id).then(function (response) {
                $scope.selectedActivity = response.data[0];
                $scope.activities = response.data;
            }).catch(function (fallback) {
                $log.log(fallback);
            });

        }

        function loadEvents() {
            activityService.getAll().then(function (response) {
                $scope.activities = response.data;
                $log.log("events loaded.");
            }).catch(function (fallback) {
                $log.log(fallback);
            });
        }

        $('#activitydialog').on('hidden.bs.modal', function () {
            loadEvents();
        })

        $(function () {
            loadEvents();


        });

    }]);


})();