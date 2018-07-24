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

            }, function (response) {
                //alert('Không tải được danh sách mục lục');
            })
        }
        else {
            alert("Sua");
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