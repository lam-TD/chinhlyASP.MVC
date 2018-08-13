app.controller("nhaphosothemController", function ($scope, $http, $rootScope, $location) {
    $scope.tieude = "Thêm mới hồ sơ";
    $scope.phongCha = "";
    $scope.muclucCha = "";
    $scope.disableMahoso = false;
    $scope.regexdate = '/^(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/](19|20)\d\d$/';
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        $scope.danhsachphong = response.data;
    }, function (response) {
        //alert('Không tải được danh sách phông');
    })

    $scope.loadmucluc = function () {
        //alert($('select[name=selectphong]').val());
        $http({
            method: 'POST',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + $('select[name=selectphong]').val(),
            data: { phongid: $('select[name=selectphong]').val() }
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachmucluc = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.loadhop = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_loadHop/' + $('select[name=selectmucluc]').val(),
            data: { muclucid: $('select[name=selectmucluc]').val() }
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachhop = response.data;
            $rootScope.phongidChitietHoSo = $('select[name=selectphong]').val();
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.loadchitiethoso = function (id) {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_loadchitiet',
            data: { id: id }
        }).then(function (response) {
            console.log(response.data);
            $('select[name=selectphong]').val(response.data[0].PHONGID).trigger('change');
            //$('#p' + response.data[0].PHONGID).attr("selected", "selected");
            $scope.h =
            {
                id: response.data[0].ID,
                mucluc: "",
                mahop: "",
                mahoso: response.data[0].MAHOSO,
                tenhoso: response.data[0].TENHOSO,
                thoigians: response.data[0].THOIGIANS,
                thoigiane: response.data[0].THOIGIANE,
                slto: response.data[0].SLTO,
                bienmuc: response.data[0].BIENMUC,
                hcsd: response.data[0].HCSD,
                loaitl: response.data[0].LOAITL,
                namlap: response.data[0].NAMLAP,
                chugiai: response.data[0].CHUGIAI,
                tinhtrang: response.data[0].TINHTRANG,
                ghichu: response.data[0].GHICHU,
                ngongu: response.data[0].NGONNGU,
            }
            $scope.phongCha = response.data[0].PHONGID;
            $scope.muclucCha = response.data[0].MUCLUC;
            $scope.hopCha = response.data[0].MAHOP;
        }, function (response) {
        
        })

        
    }
    
    
    $scope.chitiethosoquayve = function () {
        alert($rootScope.phongidChitietHoSo);
        //$rootScope.phongidChitietHoSo = $('select[name=selectphong]').val();
        //alert($rootScope.phongidChitietHoSo);
        location.href = "#!nhaphoso";
    }

    $scope.save = function () {
        if ($('select[name=selectphong]').val() == "") {
            alert("Vui lòng chọn phông");
        }
        else if ($('select[name=selectmucluc]').val() == "") {
            alert("Vui lòng chọn mục lục");
        }
        else
        {
            var path = $location.path();
            if ($scope.path == "/nhaphoso/them")
            {
                $scope.themhoso();
            }
            else
            {
                phongid = $('select[name=selectphong]').val();
                muclucid = $('select[name=selectmucluc]').val();
                mahop = $('select[name=selecthop]').val();
                console.log('phongid: ' + phongid);
                var mangmahop = [];

                if (($scope.hopCha == "" && mahop == "") || ($scope.hopCha != "" && $scope.hopCha == mahop) || ($scope.hopCha == "" && mahop != "")) {
                    // cập nhật thông tin
                    //var mangmahop = [];
                    hopid = $('#h' + mahop).attr("data-mahop")
                    mangmahop = [$scope.hopCha, "", $scope.muclucCha, mahop, hopid];
                }
                else if ($scope.hopCha != "" && $scope.hopCha != mahop) {
                    // cập nhật thông tin
                    // cập nhật số lượng hộp mới và cũ
                    hopid = $('#h' + $scope.h.mahop).attr("data-mahop");
                    mangmahop = [$scope.hopCha, $scope.hopidCha, $scope.muclucCha, mahop, hopid];

                    //alert("Cập nhật thông tin và cập nhật slhop");
                }

                var hopcapnhat = [phongid, muclucid];
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/hoso_sua',
                    data: { h: $scope.h, mangmahop: mangmahop, hopcapnhat: hopcapnhat }
                }).then(function (response) {
                    //console.log(response.data);
                    if (response.data == 1) {
                        alert("Cập nhật hồ sơ thành công");
                    }
                    else if (response.data == 0) {
                        alert("Hộp đã đầy");
                    }
                    else {
                        alert('Lỗi không cập nhật được hồ sơ');
                    }
                }, function (response) {
                    alert('Lỗi không thực hiện được chức năng này');
                })
            }
        }
    }

    $scope.themhoso = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_them/',
            data: { h: $scope.h, hopid: $('#h' + $scope.h.mahop).attr("data-mahop") }
        }).then(function (response) {
            if (response.data == 1) {
                alert('Thêm hồ sơ thành công');
                $('#formhoso').trigger("reset");
            }
            else if (response.data == -2) {
                alert("Hồ sơ số vừa nhập đã tồn tại!");
            }
            else if (response.data == 0) {
                alert('Hộp đã đầy!');
            }
            else {
                alert('Lỗi không thêm được hồ sơ');
            }
        }, function (response) {
            alert('Lỗi không thêm được hồ sơ');
        })
    }

    $scope.laymahop = function () {
        alert($('select[name=selecthop]').attr("data-mahop")); 
    }

    $scope.back_nhap = function () {
        var url = $location.url();
        id = url.slice(url.indexOf("=") + 1, url.length);
        console.log(id);
        location.href = "#!nhaphoso?id=" + id;
    }

    $scope.load_select = function () {
        $scope.loadmucluc();
        setTimeout(function () {
            $('select[name=selectmucluc]').val($scope.muclucCha).trigger('change');
            if ($('select[name=selectmucluc]').val() > 0)
            {
                $scope.loadhop();
                if ($scope.hopCha != null && $scope.hopCha != "")
                {
                    setTimeout(function () {
                        $('select[name=selecthop]').val($scope.hopCha).trigger('change');
                        $scope.muclucCha = $('select[name=selectmucluc]').val();
                        //$scope.hopCha = $scope.hopCha;
                        $scope.hopidCha = $('#h' + $scope.h.mahop).attr("data-mahop");
                    }, 1000);
                }
            }

        }, 500);
    }

    $scope.get_phong = function () {
        var url = $location.url();
        id = url.slice(url.indexOf("=") + 1, url.length);
        if (id > 0) {
            setTimeout(function () {
                $scope.loadchitiethoso(id);
                setTimeout(function () {
                    $scope.load_select();
                }, 500);
            }, 1000);
        }
    }

    $(document).ready(function () {
        $scope.path = $location.path();
        //console.log($location.path());
        $scope.get_phong();
    })
})