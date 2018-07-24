app.controller("lapkehoachchinhlyController", function ($scope, $http) {
    $scope.tieude = "Lập kế hoạch chỉnh lý";
    $scope.disablesua = true;
    $scope.disableduyet = true;
    //console.log('hhh');
    $http({
        method: 'GET',
        url: '/chinhlytailieu/lapkehoachchinhly_load'
    }).then(function (response) {
        $scope.DSkehoach = response.data;
        //console.log($scope.DSkehoach);
    }, function (response) {
        console.log(response);
    })

    $scope.loaddanhsachkehoach = function () {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/lapkehoachchinhly_load'
        }).then(function (response) {
            $scope.DSkehoach = response.data;
            //console.log($scope.DSkehoach);
        }, function (response) {
            console.log(response);
        })
    }

    // BIEN MUC - nhap muc luc chinh ly
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        $scope.danhsachphong = response.data;
    }, function (response) {
        console.log(response);
    })

    $scope.modal = function (state) {
        if (state == "add") {
            $scope.titleKh = "Thêm mới kế hoạch chỉnh lý";
            $scope.state = "add";
        }
        else {
            $scope.titleKh = "Thêm mới kế hoạch chỉnh lý";
            $scope.state = "edit";
            
        }
    }

    $scope.clickkh = function (n) {
        $('.rowkehoach').removeClass("activePhong");
        $('#kh' + n.ID).addClass("activePhong");
        $scope.disablesua = false;
        //console.log(n.ID);
        $scope.k =
        {
            id : n.ID,
            ghichu: n.GHICHU,
            mucdich: n.MUCDICH,
            giaidoan : n.GIAIDOAN,
            nam : n.NAM,
            thamdinh : n.THAMDINH,
            trangthai : n.TRANGTHAI
        }
        $('.opphong').removeAttr("selected");
        $('#' + n.PHONGID).attr("selected", "selected");
        
    }

    $scope.savekehoach = function () {
        if ($scope.state == "add") {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/lapkehoach_them',
                data: { k: $scope.k }
            }).then(function (response) {
                if (response.data == 1) {
                    alert("Lập kế hoạch thành công");
                    $('#myModal').modal('hide');
                    $scope.loaddanhsachkehoach();
                }
                else {
                    alert("Lỗi không tạo được kế hoạch");
                }
            }, function (response) {
                alert("Lỗi không thực hiện được chức năng này");
            })
        }
        else {
            var conf = confirm("Bạn có chăc chắn muốn cập nhật kế hoạch chỉnh lý vừa chọn");
            if (conf) {
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/lapkehoach_sua',
                    data: { k: $scope.k, phongid: $('select[name=selectphong]').val() }
                }).then(function (response) {
                    if (response.data == 1) {
                        alert("Cập nhật thành công");
                        $('#myModal').modal('hide');
                        $scope.loaddanhsachkehoach();
                    }
                    else {
                        alert("Lỗi không cập nhật được kế hoạch");
                    }
                }, function (response) {
                    alert("Lỗi không thực hiện được chức năng này");
                })
            }
            
        }
    }

    $scope.xoa = function () {
        conf = confirm("Bạn có chắc chắn muốn xóa kế hoạch chỉnh lý vừa chọn");
        if (conf) {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/lapkehoach_xoa',
                data: { kehoachid : $scope.k.id }
            }).then(function (response) {
                if (response.data == 1) {
                    alert("Đã xóa kế hoạch vừa chọn");
                    $('#myModal').modal('hide');
                    $scope.loaddanhsachkehoach();
                }
                else {
                    alert("Lỗi không xóa được kế hoạch");
                }
            }, function (response) {
                alert("Lỗi không thực hiện được chức năng này");
            })
        }
    }
})
