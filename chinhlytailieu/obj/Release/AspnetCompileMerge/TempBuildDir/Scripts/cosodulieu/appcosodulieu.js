var app = angular.module("appcosodulieu", ['ngRoute']);

app.factory('checkUrl', function () {
    function checkUrlUser(url) {
        $http({
            method: 'GET',
            url: 'home/checkUrlUser' + url
        }).then(function success(response) {
            if (response.data == "1") {
                return true;
            }
        }, function error(respone) {
            return false;
        })
    }
})


app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheQLtailieubienmuc',
        controller: 'phanheTLbienmuc'
    })
    .when('/danhsachmucluc', {
        templateUrl: '../danhsachmucluc',
        controller: 'phanheTLbienmuc'
    })
    .when('/danhsachhoso', {
        templateUrl: '../danhsachhoso',
        controller: 'phanheTLbienmuc'
    })
    .when('/themhosomoi', {
        templateUrl: '../themhosomoi',
        controller: 'phanheTLbienmuc'
    })
    .when('/danhsachhop', {
        templateUrl: '../danhsachhop',
        controller: 'phanheTLbienmuc'
    })
    .when('/xephosovaohop', {
        templateUrl: '../xephosovaohop',
        controller: 'phanheTLbienmuc'
    })
    .when('/congbohosorawebsite', {
        templateUrl: '../congbohosorawebsite',
        controller: 'phanheTLbienmuc'
    })
    .when('/danhsachvanban', {
        templateUrl: '../danhsachvanban',
        controller: 'phanheTLbienmuc'
    })
    .when('/danhsachvanbanthem', {
        templateUrl: '../danhsachvanbanthem',
        controller: 'phanheTLbienmuc'
    })
    .when('/importhoso', {
        templateUrl: '../importhoso',
        controller: 'phanheTLbienmuc'
    })
    .when('/importvanban', {
        templateUrl: '../importvanban',
        controller: 'phanheTLbienmuc'
    })
    .otherwise({
        redirectTo: '/'
    })
})

