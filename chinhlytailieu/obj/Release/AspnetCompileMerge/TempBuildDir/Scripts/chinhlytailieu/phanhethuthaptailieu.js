app.controller("phanheQLthuthapTLController", function ($scope, $http) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $http({
        method: 'GET',
        url: '/chinhlytailieu/phanhe_load_thongke'
    }).then(function (response) {
        //console.log(response.data);
        $scope.thongke = response.data;
    }, function (response) {
        alert('Không tải được danh sách Phông');
    })
})



