app.controller("qlnguoidungController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý nhóm người dùng";

    $scope.btnSua = true;
    $scope.btnThem = true;

    $scope.hiddenText = true;
    
    $scope.flag = false; //người dùng thêm sai giữ lịa thông tin các trường

    // load co quan
    $http({
        method: 'GET',
        url: '/hethong/users_coquan_load'
    }).then(function success(respone) {
        $scope.coquanList = respone.data;
        $scope.selectCoQuan = $scope.coquanList[0];
        $scope.hasChanged();
    }, function error(response) {
        alert("Không tải được danh sách cơ quan");
    });

    // hien thi phong khi chon co quan
    $scope.hasChanged = function () {
        var idcoquanlam = $scope.selectCoQuan.MACOQUAN;
        $http({
            method: 'POST',
            url: '/hethong/coquanLam',
            data: {id: idcoquanlam}
        }).then(function success(respone) {
            $scope.coquanLam = respone.data;
            $http({
                method: 'GET',
                url: '/hethong/DanhSachChucVu'
            }).then(function (response) {
                $scope.chucvu2 = response.data;
            }, function (reponse) {
                console.log("Lỗi");
            })
        });
    }


    //chon phong hien thi danh sach nguoi dung
    $scope.checkPhong = function (u) {
        var t = document.getElementsByClassName('clickPhong');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');

            }
        }
        $http({
            method: 'POST',
            url: '/hethong/LoadNguoiDungTheoBoPhan',
            data: { id: u.MAPHONG }
        }).then(function success(respone) {
            $scope.userList = respone.data; //load table nguoi dung
            $scope.btnThem = false; // hien thi btnThem
        });
    }


    $scope.kichhoat = function () {
        //check tai khoan co duoc kich hoat hay chua
        var title = null;
        var data = null;
        var notication = null;
        if ($scope.nd.khoa == true && $scope.nd.username != null) {
            title = 'Bạn có chắc chắn muốn kích hoạt tài khoản: ' + $scope.nd.username;
            data = { username: $scope.nd.username, khoa: 0 };
            notication = 'Kích hoạt tài khoản thành công tài khoản: ' + $scope.nd.username;
        }
        else {
            title = 'Bạn có chắc chắn muốn khóa tài khoản: ' + $scope.nd.username;
            data = { username: $scope.nd.username, khoa: 1 };
            notication = 'Đã khóa tài khoản: ' + $scope.nd.username;
        }

        var confim = confirm(title);
        if (confim) {
            $http({
                method: 'POST',
                url: '/hethong/ht_quanlynguoidung_Khoa',
                data: data
            }).then(function (response) {
                if (response.data == 1) {
                    alert(notication);
                } else { alert('Lỗi không thục hiện được'); }

            }, function () {
                alert('Lỗi không sử lý được');
            })
        }

    };


    //them sua
    $scope.modal = function (state) {
        $scope.state = state;
        if (state == "add") {
            if (!$scope.flag) { $scope.nd = null; }
            $scope.hiddenText = true;
        }
        else { $scope.hiddenText = false; }
    }

    // check username
    function checkusername(username){
        $http({
            method: 'POST',
            url: '/hethong/checkUsername',
            data: { username }
            }).then(function success(response) {
                //console.log(response.data);
                if (parseInt(response.data) == 1) {
                    return true;
                }
                else {
                    return false;
                }
            }, function (response) {
                alert("Loi cmnr");
            })
    }

    // insert - update  
    $scope.save = function (state) {
        var path = null;
        var type = null;
        var status = null;
        $scope.checkuser = true;
        var username = $scope.nd.username;
        if ($scope.nd.chucvu == null || $scope.nd.bophan == null) {
            alert("Phòng hoặc chức vụ chưa được chọn!");
            $scope.flag = true;
        }
        else {
            if (state == "add") {
                $http({
                    method: 'POST',
                    url: '/hethong/checkUsername',
                    data: { username }
                    }).then(function success(response) {
                        if (parseInt(response.data) == 1) {
                            alert("Tên đăng nhập đã tồn tại");
                            $scope.flag = true;
                        }
                        else {
                            var mk = $scope.nd.password;
                            var xn = $scope.nd.xacnhanmk;
                            if (mk == xn) {
                                 path = "../themsuanguoidung/"; type = 1; status = "Thêm thành công!";
 
                                if (path != null) {
                                    $http({
                                        method: 'POST',
                                        url: path,
                                        data: { type: type, n: $scope.nd }
                                    }).then(function success(response) {
                                        if (response.data == "1") {
                                            alert(status);
                                            $scope.flag = false;
                                            
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
                            else {
                                alert("Mật khẩu không trùng khớp");
                            }
                        }
                    }, function (response) {
                        alert("Đã xuất hiện lỗi");
                    })
            }
            else if(state == "edit") {
                varIsConf = confirm('Bạn có chắc chắn muốn cập nhật lại thông tin người dùng vừa chọn?');
                if (varIsConf) {
                    path = "../themsuanguoidung"; type = 2; status = "Cập nhật thành công";
                    if (path != null) {
                        $http({
                            method: 'POST',
                            url: path,
                            data: { type: type, n: $scope.nd }
                        }).then(function success(response) {
                            if (response.data == "1") {
                                alert(status);
                                $scope.nd = null;
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
            }
        }
    }
   
    $scope.clickDanhSach = function (u) {
        var t = document.getElementsByClassName('clickdanhsachTK');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');

            }
        }
        $scope.btnSua = false;
        var nd = {
            chucvu: u.CHUCVU,
            bophan: u.BOPHAN,
            username: u.USERNAME,
            holot: u.HOLOT,
            ten: u.TEN,
            email: u.EMAIL,
            hanche: u.HANCHE,
            password: '     ',
            xacnhanmk: '     ',
            khoa: u.KHOA
        }
        $scope.nd = nd;
        var dmk = {
            username: u.USERNAME,
            holot: u.HOLOT,
            ten: u.TEN
        }
        $scope.dmk = dmk;
    }

    // doi mat khau
    $scope.doi_matkhau = function () {
        var pass = $scope.dmk.password;
        var xacnhanpass = $scope.dmk.xacnhanmk;
        var username = $scope.dmk.username;
        if (pass == xacnhanpass) {
            var confi = confirm('Bạn có chắc chắn muốn đổi mật khẩu?');
            if (confi) {
                $http({
                    method: 'POST',
                    url: '/hethong/ht_quanlynguoidung_DoiMK',
                    data: { username: username, pass}
                }).then(function (response) {
                    if (response.data == 1) {
                        alert('Cập nhật mật khẩu thành công');
                    }
                    else { alert('Lỗi không cập nhật được mật khẩu'); }
                })
            }
        }
        else {
            alert("Mật khẩu không trùng khớp");
        }
    }
})