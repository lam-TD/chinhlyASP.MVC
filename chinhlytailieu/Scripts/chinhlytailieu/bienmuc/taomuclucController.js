app.controller("taomuclucController", function ($scope, $http) {
    $scope.tieude = "Chỉnh lý tài liệu";
    $scope.disable_btnsua = true;
    $scope.disable_inputMamucluc = false;
    $scope.disablePhong = false;
    // BIEN MUC - nhap muc luc chinh ly


    function load_danhsachmucluc(idphong) {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach',
            data: { id: idphong }
        }).then(function (response) {
            $scope.mucluc = response.data;
        }, function (response) {
            alert('Không tải được danh sách mục lục');
        })
    }


    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        //console.log(response.data);
        $scope.danhsachphong = response.data;
    }, function (response) {
        alert('Không tải được danh sách Phông');
    })

    $scope.click_phong = function (id) {
        //console.log(id);
        $('.row').removeClass("activePhong");
        $('#r' + id).addClass("activePhong");
        console.log(('id: ' + id));
        //$('.opphong').removeAttr("selected");
        //$('#' + id).attr("selected", "selected");
        $('select[name=selectphong]').val(id).trigger('change');
        $scope.disable_btnsua = true;
        $scope.idphong = id;
        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loaddanhsach/' + id,
            data: { id: id }
        }).then(function (response) {
            $scope.mucluc = response.data;
        }, function (response) {
            alert('Không tải được danh sách mục lục');
        })
    }

    
    $scope.click_mucluc = function (u) {
        $('.row_mucluc').removeClass("activePhong");
        $('#p' + u.ID).addClass("activePhong");
        $scope.disable_btnsua = false;
        var ml =
        {
            id: u.ID,
            tenmucluc: u.TENMUCLUC,
            mamucluc: u.MAMUCLUC,
            mota: u.MOTA,
            ghichu: u.GHICHU,
            phongid: u.PHONGID
        }
        $scope.ml = ml;
    }

    $scope.modal = function (state) {
        $scope.state = state;
        //$('.opphong').removeAttr("selected");
        //$('#phong' + $scope.idphong).attr("selected", "selected");
        if (state == "add") {
            $scope.disablePhong = false;
            $scope.titleModal = "Thêm mới mục lục";
            $scope.phongid = $scope.idphong;
            var ml =
            {
                tenmucluc: "",
                mamucluc: "",
                mota: "",
                ghichu: "",
                phongid: ""
            }
            $scope.ml = ml;
            $scope.disable_inputMamucluc = false;
            $scope.disable_btnsua = true;
        }
        else {
            $scope.disable_inputMamucluc = true;
            $scope.disablePhong = true;
            $scope.titleModal = "Cập nhật mục lục";
        }
    }

    $scope.check_mamucluc = function (id) {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_checkmamucluc/' + id
        }).then(function (response) {
            console.log(response.data);
            if (parseInt(response.data) == 1) {
                return 1;
            }
            else {
                return -1;
            }
        }, function (response) {
            return 1;
        })
    }


    $scope.save = function () {
        if ($('select[name=selectphong]').val() == "") {
            alert("Vui lòng chọn phông");
        }
        else {
            if ($scope.state == "add") {
                $scope.ml =
                        {
                            phongid: $('select[name=selectphong]').val(),
                            tenmucluc: $scope.ml.tenmucluc,
                            mamucluc: $scope.ml.mamucluc,
                            mota: $scope.ml.mota,
                            ghichu: $scope.ml.ghichu,
                        };
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/mucluc_themsua',
                    data: { type: 1, ml: $scope.ml }
                }).then(function (response) {
                    //console.log(response.data);
                    if (response.data == 1) {
                        alert('Thêm mục lục thành công');
                        $('#myModal').modal('hide');
                        $scope.click_phong($('select[name=selectphong]').val());
                    }
                    else if (response.data == 0) alert("Mã mục lục đã tồn tại");
                    else alert('Lỗi không thêm được mục lục');
                }, function (response) {
                    alert('Lỗi không thêm được mục lục');
                })
            }
            else {
                $scope.ml2 =
                {
                    phongid: $('select[name=selectphong]').val(),
                    tenmucluc: $scope.ml.tenmucluc,
                    mamucluc: $scope.ml.mamucluc,
                    mota: $scope.ml.mota,
                    ghichu: $scope.ml.ghichu,
                };
                //console.log($scope.ml2);
                $http({
                    method: 'POST',
                    url: '/chinhlytailieu/mucluc_themsua',
                    data: { type: 2, ml: $scope.ml }
                }).then(function (response) {
                    console.log(response.data);
                    if (response.data == 1) {
                        alert('Cập nhật mục lục thành công');
                        $('#myModal').modal('hide');
                        $scope.click_phong($('select[name=selectphong]').val());
                    }
                    else {
                        alert('Lỗi không cập nhật được mục lục');
                    }
                })
            }
        }
    }

    $scope.delete = function () {
        var confri = confirm("Bạn có chắc chắn muốn xóa mục lục vừa chọn?");
        //alert($scope.ml.id);
        $http({
            method: 'POST',
            url: '/chinhlytailieu/mucluc_xoa',
            data: { idmucluc: $scope.ml.id }
        }).then(function (response) {
            console.log(response.data);
            if (response.data == 1) {
                alert('Đã xóa mục lục thành công');
                $scope.click_phong($scope.idphong);
            }
            else if (response.data == 0) {
                alert('Mục lục này có chưa hồ sơ vui lòng xóa hồ sơ trong mục lục này!');
            }
            else {
                alert('Lỗi không xóa được mục lục');
            }
        }, function (response) {
            alert('Lỗi không xóa được mục lục');
        })
    }


    // 
    function PagerService() {
        // service definition
        var service = {};

        service.GetPager = GetPager;

        return service;

        // service implementation
        function GetPager(totalItems, currentPage, pageSize) {
            // default to first page
            currentPage = currentPage || 1;

            // default page size is 10
            pageSize = pageSize || 10;

            // calculate total pages
            var totalPages = Math.ceil(totalItems / pageSize);

            var startPage, endPage;
            if (totalPages <= 10) {
                // less than 10 total pages so show all
                startPage = 1;
                endPage = totalPages;
            } else {
                // more than 10 total pages so calculate start and end pages
                if (currentPage <= 6) {
                    startPage = 1;
                    endPage = 10;
                } else if (currentPage + 4 >= totalPages) {
                    startPage = totalPages - 9;
                    endPage = totalPages;
                } else {
                    startPage = currentPage - 5;
                    endPage = currentPage + 4;
                }
            }

            // calculate start and end item indexes
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);

            // create an array of pages to ng-repeat in the pager control
            var pages = _.range(startPage, endPage + 1);

            // return object with all pager properties required by the view
            return {
                totalItems: totalItems,
                currentPage: currentPage,
                pageSize: pageSize,
                totalPages: totalPages,
                startPage: startPage,
                endPage: endPage,
                startIndex: startIndex,
                endIndex: endIndex,
                pages: pages
            };
        }
    }

    function ExampleController(PagerService) {
        var vm = this;

        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loadphong'
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachphong = response.data;
        }, function (response) {
            alert('Không tải được danh sách Phông');
        })

        vm.dummyItems = $scope.danhsachphong; // dummy array of items to be paged

        vm.pager = {};
        vm.setPage = setPage;

        initController();

        function initController() {
            // initialize to page 1
            vm.setPage(1);
        }

        function setPage(page) {
            if (page < 1 || page > vm.pager.totalPages) {
                return;
            }

            // get pager object from service
            vm.pager = PagerService.GetPager(vm.dummyItems.length, page);

            // get current page of items
            vm.items = vm.dummyItems.slice(vm.pager.startIndex, vm.pager.endIndex + 1);
        }
    }

})