app.controller("qlchucvuController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý chức vụ";

    $scope.pageSize = 5;
    $scope.currentPage = 1;
    $scope.showBtnSua = true;

    $http({
        method: 'GET',
        url: '/hethong/DanhSachChucVu'
    }).then(function (response) {
        //console.log(response.data);
        $scope.chucvu = response.data;
    }, function (reponse) {
        console.log("Loi cmnr");
    })

    //click modal xac dinh them hay sua
    $scope.modallam = function (state) {
        $scope.state = state;
        if (state == "edit") {
            $scope.checkSua = true;
        }
        else {
            $scope.cv = {
                Machucvu: "",
                Tenchucvu: ""
            }
            $scope.checkSua == false;
        }
    }

    $scope.save = function (state) {
        var path = null;
        var type = null;
        var status = null;
        if (state == "add") { path = "../quanlychucvuThemSua/"; type = 1; status = "Thêm thành công!"; }
        else if (state == "edit")
        {
            varIsConf = confirm('Bạn có chắc chắn muốn cập nhật lại thông tin của chức vụ có mã là: ' + $scope.cv.Machucvu + '?');
            if (varIsConf) {
                path = "../quanlychucvuThemSua"; type = 2; status = "Cập nhật thành công";
            }
        }
        //console.log(state);
        if (path != null) {
            $http({
                method: 'POST',
                url: path,
                data: { type: type, cv: $scope.cv }
            }).then(function success(response) {
                if (response.data == "1") {
                    alert(status);
                    $http({
                        method: 'GET',
                        url: '/hethong/DanhSachChucVu'
                    }).then(function (response) {
                        $scope.chucvu = response.data;
                    }, function (reponse) {
                        console.log("Lỗi không tải được danh sách chức vụ");
                    })
                }
                else {
                    console.log("Lỗi không thực hiện được chức năng");
                }
            })
        }
    }


    // click chon chuc vu
    $scope.clickChucVu = function (c) {
        $('.clicktaikhoan').removeClass("activePhong");
        $('#cv' + c.MACHUCVU).addClass("activePhong");
        $scope.machucvuCha = c.MACHUCVU;
        $scope.showBtnSua = false;
        //console.log(c);
        $scope.cv = {
            Machucvu: c.MACHUCVU,
            Tenchucvu: c.TENCHUCVU
        }
    }


    $scope.xoa = function () {
        if ($scope.machucvuCha.length > 0) {
            if (confirm("Bạn có chắc chắn muốn xóa chức vụ vừa chọn")) {
                $http({
                    method: 'POST',
                    url: '/hethong/quanlychucvuXoa',
                    data: { machucvu: $scope.machucvuCha }
                }).then(function (response) {
                    if (response.data == 1) {
                        alert("Đã xóa chức vụ vừa chọn");
                        $http({
                            method: 'GET',
                            url: '/hethong/DanhSachChucVu'
                        }).then(function (response) {
                            $scope.chucvu = response.data;
                        }, function (reponse) {
                            console.log("Loi cmnr");
                        })
                    }
                    else if(response.data == 0){
                        alert("Vẫn còn tài khoản giữ chức vụ này, vui lòng xóa tài khoản khỏi chức vụ này");
                    }
                    else { alert("Lỗi không xóa được chức vụ vừa chọn"); }
                }, function (reponse) {
                    alert("Lỗi không thực hiện được chức năng này");
                })
            }
        }
        else {
            alert("Bạn chưa chọn chức vụ");
        }
        
    }
})
