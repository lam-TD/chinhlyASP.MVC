var app = angular.module("apphethong", ['ngRoute', 'angularUtils.directives.dirPagination']);

app.config(function ($routeProvider) {
    $routeProvider
        //quanlynguoidung
    .when('/', {
        templateUrl: '../quanlyphongban',
        //controller: ''
    })
    .when('/quanlychucvu', {
        templateUrl: '../quanlychucvu',
        controller: 'qlchucvuController'
    })
    .when('/quanlynguoidung', {
        templateUrl: '../quanlynguoidung',
        //controller: 'qlnguoidungController'
    })
    .when('/quanlynhom', {
        templateUrl: '../quanlynhom',
        //controller: 'timkiemhoso'
    })

    //phanquyen
    .when('/phanquyentruycaptailieu', {
        templateUrl: '../phanquyentruycaptailieu',
        //controller: 'timkiemhoso'
    })
    .when('/phanquyenchucnang', {
        templateUrl: '../phanquyenchucnang',
        //controller: 'timkiemhoso'
    })

    //thietlapquytrinh
    .when('/quanlyquytrinh', {
        templateUrl: '../quanlyquytrinh',
        //controller: 'timkiemhoso'
    })
    .when('/quanlyloaihinhkhaithac', {
        templateUrl: '../quanlyloaihinhkhaithac',
        //controller: 'timkiemhoso'
    })
    .when('/phanquyenxulyquytrinh', {
        templateUrl: '../phanquyenxulyquytrinh',
        //controller: 'timkiemhoso'
    })
    
    //cauhinhhethong
    .when('/cauhinhdangnhap', {
        templateUrl: '../cauhinhdangnhap',
        //controller: 'timkiemhoso'
    })
    .when('/cauhinhkhac', {
        templateUrl: 'cauhinhkhac',
        //controller: 'timkiemhoso'
    })
    .when('/cauhinhvitriluutru', {
        templateUrl: '../cauhinhvitriluutru',
        //controller: 'timkiemhoso'
    })
    .when('/backupcosodulieu', {
        templateUrl: '../backupcosodulieu',
        //controller: 'timkiemhoso'
    })

    //nhatky
    .when('/nhatkyhethong', {
        templateUrl: '../nhatkyhethong',
        //controller: 'timkiemhoso'
    })
    .when('/nhatkythaydoitailieu', {
        templateUrl: '../nhatkythaydoitailieu',
        //controller: 'timkiemhoso'
    })
    .when('/nhatkydocgia', {
        templateUrl: '../nhatkydocgia',
        //controller: 'timkiemhoso'
    })
    .otherwise({
        redirectTo: '/'
    })
})

app.filter('starForm', function () {
    return function (data, start) {
        return data.slice(start);
    }
})

//app.controller("qlnguoidungController", function ($scope, $http) {

//})