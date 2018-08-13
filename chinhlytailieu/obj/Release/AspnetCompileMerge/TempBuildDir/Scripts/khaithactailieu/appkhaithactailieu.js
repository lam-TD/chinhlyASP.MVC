var app = angular.module("appkhaithactailieu", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../timkiemhoso',
        controller: 'timkiemhoso'
    })
    .when('/timkiemvanban', {
        templateUrl: '../timkiemvanban',
        controller: 'timkiemhoso'
    })
    .when('/timkiemhosonangcao', {
        templateUrl: '../timkiemhosonangcao',
        controller: 'timkiemhoso'
    })
    .when('/timkiemvanbannangcao', {
        templateUrl: '../timkiemvanbannangcao',
        controller: 'timkiemhoso'
    })
    .when('/taoyeucaukhaithac', {
        templateUrl: '../taoyeucaukhaithac',
        controller: 'timkiemhoso'
    })
    .when('/quanlyyeucau', {
        templateUrl: '../quanlyyeucau',
        controller: 'timkiemhoso'
    })
    .when('/tailieuduocxem', {
        templateUrl: '../tailieuduocxemtructuyen',
        controller: 'timkiemhoso'
    })
    .when('/lichsutimkiem', {
        templateUrl: '../lichsutimkiem',
        controller: 'timkiemhoso'
    })
    .otherwise({
        redirectTo: '/'
    })
})