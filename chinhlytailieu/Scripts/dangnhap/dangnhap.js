app.controller("dangnhapcontroller", function ($scope, $http, $window) {
    
    $scope.login = function () {
        $http({
            method: "POST",
            url: "/dangnhap/dangnhap",
            data: { u: $scope.user}
        }).then(function (response) {
            if (response.data == "1") {
                $http({
                    method: 'GET',
                    url: '/home/user_module_list'
                })
                .then(function success(response) {
                    $scope.module = response.data;
                    $window.open('/chinhlytailieu/index/2', "_self");
                    //console.log(response.data);
                }, function erro(response) {
                    alert('Tài khoản hoặc mật khẩu không đúng');
                })
                //$window.open('/home/Home', "_self");
            }
            else {
                alert("Tài khoản hoặc mật khẩu không đúng");
            }
        }, function () {
            alert("Lỗi không truy cập được!");
        })
    }
})