var app = angular.module("chinhly", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '/dangnhap/login',
        controller: 'dangnhapcontroller'
    })
    .when('/home', {
        resolve:{
            "check": function ($location, $rootScope) {
                if (!$rootScope.loggedIn) {
                    $location.path('/');
                }
            }
        },
        templateUrl: '/dangnhap/login',
        controller: 'homecontroller'
    })
    .otherwise({
        redirectTo: '/'
    });
})