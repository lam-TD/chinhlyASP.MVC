var app = angular.module("appluuthongtailieu", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheluuthongtailieu',
        controller: '../phanheController'
    })
    .when('/cungcapbansao', {
        templateUrl: '../cungcapbansao',
        controller: 'phanheController'
    })
    .when('/danhsachyeucau', {
        templateUrl: '../danhsachyeucau',
        controller: 'phanheController'
    })
    .when('/duyetyeucaudangkySDTL', {
        templateUrl: '../duyetyeucaudangkySDTL',
        controller: 'phanheController'
    })
    .when('/quanlytaikhoandocgia', {
        templateUrl: '../quanlytaikhoandocgia',
        controller: 'phanheController'
    })
    .when('/danhsachyeucau', {
        templateUrl: '../danhsachyeucau',
        controller: 'phanheController'
    })
    .when('/duyetYCcungcaptainguyen', {
        templateUrl: '../duyetYCcungcaptainguyen',
        controller: 'phanheController'
    })
    .when('/cungcapbansao', {
        templateUrl: '../cungcapbansao',
        controller: 'phanheController'
    })
    .when('/giaobansaochodocgia', {
        templateUrl: '../giaobansaochodocgia',
        controller: 'phanheController'
    })
    .when('/ghimuontailieu', {
        templateUrl: '../ghimuontailieu',
        controller: 'phanheController'
    })
    .when('/ghitratailieu', {
        templateUrl: '../ghitratailieu',
        controller: 'phanheController'
    })
    .when('/sochungthuc', {
        templateUrl: '../sochungthuc',
        controller: 'phanheController'
    })
    .when('/sodangkysaochup', {
        templateUrl: '../sodangkysaochup',
        controller: 'phanheController'
    })
    .when('/sobangiaotailieuvoidocgia', {
        templateUrl: '../sobangiaotailieuvoidocgia',
        controller: 'phanheController'
    })
    .when('/sodangkyyeucaudoc', {
        templateUrl: '../sodangkyyeucaudoc',
        controller: 'phanheController'
    })
    .when('/sodangkydocgia', {
        templateUrl: '../sodangkydocgia',
        controller: 'phanheController'
    })
    .otherwise({
        redirectTo: '/'
    })
})