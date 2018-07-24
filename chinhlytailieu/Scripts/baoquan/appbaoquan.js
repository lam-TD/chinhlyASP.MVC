var app = angular.module("appbaoquan", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '../phanheQLkhovabaoquan',
        controller: 'phanheQLkhovabaoquan'
    })

    //quanlykho
    .when('/quanlykho', {
        templateUrl: '../quanlykho',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/quanlyphongkho', {
        templateUrl: '../quanlyphongkho',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/quanlygiake', {
        templateUrl: '../quanlygiake',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/quanlynganke', {
        templateUrl: '../quanlynganke',
        controller: 'phanheQLkhovabaoquan'
    })

    //quanlyvitri
    .when('/xephoplenke', {
        templateUrl: '../xephoplenke',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/chuyenkhoke', {
        templateUrl: '../chuyenkhoke',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/tracuutailieu', {
        templateUrl: '../tracuutailieu',
        controller: 'phanheQLkhovabaoquan'
    })

    //quanlynhapxuat
    .when('/xuathosochinhly', {
        templateUrl: '../xuathosochinhly',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/nhanhosochinhly', {
        templateUrl: '../nhanhosochinhly',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/nhanhosothuthap', {
        templateUrl: '../nhanhosothuthap',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/xuathosochophongdoc', {
        templateUrl: '../xuathosochophongdoc',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/nhanhosotuphongdoc', {
        templateUrl: '../nhanhosotuphongdoc',
        controller: 'phanheQLkhovabaoquan'
    })

    //baocaothongke
    .when('/danhsachphong', {
        templateUrl: '../danhsachphong',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/sodangkymucluchoso', {
        templateUrl: '../sodangkymucluchoso',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/inmucluchoso', {
        templateUrl: '../inmucluchoso',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/inmuclucvanban', {
        templateUrl: '../inmuclucvanban',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/sonhaphoso', {
        templateUrl: '../sonhaphoso',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/soxuathoso', {
        templateUrl: '../soxuathoso',
        controller: 'phanheQLkhovabaoquan'
    })
    //quanlytailieu
    .when('/hoidongthamdinh', {
        templateUrl: '../hoidongthamdinh',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/lapphieutieuhuy', {
        templateUrl: '../lapphieutieuhuy',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/lapphieutieuhuy/them', {
        templateUrl: '../lapphieutieuhuythem',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/lapphieutieuhuy/xem', {
        templateUrl: '../lapphieutieuhuyxem',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/pheduyettieuhuy', {
        templateUrl: '../pheduyettieuhuy',
        controller: 'phanheQLkhovabaoquan'
    })
    .when('/pheduyettieuhuyxem', {
        templateUrl: '../pheduyettieuhuyxem',
        controller: 'phanheQLkhovabaoquan'
    })
    .otherwise({
        redirectTo: '/'
    })
})