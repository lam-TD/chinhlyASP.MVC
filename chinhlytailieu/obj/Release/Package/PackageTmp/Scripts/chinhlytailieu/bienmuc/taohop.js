app.controller("taohopController", function ($scope, $http, $rootScope) {
    $scope.title = "Tạo hộp";
    $scope.disablebtn = true;
    $scope.currentPagePhong = 1;
    $scope.itemsPerPagePhong = 12;
    $scope.hienthi_hop = false;
    $scope.flag_phong = true;
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
            $scope.phongid = $('select[name=selectphong]').val();
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.loadmucluc2 = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + $('select[name=selectphong2]').val(),
            data: { phongid: $('select[name=selectphong2]').val() }
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachmucluc = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }


    $scope.loadhoptheoPhong = function (id) {
        //alert("Lam");
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hop_loadhoptheoPhong/' + id,
            data: { phongid: id }
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhop = response.data;
            ($scope.danhsachhop.length > 0) ? $scope.hienthi_hop = true : $scope.hienthi_hop = false;
        }, function (response) {
            alert('Không tải được danh sách hộp');
        })
    }

    $scope.click_phong = function (id) {
        $('.row').removeClass("activePhong");
        $('#' + id).addClass("activePhong");
        $('select[name=selectphong]').val(id).trigger('change');
        $scope.h = { phongid: id };
        //$scope.loadmucluc();
        $scope.phongid = id;
        $scope.loadhoptheoPhong(id);
    }

    $scope.loadIdHopCuoi = function () {
        if ($scope.phongid > 0) {
            //$scope.loadmucluc();
        }
        $http({
            method: 'GET',
            url: '/chinhlytailieu/hop_idcuoi',
        }).then(function (response) {
            var mahop = response.data;
            //console.log(response.data);
            
            if (response.data.length == 0 || response.data == "" || response.data == null) {
                $scope.Mahopmoi = "HOP-1";
                $scope.h = { mahop: $scope.Mahopmoi, phongid: "", muclucid: "" };
            }
            else {
                var codinh = mahop.slice(0, mahop.indexOf("-") + 1);
                $scope.Mahopmoi = parseInt(mahop.slice(mahop.indexOf("-") + 1, mahop.length)) + 1;
                $scope.h = { mahop: codinh + $scope.Mahopmoi, phongid: "", muclucid: "" };
            }
            
                
            //$scope.h = { mahop: codinh + $scope.Mahopmoi, phongid: "", muclucid: "" };
            $scope.h2 = { mahop: $scope.Mahopmoi, phongid: "", muclucid: "" };
            $scope.slhop = 1;
        }, function (response) {
            //alert('Không tải được danh sách phông');
        })
    }

    $scope.clickhop = function (n) {
        $scope.disablebtn = false;
        $('.trhop').removeClass("activePhong");
        $('#hop' + n.HOPID).addClass("activePhong");
        $scope.hopxoa =
        {
            id: n.HOPID,
            mahop: n.MAHOP,
            muclucid: n.MUCLUCID
        };
        //console.log(n);

    }

    $scope.themhop = function (state) {
        if ($('select[name=selectphong]').val() == "") {
            alert("Bạn cần chọn phòng");
        }
        else if ($('select[name=selectmucluc]').val() == "")
        {
            alert("Bạn cần chọn mục lục");
        }
        else if ($scope.Mahopmoi > $scope.h.mahop) {
            alert("Mã hộp cần phải lớn hơn mã hộp cũ");
        }
        else
        {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/hop_checkmahop',
                data: { mahop: $scope.h.mahop }
            }).then(function (response) {
                if (response.data != 1) {
                    $http({
                        method: 'POST',
                        url: '/chinhlytailieu/hop_them',
                        data: { h: $scope.h }
                    }).then(function (response) {
                        if (response.data == 1) {
                            alert("Tạo hộp thành công");
                            $('#myModal').modal('hide');
                            $scope.loadhoptheoPhong($scope.phongid);
                        }
                        else {
                            alert("Lỗi không tạo được hộp");
                        }
                    }, function (response) {
                        alert("Lỗi không tạo được hộp");
                    })
                }
                else {
                    alert("Mã hộp đã tồn tại");
                }
            }, function (response) {
                alert('Không kiểm tra được mã hộp');
            })
        } 
    }

    $scope.themnhieuhop = function () {
        if ($('select[name=selectphong2]').val() == "") {
            alert("Bạn cần chọn phòng");
        }
        else if ($('select[name=selectmucluc2]').val() == "") {
            alert("Bạn cần chọn mục lục");
        }
        else {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/hop_themnhieu',
                data: { h: $scope.h2, slhop: $scope.slhop }
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Thêm thành công ' + $scope.slhop + ' Hộp');
                    $('#myModaltaonhieuhop').modal('hide');
                    $scope.loadhoptheoPhong($scope.phongid);
                }
                else {
                    alert('Lỗi không thêm được hộp');
                }
            }, function (response) {
                alert('Lỗi khoonh thực hiện được chức năng này');
            })
        }
    }

    $scope.xoa = function () {
        var conf = confirm("Bạn có chắc chắn muốn xóa hộp vừa chọn!");
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hop_xoa',
            data: { h: $scope.hopxoa, phongid: $scope.phongid }
        }).then(function (response) {
            if (response.data == 1) {
                alert('Đã xóa hộp vừa chọn');
                $scope.loadhoptheoPhong($scope.phongid);
            }
            else if (response.data == 0) {
                alert('Hộp vừa chọn có chưa hồ sơ vui lòng xóa hồ sơ trong hộp!');
            }
            else {
                alert('Lỗi không xóa được hộp');
            }
        }, function (response) {
            alert('Lỗi không thực hiện được chức năng này');
        })
    }
})