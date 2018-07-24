app.controller("lapkehoachchinhlyController", function ($scope, $http) {
    $scope.tieude = "Lập kế hoạch chỉnh lý";
    //console.log('hhh');
    $http({
        method: 'GET',
        url: '/chinhlytailieu/lapkehoachchinhly_load'
    }).then(function (response) {
        console.log(response.data);
        $scope.DSkehoach = response.data;
        //console.log($scope.DSkehoach);
    }, function (response) {
        console.log(response);
    })

    //$http({
    //    method: 'GET',
    //    url: '/chinhlytailieu/loadcoquan'
    //}).then(function (response) {
    //    console.log(response.data);
    //    var lam
    //    $('#select_coquan').html = response.data;
    //}, function (response) {
    //    console.log(response);
    //})


    // BIEN MUC - nhap muc luc chinh ly
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loaddanhsach'
    }).then(function (response) {
        console.log(response.data);
    }, function (response) {
        console.log(response);
    })
})
