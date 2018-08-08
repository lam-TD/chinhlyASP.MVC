app.controller("nhaphosoController", function ($scope, $http, $rootScope) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $scope.disablebtn = true;
    $scope.pageIndex = 1;
    $scope.pageSize = 10;
    $scope.total = 0;
    $rootScope.idhosoCha = 0;
    $scope.select_phong = false;
    $scope.arrhienthi = [10, 20, 30];
    $scope.page_Size = $scope.arrhienthi[0];

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
        phongid = $('select[name=selectphong]').val();

        if ($('select[name=selectphong]').val() != "") {
            $http({
                method: 'GET',
                url: '/chinhlytailieu/hoso_load?phongid=' + phongid + '&pageIndex=' + $scope.pageIndex + '&pageSize=' + $scope.pageSize
            }).then(function (response) {
                //console.log(response.data);
                //console.log(response.data[0]["totalCount"]);
                $scope.total = response.data[0]["totalCount"];
                $scope.danhsachhoso = response.data;
                $scope.select_phong = true;
            }, function (response) {
                alert('Không tải được danh sách phông');
            })
        }
    }

    $scope.pageChanged = function () {
        $scope.loadMucluc();
    }

    $scope.change_hienthi = function (n) {
        $scope.pageIndex = 1;
        $scope.pageSize = n;
        //$scope.pageSize = $('select[name=selecthienthi]').val();
        $scope.loadMucluc();
    }

    function changehienthi() {
        $scope.pageIndex = 1;
        $scope.pageSize = $('select[name=selecthienthi]').val();
        $scope.loadMucluc();
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
        //$('#idhienthi').on('change', $scope.change_hienthi());
        if ($rootScope.phongidChitietHoSo > 0) {
            $scope.loaddanhsachhoso($rootScope.phongidChitietHoSo);
        }
    })
})