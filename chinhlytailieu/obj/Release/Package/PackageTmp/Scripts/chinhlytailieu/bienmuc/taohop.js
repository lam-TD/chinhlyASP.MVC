app.controller("taohopController", function ($scope, $http, $rootScope) {
    $scope.title = "Tạo hộp";

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

    $scope.loadmucluc2 = function () {
        //alert($('select[name=selectphong]').val());
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
            console.log(response.data);
            $scope.danhsachhop = response.data;
        }, function (response) {
            alert('Không tải được danh sách hộp');
        })
    }

    $scope.click_phong = function (id) {
        $('.row').removeClass("activePhong");
        $('#' + id).addClass("activePhong");
        $('.rowPhong').removeAttr("selected");
        $('#phong' + id).attr("selected", "selected");
        $scope.loadmucluc();
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
            var codinh = mahop.slice(0, mahop.indexOf("-") + 1);
            $scope.Mahopmoi = parseInt(mahop.slice(mahop.indexOf("-") + 1, mahop.length)) + 1;
 
            $scope.h = { mahop: codinh + $scope.Mahopmoi, phongid: "", muclucid: "" };
            $scope.h2 = { mahop: codinh + $scope.Mahopmoi, phongid: "", muclucid: "" };
            $scope.slhop = 1;
        }, function (response) {
            //alert('Không tải được danh sách phông');
        })
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
                var mahop = response.data;
                var codinh = mahop.slice(0, mahop.indexOf("-") + 1);
                $scope.Mahopmoi = parseInt(mahop.slice(mahop.indexOf("-") + 1, mahop.length)) + 1;

                $scope.h = { mahop: codinh + $scope.Mahopmoi, phongid: "", muclucid: "" };
            }, function (response) {
                //alert('Không tải được danh sách phông');
            })
        }
        
    }
})