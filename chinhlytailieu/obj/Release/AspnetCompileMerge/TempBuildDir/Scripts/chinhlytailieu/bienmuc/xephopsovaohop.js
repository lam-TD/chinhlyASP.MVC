app.controller("xephosovaohopController", function ($scope, $http, $rootScope) {
    $scope.title = "Tạo hộp";
    $scope.disablebtnChuyenvaohop = true;
    $scope.disablebtn = true;
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    $scope.currentPageHop = 1;
    $scope.itemsPerPageHop = 10;
    $scope.total = 0;
    $scope.pagination =
    {
        pageIndex: 1,
        pageSize: 10
    }

    $scope.loadhosochuavaohop = function (phong_id) {
        //alert($('select[name=selectphong]').val());
        if ($('select[name=selectphong]').val() > 0) {
            phongid = $('select[name=selectphong]').val();
        }
        if (phongid < 0) return -1;
        if ($('select[name=selectphong]').val() != "") {
            $http({
                method: 'GET',
                url: '/chinhlytailieu/hoso_hschuavaohop?phongid=' + phongid + '&pageIndex=' + $scope.pagination.pageIndex + '&pageSize=' + $scope.pagination.pageSize
            }).then(function (response) {
                //console.log(response.data);
                //console.log(response.data[0]["totalCount"]);
                if (response.data.length > 0) $scope.total = response.data[0]["totalCount"];
                else $scope.total = 0;
                $scope.danhsachhoso = response.data;
                $scope.select_phong = true;
            }, function (response) {
                //alert('Không tải được danh sách phông');
            })
        }
    }

    $scope.countHoso = function () {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/hoso_demhosochuavaohop?phongid=' + $('select[name=selectphong]').val()
        }).then(function (response) {
            $scope.danhsachphong = response.data;
        }, function (response) {
            //alert('Không tải được danh sách phông');
        })
    }

    $scope.page_Changed = function () {
        if ($scope.flag_pagination) {
            $scope.danhsachhoso = $scope.danhsachtimkiem.slice((($scope.pagination.pageIndex - 1) * $scope.pagination.pageSize), ($scope.pagination.pageIndex * $scope.pagination.pageSize));
        }
        else {
            $scope.loadMucluc();
        }
    }

    $scope.change_hienthi = function (n) {
        $scope.pageIndex = 1;
        $scope.pagination.pageSize = n;
        $scope.loadMucluc();
    }

    function changehienthi() {
        $scope.pageIndex = 1;
        $scope.pageSize = $('select[name=selecthienthi]').val();
        $scope.loadMucluc();
    }


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
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach?id=' + $('select[name=selectphong]').val()
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachmucluc = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    //$scope.loadhop = function () {
    //    $http({
    //        method: 'POST',
    //        url: '/chinhlytailieu/hoso_loadHop?muclucid=' + $('select[name=selectmucluc]').val()
    //    }).then(function (response) {
    //        //console.log(response.data);
    //        $scope.danhsachhop = response.data;
    //    }, function (response) {
    //        alert('Không tải được danh sách hộp');
    //    })
    //}

    //$scope.loadhosochuavaohop = function () {
    //    if ($('select[name=selectphong]').val() != "") {
    //        $scope.loadmucluc();
    //        $http({
    //            method: 'POST',
    //            url: '/chinhlytailieu/hoso_hschuavaohop',
    //            data: { phongid: $('select[name=selectphong]').val() }
    //        }).then(function (response) {
    //            //console.log(response.data);
    //            $scope.danhsachhosochuavaohop = response.data;
    //        }, function (response) {
    //            //alert('Không tải được danh sách mục lục');
    //        })
    //    }
    //}

    $scope.loadhosochuavaohop2 = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_hschuavaohop',
            data: { phongid: $('select[name=selectphong]').val() }
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhosochuavaohop = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.xemhoso = function (n) {
        mahop = n.MAHOP;
        $scope.MAHOPxemhoso = n.MAHOP;
        mucluc = n.MUCLUCID;
        phongid = $('select[name=selectphong]').val();
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_loadtheohop?mahop=' + mahop + '&muclucid=' + mucluc + '&phongid=' + phongid
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachhosotronghop = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.clickHoSo = function (u) {
        //$('.rowHoso').removeClass("activePhong");
        //$('#hs' + u.ID).addClass("activePhong");
        
    }
    
    

    $scope.clickHop = function (u) {
        $('.rowHop').removeClass("activePhong");
        $('#hop' + u.ID).addClass("activePhong");
        $scope.disablebtnChuyenvaohop = false;
        $scope.MaHopThemHoSo = u.MAHOP;
        $scope.slmax = u.SLMAX;
        $scope.slhosotronghop = u.SLHOSO;
        //console.log("slhoso: " + $scope.slhosotronghop);
        $scope.hopid = u.ID;
    }

    $scope.chuyenhoso = function () {
        var slcheck = $("input:checkbox:checked").length;
        if (slcheck == 0)
        {
            alert('Bạn chưa chọn HỒ SƠ');
            //$scope.disablebtnChuyenvaohop = true;
        }
        else if ($scope.MaHopThemHoSo <= 0) {
            alert('Bạn chưa chọn HỘP');
        }
        else
        {
            conf = confirm('Bạn có chắc chắn muốn chuyền ' + slcheck + ' hồ sơ vừa chọn vào hồ sơ có mã hồ sơ: ' + $scope.MaHopThemHoSo);
            if (conf) {
                lam = $scope.slmax - (slcheck + $scope.slhosotronghop);
                conlai = $scope.slmax - $scope.slhosotronghop;
                if (lam >= 0) {
                    var arrIdHoSo = $("input:checkbox:checked").map(function () {
                        return $(this).val();
                    }).get();
                    console.log(arrIdHoSo);
                    console.log("mahop: " + $scope.MaHopThemHoSo);
                    $http({
                        method: 'POST',
                        url: '/chinhlytailieu/themhosovaohop',
                        data: {
                            h: arrIdHoSo,
                            mahop: $scope.MaHopThemHoSo,
                            muclucid: $('select[name=selectmucluc]').val(),
                            hopid: $scope.hopid,
                            phongid: $('select[name=selectphong]').val()
                        }
                    }).then(function (response) {
                        console.log(response.data);
                        if (response.data == 1) {
                            alert("Thêm hồ sơ vào hộp thành công");
                            $scope.slhosotronghop = 0;
                            $scope.loadhosochuavaohop2();
                            $scope.loadhop();
                        }
                        else {
                            alert("Lỗi không thêm được hồ sơ vào hộp");
                        }
                    }, function (response) {
                        alert('Không thực hiện được chức năng này');
                    })
                }
                else {
                    alert('Số lượng hồ sơ vừa chọn vượt quá sức chưa của hộp!Còn ' + conlai + ' hồ sơ có thể thêm vào hộp');
                }
            }
        }
        
        $scope.hoso_capnhatsoluonghoso = function (hopid) {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/hoso_capnhatsoluonghoso',
                data: { hopid: hopid }
            }).then(function (response) {
                
            }, function (response) {
                alert('Lỗi không cập nhật được số lượng hộp');
            })
        }
    }


    checkChonHoSo = function (u) {
        console.log(u);
        if (!u.checked) {
            $('#hs' + u.value).removeClass("activePhong");
        }
        else {
            $('#hs' + u.value).addClass("activePhong");
        }
    }
    
    $scope.xoa_hoso = function (hs) {
        conf = confirm("Bạn có chắc chắn muốn xóa hồ sơ vừa chọn");
        if (conf) {
            $http({
                method: 'POST',
                url: '/chinhlytailieu/hoso_xoa',
                data: {
                    hosoid: hs.ID,
                    mahop: hs.MAHOP,
                    muclucid: hs.MUCLUC,
                    phongid: hs.PHONGID
                }
            }).then(function (response) {
                if (response.data == 1) {
                    alert('Đã xóa hồ sơ vừa chọn');
                    hh = { MAHOP: hs.MAHOP, MUCLUCID: hs.MUCLUC } 
                    $scope.xemhoso(hh);
                }
                else if (response.data == 0) {
                    alert('Hồ sơ này có chứa văn bản, vui lòng xóa văn bản trong hồ sơ này');
                }
                else {
                    alert('Lỗi không xóa được hồ sơ vừa chọn');
                }
            }, function (response) {
                alert('Lỗi không thực hiện được chức năng này');
            })
        }
    }

    $scope.thoatmodalxemhoso = function () {
        $scope.loadhop();
    }

    $(document).ready(function () {
        //$(".content_table").mCustomScrollbar();
    })
})