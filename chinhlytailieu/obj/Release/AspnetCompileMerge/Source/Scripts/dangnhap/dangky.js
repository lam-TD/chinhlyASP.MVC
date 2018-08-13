var app = angular.module("appdangky", []);

app.controller("dangky", function ($scope) {
    $scope.dongy = false;
    $scope.dacheck = function () {
        if ($scope.dongy) {
            return true;
        }
        return false;
    }

    $scope.guiyeucau = function () {
        console.log($scope.dongy.checked);
    }
})