app.controller("nhaphosothemController", function ($scope, $http, $rootScope) {
    $scope.tieude = "Thêm mới hồ sơ";
    $scope.phongCha = "";
    $scope.muclucCha = "";
    $scope.disableMahoso = false;

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
            //console.log(response.data);
            $scope.h =
            {
                id: response.data[0].ID,
                phongid: response.data[0].PHONGID,
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
        else {
            
            if ($rootScope.idhosoCha > 0) {
                phogid = $('select[name=selectphong]').val();
                muclucid = $('select[name=selectmucluc]').val();
                mahop = $('select[name=selecthop]').val();
                
                console.log($scope.hopidCha);
                console.log(mahop);
                if (($scope.hopidCha == "" && mahop == "") || ($scope.hopidCha != "" && $scope.hopidCha == mahop))
                {
                    // cập nhật thông tin
                    alert("Cập nhật thông tin");
                }
                //else if($scope.hopidCha != "" && $scope.hopidCha == mahop) 
                //{
                //    // cập nhật thông tin
                //    alert("Cập nhật thông tin 2");
                //}
                else if($scope.hopidCha != "" && $scope.hopidCha != mahop){
                    // cập nhật thông tin
                    // cập nhật số lượng hộp mới và cũ
                    alert("Cập nhật thông tin và cập nhật slhop");
                }
                //$http({
                //    method: 'POST',
                //    url: '/chinhlytailieu/hoso_sua',
                //    data: { h: $scope.h, phongid: phogid, muclucid: muclucid, mahop: mahop }
                //}).then(function (response) {
                //    //console.log(response.data);
                //    if (response.data == 1) {
                //        alert("Cập nhật hồ sơ thành công");
                //    }
                //    else {
                //        alert('Lỗi không cập nhật được hồ sơ');
                //    }
                //}, function (response) {
                //    alert('Lỗi không thực hiện được chức năng này');
                //})
            }
            else {
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/hoso_check_idhoso',
                    data: { mahoso: $scope.h.mahoso, phongid: $scope.h.phongid }
                }).then(function (response) {
                    if (response.data == 1) {
                        alert("Hồ sơ số vừa nhập đã tồn tại!");
                    }
                    else {
                        $http({
                            method: 'POST',
                            url: '/chinhlytailieu/hoso_them/',
                            data: { h: $scope.h, hopid: $('#h' + $scope.h.mahop).attr("data-mahop") }
                        }).then(function (response) {
                            if (response.data == 1) {
                                alert('Thêm hồ sơ thành công');
                                //if ($scope.h.mahop != null) {
                                //    $http({
                                //        method: 'POST',
                                //        url: '/chinhlytailieu/hop_capnhatsoluong',
                                //        data: { hopid: $('#h' + $scope.h.mahop).attr("data-mahop") }
                                //    }).then(function (response) {

                                //    }, function (response) {
                                //        alert('Lỗi không cập nhật được số lượng hồ sơ trong hộp');
                                //    })
                                //}
                                $('#formhoso').trigger("reset");
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
                }, function (response) {
                    alert('Lỗi không kiểm tra được mã hồ sơ');
                })
            }   
        }
    }

    $scope.laymahop = function () {
        alert($('select[name=selecthop]').attr("data-mahop")); 
    }
    

    $(document).ready(function () {
        //alert($scope.phongCha);
        
        if ($rootScope.idhosoCha > 0) {
            $scope.loadchitiethoso($rootScope.idhosoCha);
            $scope.disableMahoso = true;
            setTimeout(function () {
                //alert($scope.phongCha);
                $('#p' + $scope.phongCha).attr("selected", "selected");
                $scope.loadmucluc();

                setTimeout(function () {
                    $('.rowmucluc').removeAttr('selected');
                    $('#ml' + $scope.muclucCha).attr("selected", "selected");
                    if ($('select[name=selectmucluc]').val() > 0) {
                        $scope.loadhop();
                        setTimeout(function () {
                            $('.rowhop').removeAttr('selected');
                            $('#h' + $scope.hopCha).attr("selected", "selected");
                            $scope.hopidCha = $('select[name=selecthop]').val();
                        }, 500);
                    }
                        
                }, 500);
            }, 1000);
        }
        
        //$('.js-example-basic-single').select2();
    })
})