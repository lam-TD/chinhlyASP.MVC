app.controller("nhaphosothemController", function ($scope, $http, $rootScope, $location) {
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
        else
        {
            var path = $location.path();
            if ($scope.path == "/nhaphoso/them") {
                $scope.themhoso();
            }

            return 1;

            if (confirm("Bạn có chắc chắn muốn cập nhật lại hồ sơ")) {
                if ($rootScope.idhosoCha > 0) {
                phongid = $('select[name=selectphong]').val();
                muclucid = $('select[name=selectmucluc]').val();
                mahop = $('select[name=selecthop]').val();
                console.log('phongid: ' + phongid);
                var mangmahop = [];
                
                if (($scope.hopmaCha == "" && mahop == "") || ($scope.hopmaCha != "" && $scope.hopmaCha == mahop) || ($scope.hopmaCha == "" && mahop != ""))
                {
                    // cập nhật thông tin
                    //var mangmahop = [];
                    alert("Cập nhật thông tin");
                    hopid = $('#h' + mahop).attr("data-mahop")
                    mangmahop = [$scope.hopmaCha, "", $scope.muclucidCha, mahop, hopid];
                }
                else if($scope.hopmaCha != "" && $scope.hopmaCha != mahop){
                    // cập nhật thông tin
                    // cập nhật số lượng hộp mới và cũ
                    hopid = $('#h' + $scope.h.mahop).attr("data-mahop");
                    mangmahop = [$scope.hopmaCha, $scope.hopidCha, $scope.muclucidCha, mahop, hopid ];
                    
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
            else {
                
            }  
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

    function validate_date() {
        var lam = '^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$';
    }
    

    $(document).ready(function () {
        $scope.path = $location.path();
        console.log($location.path());
        //if ($rootScope.idhosoCha > 0) {
        //    $scope.loadchitiethoso($rootScope.idhosoCha);
        //    $scope.disableMahoso = true;
        //    setTimeout(function () {
        //        //alert($scope.phongCha);
        //        $('#p' + $scope.phongCha).attr("selected", "selected");
        //        $scope.loadmucluc();

        //        setTimeout(function () {
        //            $('.rowmucluc').removeAttr('selected');
        //            $('#ml' + $scope.muclucCha).attr("selected", "selected");
        //            if ($('select[name=selectmucluc]').val() > 0) {
        //                $scope.loadhop();
        //                setTimeout(function () {
        //                    $('.rowhop').removeAttr('selected');
        //                    $('#h' + $scope.hopCha).attr("selected", "selected");
        //                    $scope.muclucidCha = $('select[name=selectmucluc]').val();
        //                    $scope.hopmaCha = $('select[name=selecthop]').val();
        //                    $scope.hopidCha = $('#h' + $scope.h.mahop).attr("data-mahop");
        //                }, 500);
        //            }
                        
        //        }, 500);
        //    }, 1000);
        //}
        
        //$('.js-example-basic-single').select2();
    })
})