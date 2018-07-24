app.controller("phanquyenController", function ($scope, $http) {
    $scope.nhomchucnang = "Phân quyền";
    $scope.chucnang = "Phân quyền truy cập tài liệu";

    $scope.disableCoQuan = true;
    $scope.currentPage = 1;
    $scope.showBtnSua = true;

    
    // load nhom nguoi dung
    $http({
        method: 'GET',
        url: '/hethong/ht_qlnhomnguoidung_Load'
    }).then(function (response) {
        //console.log(response.data);
        $scope.nhomnguoidung = response.data;
    }, function (reponse) {
        console.log("Lỗi không load được nhóm người dùng");
    })

    //click modal xac dinh them hay sua
    $scope.modallam = function (state) {
        $scope.state = state;
        if (state == "edit") {
            $scope.checkSua = true;
        }
        else { $scope.checkSua == false; }
    }

    $scope.save = function (state) {
        var path = null;
        var type = null;
        var status = null;
        if (state == "add") { path = "../quanlychucvuThemSua/"; type = 1; status = "Thêm thành công!"; }
        else if (state == "edit") {
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


    // click chon nhom
    $scope.click_nhom = function (n) {
        var t = document.getElementsByClassName('clicknhom');
        for (var i = 0; i < t.length; i++) {
            t[i].onclick = function () {
                for (var i = 0; i < t.length; i++) {
                    t[i].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom')
            }
        }
        $scope.manhom = n.MANHOM; // lay ma nhom
        $scope.disableCoQuan = false;
        //
        if ($scope.maphong != null && $scope.manhom != null) {
            $scope.click_phong();
        }
    }

    // click danh sach phong
    

    // load phong khi chon co quan
    $(document).ready(function () {
        $('select[name=select_coquan]').change(function () {
            if ($scope.manhom == null) {
                alert("Vui lòng chọn nhóm người dùng");
                $scope.disableCoQuan = true;
            }
            else {
                var idcoquan = $('select[name=select_coquan]').val();
                $http({
                    method: 'POST',
                    url: '/hethong/ht_phanquyen_loadPhongTheoCoquan',
                    data: { macoquan: idcoquan }
                }).then(function (response) {
                    $scope.danhsachPhong = response.data;
                }, function (response) {
                    alert("Lỗi không tải được danh sách phông");
                })
            }
        })

        $('select[name=select_phong]').change(function () {
            $scope.maphong = $('select[name=select_phong]').val();
            if ($scope.maphong == null) {
                $scope.DSTruyCapTaiLieu = null;
            }
            else {
                $scope.click_phong();
            }
        })
    })

    // load danh sach quyen truy cap khi chon phong
    $scope.click_phong = function () {
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_loadPhong',
            data: { maphong: $scope.maphong, manhom: $scope.manhom }
        }).then(function (response) {
            var lam = response.data;
            //console.log(lam.length);
            if (lam.length == 0) {
                $http({
                    method: 'POST',
                    url: '/hethong/ht_phanquyen_loadphongnull',
                    data: { maphong: $scope.maphong }
                }).then(function (response2) {
                    $scope.DSTruyCapTaiLieu = response2.data;
                    $scope.DSTruyCapTaiLieu.XEM = false;
                    $scope.DSTruyCapTaiLieu.THEM = false;
                    $scope.DSTruyCapTaiLieu.SUA = false;
                }, function (response2) {
                    alert("Lỗi không tải được danh sách truy cập tài liệu null");
                })
            }
            else {

                $scope.DSTruyCapTaiLieu = response.data;
            }
        }, function (response) {
            alert("Lỗi không tải được danh sách truy cập tài liệu");
        })
    }


    $scope.ghinhan = function () {
        var Mamucluc = $scope.DSTruyCapTaiLieu[0].MAMUCLUC;
        console.log(Mamucluc);
        var xem = document.getElementsByClassName('truycapxem');
        var them = document.getElementsByClassName('truycapthem');
        var sua = document.getElementsByClassName('truycapsua');

        $scope.truycap = {
            MANHOM: $scope.manhom,
            PHONGID: $scope.maphong,
            MAMUCLUC: Mamucluc,
            XEM: xem[0].checked,
            THEM: them[0].checked,
            SUA: sua[0].checked
        }

        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_GhiNhan',
            data: { tc: $scope.truycap }
        }).then(function(response){
            if (response.data == "1") {
                alert("Ghi nhận thành công");
            } else { alert("Ghi nhận thất bại"); }
        })
    }

})
