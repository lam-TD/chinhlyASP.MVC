app.controller("nhapvanbanController", function ($scope, $http, $rootScope) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $scope.disablebtnADD = true;
    $scope.disablebtnEDIT = true;


    function DatepickerDemoCtrl() {
        vm = this;
        vm.today = function () {
            if (vm.today) {
                vm.day = new Date();
            }
        };
        vm.options = {
            minDate: new Date(),
            showWeeks: true
        };
    }


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
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }


    $scope.loadhoso = function () {
        $http({
            method: 'POST',
            url: '/chinhlytailieu/hoso_loadtheoMucLuc',
            data: { muclucid: $('select[name=selectmucluc]').val() }
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhoso = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

   

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
            buttich: u.BUTTICH
        }
    }

    $scope.modal = function (state) {
        if (state == "add") {
            $scope.state = "add";
            $scope.titlemodal = "Thêm mới văn bản";
            
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
                //alert('Không tải được danh sách mục lục');
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
                //alert('Không tải được danh sách mục lục');
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
        $("input[type=date]").datepicker({
            dateFormat: 'yy-mm-dd',
            onSelect: function (dateText, inst) {
                $(inst).val(dateText); // Write the value in the input
            }
        });

    })
})