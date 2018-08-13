var app = angular.module("appthuthaptailieu", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheQLthuthaptailieu',
        controller: 'homeController'
    })
    .when('/lapmucnopluu', {
        templateUrl: '../lapmucnopluu',
        controller: 'lapmucnopluuController'
    })
    .when('/qllannopluu', {
        templateUrl: '../qllannopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/xuatmucnopluu', {
        templateUrl: '../xuatmucnopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/nopluutructuyen', {
        templateUrl: '../nopluutructuyen',
        controller: 'thuthaptailieuController'
    })
    .when('/nguonnopluu', {
        templateUrl: '../nguonnopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/hoidongthamdinh', {
        templateUrl: '../hoidongthamdinh',
        controller: 'thuthaptailieuController'
    })
    .when('/hosonopluu', {
        templateUrl: '../hosonopluu',
        controller: 'thuthaptailieuController'
    })
    .when('/hosonopluu/them', {
        templateUrl: '../hosoluuthem',
        controller: 'thuthaptailieuController'
    })
    .when('/thamdinhhoso', {
        templateUrl: '../thamdinhhoso',
        controller: 'thuthaptailieuController'
    })
    .when('/kiemtrahosothucte', {
        templateUrl: '../kiemtrahosothucte',
        controller: 'thuthaptailieuController'
    })
    .when('/hieuchinhsuamucluchoso', {
        templateUrl: '../hieuchinhsuamucluchoso',
        controller: '../thuthaptailieuController'
    })
    .when('/giaotailieuvaokho', {
        templateUrl: '../giaotailieuvaokho',
        controller: 'thuthaptailieuController'
    })
    .when('/bienbannhanTLtunguonnopluu', {
        templateUrl: '../bienbannhanTLtunguonnopluu',
        controller: 'thuthaptailieuController'
    })
    .otherwise({
        redirectTo: '/'
    })
})

app.controller("thuthaptailieuController", function ($scope, $http,$location) {
    //console.log($location.path());

    //$scope.lam = "lam";
    //$http({
    //    method: 'GET',
    //    url: '/home/user_nhomchucnang'
    //}).then(function (response) {
    //    $scope.nhomchucnang = response.data;
    //    console.log(response.data);
    //}, error(function (response) {
    //    alert("Loi cmnr");
    //}))

})



app.controller('homeController', function ($scope) {
    $scope.title = "Home";
})

