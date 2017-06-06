(function () {
    var app = angular.module('ActivityApp', ['ui.router', 'lumx']);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");
        $stateProvider.state('home', {
            url: '/'
        })
        .state("activity", {
            url: '/activity/:id',
            sticky: true,
            views: {
                "main": {
                    templateUrl: "/views/enrollactivity.html",
                    controller: "activityController"
                }
            }
        })
        .state("manage", {
            url: '/activity/manage/:id',
            sticky: true,
            views: {
                "main": {
                    templateUrl: "/views/manageactivity.html",
                    controller: "activityController"
                }
            }
        });
    });


    app.factory("activityService", ['$http', '$log', function DownloadService($http, $log) {
        return {
            getActivity: function (id) {
                return $http.get('/api/activity/' + id)
            },
            getAll: function () {
                return $http.get('/api/activity');
            },
            updateEvent: function (data) {
                return $http.post('/api/activity/', data);
            },
            deleteEvent: function (id) {
                return $http.delete('/api/activity/' + id);
            },
            getEmtpyEvent: function () {
                return $http.get('/api/activity/empty');
            },
            getEmtpySlot: function () {
                return $http.get('/api/slot/empty');
            },
            getEmtpyEnrollment: function () {
                return $http.get('/api/enrollment/empty');
            },
            deleteSlot: function (id) {
                return $http.delete('/api/activity/slot/' + id);
            },
            updateEnrollment: function (data) {
                return $http.post('/api/enrollment/', data);
            },
            getEnrollment: function (activity_id) {
                return $http.get('/api/activity/' + activity_id + '/enrollment');
            },


        }
    }]);

    app.controller('ActivityMainController', ['$http', '$scope', '$log', '$stateParams', '$state', 'activityService', 'alertService', function ($http, $scope, $log, $stateParams, $state, activityService, alertService) {
        //$scope.uploadData = null;
        $scope.activitys = [];
        alertService.hide();

        $scope.modifyEvent = function (activity) {
            $scope.selectedEvent = activity;

            $scope.activitytitle = "Edit " + activity.name;
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

    app.factory("alertService", ['$http', '$log', '$timeout', function AlertService($http, $log, $timeout) {
        return {
            show: function (type, message) {
                var classname;
                if (type == 'warning') {
                    classname = 'alert alert-warning';
                }
                else if (type = 'info') {
                    classname = 'alert alert-info';
                }
                document.getElementById('myalert').className = classname;
                document.getElementById('myalert').innerText = message;
                $('.alert').hide().show('medium');
                $timeout(function () {
                    $('.alert').hide();
                }, 3000);
            },
            hide: function () {
                $('.alert').hide();
            }
        }
    }]);

})();