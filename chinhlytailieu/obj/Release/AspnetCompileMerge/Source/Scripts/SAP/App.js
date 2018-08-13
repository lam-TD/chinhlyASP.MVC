var app = angular.module("myApp", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'phanheQLthuthaptailieu',
        controller: 'homeController'
    })
    .when('/lapmucnopluu', {
        templateUrl: 'lapmucnopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/qllannopluu', {
        templateUrl: 'qllannopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/xuatmucnopluu', {
        templateUrl: 'xuatmucnopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/nopluutructuyen', {
        templateUrl: 'nopluutructuyen',
        controller: 'thuthaptailieuController'
    })
})

app.controller('homeController', function ($scope) {
    $scope.title = "Home";
})

app.controller('thuthaptailieuController', function ($scope) {

})