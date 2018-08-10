var app = angular.module("appchinhlytailieu", ['ngRoute', 'angularUtils.directives.dirPagination', 'ui.bootstrap']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheQLthuthapTL',
        controller: ''
    })
    .when('/danhsachphong', {
        templateUrl: '../danhsachphong',
        controller: ''
    })
    .when('/taomucluc', {
        templateUrl: '../taomucluc',
        controller: ''
    })
    .when('/nhaphoso', {
        templateUrl: '../nhaphoso',
        controller: 'nhaphosoController'
    })
    .when('/nhaphoso/them', {
        templateUrl: '../nhaphosothem',
        controller: ''
    })
    .when('/nhaphoso/sua', {
        templateUrl: '../nhaphosothem',
        controller: ''
    })
    .when('/nhapvanban', {
        templateUrl: '../nhapvanban',
        controller: ''
    })
    .when('/importhoso', {
        templateUrl: '../importhoso',
        controller: ''
    })
    .when('/importvanban', {
        templateUrl: '../importvanban',
        controller: ''
    })
    .when('/taohop', {
        templateUrl: '../taohop',
        controller: ''
    })
    .when('/xephosovaohop', {
        templateUrl: '../xephosovaohop',
        controller: ''
    })
    .when('/kiemtrahosochinhly', {
        templateUrl: '../kiemtrahosochinhly',
        controller: ''
    })
    .when('/giaotailieuvaokho', {
        templateUrl: '../giaotailieuvaokho',
        controller: ''
    })
    .when('/timkiemhoso', {
        templateUrl: '../timkiemhoso',
        controller: ''
    })
    .when('/timkiemvanban', {
        templateUrl: '../timkiemvanban',
        controller: ''
    })
    .when('/timkiemhosonangcao', {
        templateUrl: '../timkiemhosonangcao',
        controller: ''
    })
    .when('/timkiemvanbannangcao', {
        templateUrl: '../timkiemvanbannangcao',
        controller: ''
    })
    .when('/taoyeucaukhaithac', {
        templateUrl: '../timkiemvanbannangcao',
        controller: ''
    })
})