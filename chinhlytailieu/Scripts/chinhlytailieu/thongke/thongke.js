app.controller("thongkeController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.disablebtn = true;
    $scope.disableinput = true;

    $scope.tieuchi = "Chọn tiêu chí muốn thống kê";
    $scope.loading_tk_phong = false;


    $scope.tk_ml_phong = 0;
    $scope.tk_hs_phong = 0;
    $scope.tk_vb_phong = 0;
    $scope.tk_hop_phong = 0;

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
        $scope.tieuchi = "Thống kê theo phông tài liệu: " + $('#selectphong option:selected').text();
        $scope.loading_tk_phong = true;
        if ($('select[name=selectphong]').val() == "") {
            $scope.thong_ke_tat_ca();
        } else {
            $scope.thong_ke_theo_phong();
        }
        $http({
            method: 'POST',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + $('select[name=selectphong]').val(),
            data: { phongid: $('select[name=selectphong]').val() }
        }).then(function (response) {
            $scope.loading_tk_phong = false;
            $scope.danhsachmucluc = response.data;
        }, function (response) {
            $scope.loading_tk_phong = false;
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.loadhop = function () {
        $scope.thong_ke_theo_muc_luc();
        $http({
            method: 'GET',
            url: '/chinhlytailieu/hoso_loadHop?muclucid=' + $('select[name=selectmucluc]').val()
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhop = response.data;
        }, function (response) {
        })
    }

    $scope.hoso_loadtheoMucLuc = function () {
        $http({
            method: 'GET',
            url: '/thongke/hoso_loadtheoMucLuc?muclucid=' + $('select[name=selectmucluc]').val()
        }).then(function (response) {
            $scope.danhsachhoso = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.select_hop = function (h) {
        console.log(h);
        $scope.result_text = h.MAHOP;
        $('#body-select-hop').removeClass('hien');
    }

    $scope.click_text_select = function () {
        $('#body-select-hop').addClass('hien');
        //$('.search-text').focus();
    }


    // Thong Ke
    $scope.thong_ke_tat_ca = function () {
        $http({
            method: 'GET',
            url: '/thongke/phanhe_load_thongke'
        }).then(function (response) {
            //console.log(response.data);
            $scope.thongke = response.data;
            $scope.tk_ml_phong = response.data[2];
            $scope.tk_hs_phong = response.data[0];
            $scope.tk_vb_phong = response.data[1];
            $scope.tk_hop_phong = response.data[3];
        }, function (response) {
            alert('Không tải được danh sách Phông');
        })
    }

    $scope.thong_ke_theo_phong = function () {
        $http({
            method: 'GET',
            url: '/thongke/thong_ke_all_theo_phong?phongid=' + $('select[name=selectphong]').val()
        }).then(function (response) {
            $scope.tk_ml_phong = response.data[0];
            $scope.tk_hs_phong = response.data[1];
            $scope.tk_vb_phong = response.data[2];
            $scope.tk_hop_phong = response.data[3];
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.thong_ke_theo_muc_luc = function () {
        var muclucid = $('select[name=selectmucluc]').val();
        if (muclucid == "" || muclucid < 0) return 1;
        $http({
            method: 'GET',
            url: '/thongke/thong_ke_all_theo_phong_muc_luc?phongid=' + $('select[name=selectphong]').val() + '&muclucid=' + muclucid
        }).then(function (response) {
            $scope.tk_hop_phong = response.data[0];
            $scope.tk_hs_phong = response.data[1];
            $scope.tk_vb_phong = response.data[2];
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.thong_ke_theo_hop = function () {
        var muclucid = $('select[name=selectmucluc]').val();
        if (muclucid == "" || muclucid < 0) return 1;
        $http({
            method: 'GET',
            url: '/thongke/thong_ke_all_theo_phong_muc_luc_hop?phongid=' + $('select[name=selectphong]').val() + '&muclucid=' + muclucid + '&mahop=' + $scope.result_text
        }).then(function (response) {
            $scope.tk_hs_phong = response.data[0];
            $scope.tk_vb_phong = response.data[1];
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    window.onclick = function (event) {
        var lma = $('#selectlam').attr('data-lam');
        var selectlam = document.getElementById('selectlam');
        var textselect = document.getElementsByClassName('text-select');
        var l = false;
        for (var i = 0; i < textselect.length; i++) {
            if (event.target == textselect[i]) l = true;
        }
        if (event.target == selectlam || l) {
            $('#body-select-hop').css('display', 'block');
            $('input[name="search-text"]').focus();
        }
        else {
            $('#body-select-hop').css('display', 'none');
        }
    }
    
    $(document).ready(function () {
        $scope.loadphong();
        $scope.thong_ke_tat_ca();
    })

})