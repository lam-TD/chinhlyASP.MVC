﻿app.controller("importvanbanController", function ($scope, $http, $rootScope) {
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

    $scope.loadmucluc = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + $('select[name=selectphong]').val(),
            data: { phongid: $('select[name=selectphong]').val() }
        }).then(function (response) {
            $scope.danhsachmucluc = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
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
            url: '/chinhlytailieu/read_excel?type=1',
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
        formData.append('type', "1");
        $scope.showLoader = true;   //show spinner  
        var response = $scope.SendExcelData(formData);   //calling service  
        response.then(function (d) {
            //$scope.danhsachvanban = JSON.parse(d.data);
            $scope.danhsachvanban = (d.data);
            //console.log(d.data);
            $scope.disablebtn = false;
        }, function (err) {
            alert("Lỗi không tải được danh sách văn bản");
        });
    }

    $scope.insertData = function () {
        if ($('select[name=selectphong]').val() == null || $('select[name=selectmucluc]').val() == "") { alert("Vui lòng chọn phông tài liệu"); return -1; }
        if ($('select[name=selectmucluc]').val() == null || $('select[name=selectmucluc]').val() == "") { alert("Vui lòng chọn mục lục"); return -1; }
        $scope.phongid = $('select[name=selectphong]').val();
        $scope.mamucluc = $('select[name=selectmucluc]').val();
        $http({
            method: 'GET',
            url: '/chinhlytailieu/insert_excel_data?phongid=' + $scope.phongid + '&mamucluc=' + $scope.mamucluc
        }).then(function (response) {
            console.log(response.data);
            alert('Import thành công ' + response.data[0] + ' trên tổng số ' + response.data[1] + ' văn bản');
        }, function (response) {
            alert('Lỗi không thực hiện được chức năng này');
        })
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