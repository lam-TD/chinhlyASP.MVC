app.controller("nhaphosoController", function ($scope, $http, $rootScope) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $scope.disablebtn = true;
  
    $rootScope.idhosoCha = 0;

    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        $scope.danhsachphong = response.data;
        $rootScope.danhsachPhongChahaha = response.data;
    }, function (response) {
        alert('Không tải được danh sách phông');
    })

    $scope.loadMucluc = function () {
        ////alert($('select[name=selectphong]').val());
        
        if ($('select[name=selectphong]').val() != "") {
            $http({
                method: 'GET',
                url: '/chinhlytailieu/hoso_load?phongid=' + $('select[name=selectphong]').val()
            }).then(function (response) {
                //console.log(response.data);
                $scope.danhsachhoso = response.data;
                $rootScope.phongidChitietHoSo = $('select[name=selectphong]').val();
            }, function (response) {
                alert('Không tải được danh sách phông');
            })
        }
    }

    $scope.loaddanhsachhoso = function (phongid) {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/hoso_load?phongid=' + phongid

        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhoso = response.data;
        }, function (response) {
            alert('Không tải được danh sách phông');
        })
    }

    

    $scope.clickchonhoso = function (u) {
        $('.rowhoso').removeClass("activePhong");
        $('#' + u.ID).addClass("activePhong");
        $scope.idhoso = u.ID;
        $scope.muclucid = u.MUCLUC;
        $scope.phongid = u.PHONGID;
        $scope.mahop = u.MAHOP;
        $scope.disablebtn = false;
        $('#btnsuahoso').removeAttr("disabled", "disabled");
        $rootScope.idhosoCha = u.ID;
        $rootScope.phongidChitietHoSo = $('select[name=selectphong]').val();
    }

    $scope.loadformedit = function (id) {
        //alert(id);
        $http({
            method: 'POST',
            url: '/chinhlytailieu/loadchitiethoso',
            data: { id: id }
        }).then(function (response) {
            //console.log(response.data);
            location.href = "#!nhaphoso/them";
        }, function (response) {
            alert('Lỗi không tải được chi tiết hồ sơ');
        })
     
    }

    $scope.deleteHoso = function () {
        if ($scope.idhoso > 0) {
            conf = confirm("Bạn có chắc chắn muốn xóa hồ sơ vừa chọn");
            if (conf) {
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/hoso_xoa',
                    data: {
                        hosoid: $scope.idhoso,
                        mahop: $scope.mahop,
                        muclucid: $scope.muclucid,
                        phongid: $scope.phongid
                    }
                }).then(function (response) {
                    if (response.data == 1) {
                        alert("Đã xóa hồ sơ vừa chọn");
                        $scope.loadMucluc(1);
                    }
                    else if (response.data == 0) {
                        alert("Hồ sơ này đang chứa văn bản, không xóa được");
                    }
                    else {
                        alert("Lỗi không xóa được hồ sơ");
                    }
                }, function (response) {
                    alert('Lỗi không thực hiện được chức năng');
                })
            }
            
        }
    }

    $(document).ready(function () {
        $('#btnsuahoso').attr("disabled", "disabled");
        if ($rootScope.phongidChitietHoSo > 0) {
            $scope.loaddanhsachhoso($rootScope.phongidChitietHoSo);
        }
    })
})