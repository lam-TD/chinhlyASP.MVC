var app = angular.module("appdanhmuc", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../coquanluutru'
    })
    .when('/phongtailieu', {
        templateUrl: '../phongtailieu'
    })
    .when('/loaihinhtailieu', {
        templateUrl: '../loaihinhtailieu'
    })
    .when('/thoihanbaoquan', {
        templateUrl: '../thoihanbaoquan'
    })
    .when('/tudien', {
        templateUrl: '../tudien'
    })
    .otherwise({
        redirectTo: '/'
    })
})