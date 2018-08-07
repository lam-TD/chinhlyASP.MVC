app.controller("importvanbanController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.disablebtn = true;
    $scope.disableinput = true;

    $scope.loadphong = function () {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loadphong'
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachphong = response.data;
        }, function (response) {
            alert('Không tải được danh sách Phông');
        })
    }

    $scope.SelectedFileForUpload = null; //initially make it null   

    $scope.UploadFiles = function (files) {
        $scope.$apply(function () {
            $scope.Message = '';
            $scope.SelectedFileForUpload = files[0];
            $scope.ParseExcel();
        })
    }

    $scope.SendExcelData = function (data) {
        var request = $http({
            method: "post",
            withCredentials: true,
            url: '/chinhlytailieu/read_excel',
            data: data,
            headers: {
                'Content-Type': undefined
            },
            transformRequest: angular.identity
        });
        return request;
    }

    $scope.ParseExcel = function () {
        var formData = new FormData();
        var file = $scope.SelectedFileForUpload;
        formData.append('file', file);
        $scope.showLoader = true;   //show spinner  
        var response = $scope.SendExcelData(formData);   //calling service  
        response.then(function (d) {
            //$scope.danhsachvanban = JSON.parse(d.data);
            $scope.danhsachvanban = (d.data);
            console.log(d.data);
            //$scope.BindData = res;
            //$scope.IsVisible = true; //showing the table after databinding  
            //$scope.showLoader = false; //after success hide spinner  
        }, function (err) {
            console.log(err.data);
            console.log("error in parse excel");
        });
    }

    $(document).ready(function () {
        $scope.loadphong();
    })

});

//app.service("Excelservice", function ($http) {  
////    this.SendExcelData = function (data) {  
////        var request = $http({  
////            method: "post",  
////            withCredentials: true,  
////            url: '/File/ReadExcel',  
////            data: data,  
////            headers: {  
////                'Content-Type': undefined  
////            },  
////            transformRequest: angular.identity  
////        });  
////        return request;  
////    }  
//}