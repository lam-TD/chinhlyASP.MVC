var app = angular.module("apphome", []);

app.controller("homeController", function ($scope, $http,$window) {
    $http({
        method: 'GET',
        url: '/home/user_module_list'
    })
    .then(function success(response) {
        $scope.module = response.data;
        //console.log(response.data);
    }, function erro(response) {
        alert('Loi cmnr');
    })

})

