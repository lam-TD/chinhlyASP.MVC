app.controller("dangnhapcontroller", function ($scope, $http, $window) {
    
    $scope.login = function () {
        $http({
            method: "POST",
            url: "/dangnhap/dangnhap",
            data: $scope.user
        }).then(function (response) {
            if (response.data == "1") {
                $window.open('/home/Home', "_self");
            }
            else {
                alert("Tài khoản hoặc mật khẩu không đúng");
            }
        })
    }
})