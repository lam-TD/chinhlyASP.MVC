app.controller("qlnhomnguoidungController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý chức vụ";

    $scope.btnSua = true; //disable btnsua
    $scope.disabletxtSua = false; //disable txtmanhom
    $scope.flag = false; // luu noi dung text khi khong thu hien duoc chuc nang
    $scope.disablebtnthemtaikhoan = true;
    $scope.disablebtnloaibotaikhoan = true;

    // load danh sach nhom nguoi dung
    $http.get('/hethong/ht_qlnhomnguoidung_Load').then(function (response) {
        $scope.nhomnguoidungLoad = response.data;
    }, function (response) {
        alert('Lỗi không tải được danh sách nhóm');
    })

    $scope.DSnhomnguoidung = function () {
        $http.get('/hethong/ht_qlnhomnguoidung_Load').then(function (response) {
            $scope.nhomnguoidungLoad = response.data;
        }, function (response) {
            alert('Lỗi không tải được danh sách nhóm');
        })
    }





    // load danh sach tai khoan trong nhom khi click chon nhom nguoi dung
    $scope.clickNhom = function (u) {
        var manhom = u.MANHOM;
        $scope.manhomStatic = u.MANHOM;
        $scope.loadNhomnguoidung(manhom); //load danh sach nhom nguoi dung theo ma nhom
        var nhom_info = { manhom: u.MANHOM, tennhom: u.TENNHOM }
        $scope.nhom = nhom_info;
        $scope.btnSua = false;
        $scope.disablebtnthemtaikhoan = false; // kich hoat btn them tai khoan vao nhom
        var t = document.getElementsByClassName('click_nhom');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');
                
            }
        }
    }

    $scope.loadNhomnguoidung = function (manhom) {
        $http({
            method: 'POSt',
            url: '/hethong/ht_qlnhomnguoidung_LoadDSTaikhoan',
            data: { manhom: manhom}
        }).then(function (response) {
            $scope.taikhoan = response.data;
        })
    }

    // modal
    $scope.modal = function (state) {
        $scope.state = state;
        if (state == 'add') {
            if (!$scope.flag) { $scope.nhom = null; $scope.btnSua = true; }
            $scope.disabletxtSua = false;
        }
        else
        {
            $scope.disabletxtSua = true;
        }
    }

    // check ma nhom co ton tai hay khong
    $scope.check_manhom = 1;
    $scope.checkMaNhom = function(){
        $http({
            method: 'POST',
            url: '/hethong/ht_qlnhomnguoidung_CheckMaNhom',
            data: { manhom: $scope.nhom.manhom}
        }).then(function(response){
            if (response.data == 1) { $scope.check_manhom = 1; }
            else { $scope.check_manhom = -1; }
        }, function (resopnse) {
            alert("Lỗi không kiểm tra được mã nhóm");
        })
    }

    // them - capnhat
    $scope.save = function (state) {
        var nhom = $scope.nhom;
        if (state == 'add')
        {
            $http({
                method: 'POST',
                url: '/hethong/ht_qlnhomnguoidung_CheckMaNhom',
                data: { manhom: $scope.nhom.manhom }
            }).then(function (response) {
                if (response.data == -1)
                {
                    var ma_nhom = $scope.nhom.manhom.trim();
                    var vitri = ma_nhom.search(" ");
                    if (vitri == -1)
                    {
                        $http({
                            method: 'POST',
                            url: '/hethong/ht_qlnhomnguoidung_ThemSua',
                            data: { type: 1, n: nhom }
                        }).then(function (response) {
                            if (response.data == 1) {
                                alert("Thêm thành công");
                                $scope.flag = false;
                                $scope.DSnhomnguoidung();
                            }
                            else { alert("Lỗi không thêm được"); $scope.flag = false; }
                        }, function (resopnse) {
                            alert("Lỗi không thực hiện được chức năng");
                            $scope.flag = false;
                        })
                    }
                    else
                    {
                        alert('Mã nhóm không được có khoảng trắng');
                        $scope.flag = true;
                    }
                }
                else { alert('Mã nhóm đã tồn tại'); }
            }, function (resopnse) {
                alert("Lỗi không kiểm tra được mã nhóm");
            })      
        }
        else if (state == 'edit')
        {
            var conf = confirm('Bạn có chắc chắn muốn cập nhật nhóm: ' + nhom.manhom);
            if (conf) {
                $http({
                    method: 'POST',
                    url: '/hethong/ht_qlnhomnguoidung_ThemSua',
                    data: { type: 2, n: $scope.nhom }
                }).then(function (response) {
                    if (response.data == 1) {
                        alert("Cập nhật thành công");
                        $scope.DSnhomnguoidung();
                    }
                    else {
                        alert("Lỗi không cập nhật được");
                    }
                }, function (resopnse) {
                    alert("Lỗi không thực hiện được chức năng");
                })
            }
        }
    }
    
    //====== DANH SACH TAI KHOAN TRONG NHOM ======
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
            data: { id: idcoquanlam }
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
        $http({
            method: 'POST',
            url: '/hethong/LoadNguoiDungTheoBoPhan',
            data: { id: u.MAPHONG }
        }).then(function success(respone) {
            $scope.userList = respone.data; //load table nguoi dung
            $scope.btnThem = false; // hien thi btnThem
            active_clickbophan(); // to mau cho bo phan duoc chon

            checknguoidngdathuocnhom();

        });
    }

    $scope.loaddanhsachnguoidungdathuocnhom = function () {

    }

    // them nguoi dung vao nhom
    $scope.themnguoidungvaonhom = function () {
        var manhom = $scope.nhom.manhom;
        console.log(manhom);
        var DanhSachTKDuocChon = [];
        var DanhSachTaiKhoan = document.getElementsByClassName('check_vaonhom');
        // lay danh sach nguoi dung da duoc chon
        for (var i = 0; i < DanhSachTaiKhoan.length; i++) {
            if (DanhSachTaiKhoan[i].checked) {
                DanhSachTKDuocChon.push(DanhSachTaiKhoan[i].value);
            }
        }
        
        //them nguoi dung 
        $http({
            method: 'POST',
            url: '/hethong/ht_qlnhomnguoidung_themnguoidungvaonhom',
            data: { username: DanhSachTKDuocChon, manhom: manhom }
        }).then(function (response) {
            console.log(response.data);
            alert('Đã thêm tài khoản vào nhóm');
            checknguoidngdathuocnhom();
        })
       
    }

    //check nguoi dung da thuoc nhom
    function checknguoidngdathuocnhom() {
       
        var DSTKDaThuocnhom; // danh sach tai khoan da thuoc nhom
        $http({
            method: 'POST',
            url: '/hethong/ht_qlnhomnguoidung_LoadDSTaikhoan',
            data: { manhom: $scope.manhomStatic }
        }).then(function (response) {
            DSTKDaThuocnhom = response.data;

            var DanhSachTaiKhoan = document.getElementsByClassName('check_vaonhom');
            
            for (var i = 0; i < DSTKDaThuocnhom.length; i++) {
                
                for (var j = 0; j < DanhSachTaiKhoan.length; j++) {
                    if (DSTKDaThuocnhom[i].USERNAME == DanhSachTaiKhoan[j].value)
                    {
                        DanhSachTaiKhoan[j].checked = true;
                        DanhSachTaiKhoan[j].disabled = true;
                    }
                }
            }
        })
        
    }

    // click chon tai khoan trong danh sach tai khoan trong nhom
    $scope.clickDSTKtrongnhom = function (t) {
        var tk = document.getElementsByClassName('itemTK');
        
        for (var i = 0; i < tk.length; i++) {
            tk[i].onclick = function () {
                for (var j = 0; j < tk.length; j++) {
                    tk[j].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');
            }
        }
        $scope.usernameKhichonTK = t.USERNAME;
        $scope.disablebtnloaibotaikhoan = false;
    }

    //loai bo tai khoan
    $scope.loaibo = function () {
        var conf = confirm('Bạn có chắc chắn muốn loại bỏ tài khoản này ra khỏi nhóm?');
        if (conf) {
            var username = $scope.usernameKhichonTK;
           
            $http({
                method: 'POST',
                url: '/hethong/ht_qlnhomnguoidung_Loaibo',
                data: {username: username}
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Đã loại bỏ tài khoản: ' + username);
                }
                else {
                    alert('Lỗi không thực hiện được');
                }
                $scope.disablebtnloaibotaikhoan = true;
            })
        }
    }

    // active
    function active_clickbophan() {
        var t = document.getElementsByClassName('click_bophan');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');

            }
        }
    }
})