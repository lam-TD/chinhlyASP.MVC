﻿app.controller("importhosoController", function ($scope, $http, $rootScope) {
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

    $scope.click_phong = function (n) {
        $('.row-phong').removeClass("activePhong");
        $('#p' + n.ID).addClass("activePhong");
        $scope.disablebtn = false;
        $scope.p =
        {
            id: n.ID,
            maphong: n.MAPHONG,
            tenphong: n.TENPHONG,
            ghichu: n.GHICHU,
            sltailieuok: n.SLTLOK,
            sltailieuno: n.SLTLNO,
            sltailieu: n.SLTAILIEU,
            thoigian: n.THOIGIAN,
            lichsu: n.LICHSU,
            nhomtl: n.NHOMTL,
            bansao: n.BANSAO,
            congcu: n.CONGCU,
            ngonngu: n.NGONNGU,
            vitri: n.VITRIID,
            thoigiannhap: n.THOIGIANNHAP
        }
    }

    $scope.click_form = function (state) {
        $scope.state = state;
        if (state == "add") {
            $('#formphong').trigger("reset");
            $scope.disableinput = false;
        }
        else {
            $scope.disableinput = true;
        }
    }

    $scope.save = function () {
        if ($scope.state == "add") {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/chinhly_phong_them',
                data: { p: $scope.p }
            }).then(function (response) {
                if (response.data == 1) { alert("Thêm phông thành công"); $('#myModal').modal('hide'); $scope.loadphong(); }
                else if (response.data == 0) { alert("Mã phông đã tồn tại"); }
                else { alert("Lỗi không thêm được") }
            }, function (response) {
                alert('Lỗi không thực hiện được chức năng này');
            })
        }
        else {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/chinhly_phong_sua',
                data: { p: $scope.p }
            }).then(function (response) {
                if (response.data == 1) { alert("Cập nhật phông thành công!"); $('#myModal').modal('hide'); $scope.loadphong(); }
                else { alert("Lỗi không cập nhật được!") }
            }, function (response) {
                alert('Lỗi không thực hiện được chức năng này!');
            })
        }
    }

    $scope.delete = function () {
        if (confirm("Bạn có chắc chắn muốn xóa phông vừa chọn?")) {
            if ($scope.p.id > 0) {
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/chinhly_phong_xoa',
                    data: { phongid: $scope.p.id }
                }).then(function (response) {
                    if (response.data == 1) { alert("Đã xóa phông vừa chọn"); $scope.loadphong(); }
                    else if (response.data == 0) { alert("Phông có chứa mục lục! Vui lòng xóa mục lục!"); }
                    else { alert("Lỗi không xóa được!"); }
                }, function (response) {
                    alert('Lỗi không thực hiện được chức năng này');
                })
            }
        }
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
            var res = d.data;
            console.log(res);
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