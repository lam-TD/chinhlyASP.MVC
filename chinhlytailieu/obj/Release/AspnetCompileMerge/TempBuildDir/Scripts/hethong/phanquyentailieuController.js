app.controller("phanquyenController", function ($scope, $http) {
    $scope.nhomchucnang = "Phân quyền";
    $scope.chucnang = "Phân quyền truy cập tài liệu";

    $scope.disableCoQuan = true;
    $scope.currentPage = 1;
    $scope.showBtnSua = true;

    $scope.dsquyentruycap = [];
    $scope.DSTruyCapTaiLieu = [];
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

    // load phong tai lieu
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        $scope.danhsachphong = response.data;
    }, function (response) {
        //alert('Không tải được danh sách phông');
    })

    // load danh sach truy cap muc muc theo phong
    $scope.clickPhong = function () {
        var maphong = $('select[name=select_phong]').val();
        if (maphong != "") {
            $http({
                method: 'GET',
                url: '/hethong/ht_phanquyen_loadphongnull?maphong=' + maphong
            }).then(function (response) {
                //console.log(response.data);
                $scope.DSTruyCapTaiLieu = response.data;
                
                $scope.hienthiquyen($scope.dsquyentruycap, $scope.DSTruyCapTaiLieu);
            }, function (response) {
                //alert('Không tải được danh sách mục lục');
            })
        }
    }
    // load danh sach quyen truy cap theo nhom
    $scope.truycapnhom = function (manhom) {
        $http({
            method: 'GET',
            url: '/hethong/ht_phanquyentruycap_loadquyentheonhom?manhom=' + manhom
        }).then(function (response) {
            console.log(response.data);
            $scope.dsquyentruycap = response.data;
            $scope.hienthiquyen($scope.dsquyentruycap, $scope.DSTruyCapTaiLieu);
        }, function (response) {
            alert("Lỗi không tải được danh sách truy cập tài liệu");
        })
    }

    //click modal xac dinh them hay sua
    $scope.modallam = function (state) {
        $scope.state = state;
        if (state == "edit") {
            $scope.checkSua = true;
        }
        else { $scope.checkSua == false; }
    }



    // click chon nhom
    $scope.click_nhom = function (n) {
        var t = document.getElementsByClassName('clicknhom');
        $('.clicknhom').removeClass("activePhong");
        $('#n' + n.MANHOM).addClass("activePhong");
        $scope.manhom = n.MANHOM; // lay ma nhom
        $scope.disableCoQuan = false;
        $scope.truycapnhom($scope.manhom);
    }

    // click danh sach phong
    

    // load phong khi chon co quan
    $(document).ready(function () {
        //$('select[name=select_coquan]').change(function () {
        //    if ($scope.manhom == null) {
        //        alert("Vui lòng chọn nhóm người dùng");
        //        $scope.disableCoQuan = true;
        //    }
        //    else {
        //        var idcoquan = $('select[name=select_coquan]').val();
        //        $http({
        //            method: 'POST',
        //            url: '/hethong/ht_phanquyen_loadPhongTheoCoquan',
        //            data: { macoquan: idcoquan }
        //        }).then(function (response) {
        //            $scope.danhsachPhong = response.data;
        //        }, function (response) {
        //            alert("Lỗi không tải được danh sách phông");
        //        })
        //    }
        //})

        //$('select[name=select_phong]').change(function () {
        //    $scope.maphong = $('select[name=select_phong]').val();
        //    if ($scope.maphong == null) {
        //        $scope.DSTruyCapTaiLieu = null;
        //    }
        //    else {
        //        $scope.click_phong();
        //    }
        //})
    })

    


    $scope.ghinhan = function () {
        $scope.truycap = { MANHOM: $scope.manhom, PHONGID: $('select[name=select_phong]').val() };

        var xem = document.getElementsByClassName('truycapxem');
        var them = document.getElementsByClassName('truycapthem');
        var sua = document.getElementsByClassName('truycapsua');

        var arrxem = [];
        for (var i = 0; i < xem.length; i++) {
            (xem[i].checked) ? flag = 1 : flag = 0;
            arrxem.push(flag);
        }

        var arrthem = [];
        for (var i = 0; i < them.length; i++) {
            (them[i].checked) ? flag = 1 : flag = 0;
            arrthem.push(flag);
        }

        var arrsua = [];
        for (var i = 0; i < sua.length; i++) {
            (sua[i].checked) ? flag = 1 : flag = 0;
            arrsua.push(flag);
        }

        var arrmucluc = [];
        for (var i = 0; i < $scope.DSTruyCapTaiLieu.length; i++) {
            arrmucluc[i] = $scope.DSTruyCapTaiLieu[i].MAMUCLUC
        }

        var arrtruycap = {
            xem: arrxem,
            them: arrthem,
            sua: arrsua,
            mucluc: arrmucluc
        }
        //console.log(arrtruycap);
        
        $http({
            method: 'POST',
            url: '/hethong/ht_phanquyen_GhiNhan',
            data: {
                tc  : $scope.truycap,
                xem : arrxem,
                them: arrthem,
                sua : arrsua,
                mamucluc: arrmucluc
            }
        }).then(function(response){
            if (response.data == "1") {
                alert("Ghi nhận thành công");
            } else { alert("Ghi nhận thất bại"); }
            //$scope.hienthiquyen($scope.dsquyentruycap, $scope.DSTruyCapTaiLieu);
        }, function () { alert("Lỗi không thực hiện được chức năng"); })
    }

    $scope.hienthiquyen = function (arr1, arr2) {
        //console.log(arr1);
        if (arr1.length > 0 && arr2.length > 0)
        {
            if (arr1.length == arr2.length)
            {
                for (var i = 0; i < arr2.length; i++)
                {
                    m = arr1[i].MAMUCLUC;
                    $('#x' + m).prop('checked', arr1[i].XEM);
                    $('#t' + m).prop('checked', arr1[i].THEM);;
                    $('#s' + m).prop('checked', arr1[i].SUA);
                }
            }
            else {
                // tim kiem noi suy
                for (var i = 0; i < arr1.length; i++)
                {
                    for (var j = 0; j < arr2.length; j++) {
                        if (arr1[i].MAMUCLUC == arr2[j].MAMUCLUC) {
                            //arrSeen[j].checked = arr1[i].XEM;
                            m = arr1[i].MAMUCLUC;
                            $('#x' + m).prop('checked', arr1[i].XEM);
                            $('#t' + m).prop('checked', arr1[i].THEM);
                            $('#s' + m).prop('checked', arr1[i].SUA);
                        }
                        else {
                            m = arr2[j].MAMUCLUC
                            $('#x' + m).prop('checked', false);
                            $('#t' + m).prop('checked', false);
                            $('#s' + m).prop('checked', false);
                        }
                    }
                }
            }
        }
        else if(arr1.length == 0 && arr2.length > 0)
        {
            $('input:checked').prop('checked', false);
        }
    }

})
