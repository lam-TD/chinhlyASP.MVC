app.controller("nhapvanbanController", function ($scope, $http, $rootScope) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $scope.disablebtnADD = true;
    $scope.disablebtnEDIT = true;
    $scope.disableTextSeach = true;
    $scope.hienthi_pagina = false;
    $scope.pagination =
    {
        pageIndex: 1,
        pageSize: 10
    }
    $scope.total = 0;
    $scope.flag_pagination = false;
    $scope.flag_icon = false;
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        $scope.danhsachphong = response.data;
    }, function (response) {
        alert('Không tải được danh sách phông');
    })

    $scope.loadmucluc = function () {
        //alert($('select[name=selectphong]').val());
        $http({
            method: 'POST',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + $('select[name=selectphong]').val(),
            data: { phongid: $('select[name=selectphong]').val() }
        }).then(function (response) {
            $scope.danhsachmucluc = response.data;
            $scope.disableTextSeach = false;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.loadhoso = function (phong_id) {
        if ($('select[name=selectphong]').val() > 0) {
            phongid = $('select[name=selectphong]').val();
        }
        if (phongid < 0) return -1;
        if ($('select[name=selectphong]').val() != "") {
            $http({
                method: 'GET',
                url: '/chinhlytailieu/hoso_load_phong_mucluc?phongid=' + phongid + '&muclucid=' + $('select[name=selectmucluc]').val() + '&pageIndex=' + $scope.pagination.pageIndex + '&pageSize=' + $scope.pagination.pageSize
            }).then(function (response) {
                //console.log(response.data);
                //console.log(response.data[0]["totalCount"]);
                if (response.data.length > 0) { $scope.total = response.data[0]["totalCount"]; $scope.hienthi_pagina = true; }
                else { $scope.total = 0; $scope.hienthi_pagina = false; };
                $scope.danhsachhoso = response.data;
                $scope.select_phong = true;
            }, function (response) {
                //alert('Không tải được danh sách phông');
            })
        }
    }

    $scope.page_Changed = function () {
        if ($scope.flag_pagination) {
            $scope.danhsachhoso = $scope.danhsachtimkiem.slice((($scope.pagination.pageIndex - 1) * $scope.pagination.pageSize), ($scope.pagination.pageIndex * $scope.pagination.pageSize));
        }
        else {
            $scope.loadhoso();
        }
    }

    $scope.search_hoso = function () {
        if ($scope.textSearch.length > 0) {
            $scope.flag_icon = true;
        }
        else {
            $scope.flag_icon = false;
            $scope.pageIndex = 1;
            $scope.pagination.pageSize = 10;
            $scope.loadhoso();
        }
    }

    $scope.delete_text = function () {
        $scope.textSearch = "";
        $scope.flag_icon = false;
        $scope.pagination.pageIndex = 1;
        $scope.pagination.pageSize = 10;
        $scope.flag_pagination = true;
        $scope.loadhoso();
    }

    $scope.tim_kiemhoso = function () {
        if ($('select[name=selectmucluc]').val() > 0) {
            if ($scope.textSearch != "" && $scope.textSearch != null) $scope.timkiemhoso();
            else alert("Nhập từ khóa để tìm kiếm");
        } else { alert("Vui lòng chọn PHÔNG và MỤC LỤC"); }
    }

    $scope.timkiemhoso = function () {
        if ($scope.textSearch != "" && $scope.textSearch != null) {
            $scope.keyword = $scope.textSearch.trim();
            path = '/chinhlytailieu/chinhly_timkiemhoso_phong_mucluc?phongid=' + $('select[name=selectphong]').val() + '&muclucid=' + $('select[name=selectmucluc]').val() + '&keyword=' + $scope.keyword
            $http({
                method: 'GET',
                url: path
            }).then(function (response) {
                //console.log(response.data);
                $scope.danhsachtimkiem = response.data;
                $scope.pagination.pageIndex = 1;
                $scope.pagination.pageSize = 10;
                $scope.danhsachhoso = $scope.danhsachtimkiem.slice((($scope.pagination.pageIndex - 1) * $scope.pagination.pageSize), ($scope.pagination.pageIndex * $scope.pagination.pageSize));
                //danhsachhop.slice(((currentPageHop-1)*itemsPerPageHop), ((currentPageHop)*itemsPerPageHop))
                $scope.total = $scope.danhsachtimkiem.length;
                $scope.flag_pagination = true;
            }, function (response) {
                //alert('Không tải được danh sách mục lục');
            })
        }
        //else { alert("Nhập từ khóa để tìm kiếm"); }
    }
    $('#txtsearch').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $scope.timkiemhoso();
        }
        event.stopPropagation();
    });

    //$scope.loadvanban = function (id) {
    //    $http({
    //        method: 'POST',
    //        url: '/chinhlytailieu/vanban_loadtheohoso',
    //        data: { hosoid: id }
    //    }).then(function (response) {
    //        //console.log(response.data);
    //        $scope.danhsachvanban = response.data;
    //    }, function (response) {
    //        //alert('Không tải được danh sách mục lục');
    //    })
    //}

    function loadvanban(id) {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/vanban_loadtheohoso',
            data: { hosoid: id }
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachvanban = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.clickhoso = function (id) {
        $('.rowho').removeClass("activePhong");
        $('#hs' + id).addClass("activePhong");
        $scope.HOSOID = id;
        
        loadvanban(id);
        $scope.disablebtnADD = false;
    }

    $scope.clickvanban = function (u) {
        $('.rowVanban').removeClass("activePhong");
        $('#v' + u.ID).addClass("activePhong");
        $scope.disablebtnEDIT = false;
        $scope.v =
        {
            id: u.ID,
            sokyhieu: u.SOKYHIEU,
            ngonngu: u.NGOCNGU,
            tacgia: u.TACGIA,
            tenloai: u.TENLOAI,
            thoigian: u.THOIGIAN,
            toso: u.TOSO,
            slto: u.SLTO,
            trichyeu: u.TRICHYEU,
            hosoid: u.HOSOID,
            buttich: u.BUTTICH,
            ghichu: u.GHICHU
        }
    }

    $scope.modal = function (state) {
        if (state == "add") {
            $scope.state = "add";
            $scope.titlemodal = "Thêm mới văn bản";
            $('#formVanBan').trigger("reset");
        }
        else {
            $scope.state = "edit";
            $scope.titlemodal = "Cập nhật văn bản";
        }
    }

    $scope.save = function () {
        if ($scope.state == "add") {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/vanban_them',
                data: { v: $scope.v, hosoid: $scope.HOSOID }
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Thêm thành công văn bản');
                    $('#myModal').modal('hide');
                    loadvanban($scope.HOSOID);
                }
                else {
                    alert('Lỗi không thêm được văn bản');
                }
            }, function (response) {
                alert('Lỗi không thực hiện được chức năng này');
            })
        }
        else {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/vanban_sua',
                data: { v: $scope.v }
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Cập nhật thành công văn bản');
                    $('#myModal').modal('hide');
                    loadvanban($scope.HOSOID);
                }
                else {
                    alert('Lỗi không cập nhật được văn bản');
                }
            }, function (response) {
                alert('Lỗi không thực hiện được chức năng này');
            })
        }
    }

    $scope.xoa = function () {
        conf = confirm("Bạn có chắc chắn muốn xóa văn bản vừa chọn?");
        if (conf) {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/vanban_xoa',
                data: { vanbanid: $scope.v.id }
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Đã xóa văn bản');
                    loadvanban($scope.HOSOID);
                }
                else {
                    alert('Lỗi không xóa được văn bản');
                }
            }, function (response) {
                alert('Lỗi không thực hiện chức năng này');
            })
        }
    }

    $(document).ready(function () {
        

    })
})