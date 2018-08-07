app.controller("phongtailieuController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    
   
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        console.log(response.data);
        $scope.danhsachphong = response.data;
    }, function (response) {
        alert('Không tải được danh sách Phông');
    })

    

})