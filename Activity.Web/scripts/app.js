(function () {
    var app = angular.module('ActivityApp', ['ui.router', 'lumx', 'angular.filter']);

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
            url: '/activity/manage',
            sticky: true,
            views: {
                "main": {
                    templateUrl: "/views/manageactivity.html",
                    controller: "activityManageController"
                }
            }
        })
        .state("report", {
            url: '/activity/report/:id',
            sticky: true,
            views: {
                "main": {
                    templateUrl: "/views/reportactivity.html",
                    controller: "activityReportController"
                }
            }
        });
    });


    app.factory("activityService", ['$http', '$log', function ActivityService($http, $log) {
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
                return $http.get('/api/enrollment/activity/' + activity_id);
            }

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