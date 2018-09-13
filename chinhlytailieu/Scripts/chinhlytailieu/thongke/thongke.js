app.controller("thongkeController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.disablebtn = true;
    $scope.disableinput = true;

    $scope.loadphong = function () {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/nhapmucluc_loadphong'
        }).then(function (response) {
            console.log(response.data);
            $scope.danhsachphong = response.data;
        }, function (response) {
            alert('Không tải được danh sách Phông');
        })
    }

    $scope.loadmucluc = function () {
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

    $scope.loadhop = function () {
        console.log('dadadsad');
        $http({
            method: 'GET',
            url: '/chinhlytailieu/hoso_loadHop?muclucid=' + $('select[name=selectmucluc]').val()
        }).then(function (response) {
            //console.log(response.data);
            $scope.danhsachhop = response.data;
        }, function (response) {
            alert('Không tải được danh sách hộp');
        })
    }

    $scope.hoso_loadtheoMucLuc = function () {
        $http({
            method: 'GET',
            url: '/thongke/hoso_loadtheoMucLuc?muclucid=' + $('select[name=selectmucluc]').val()
        }).then(function (response) {
            $scope.danhsachhoso = response.data;
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.select_hop = function (h) {
        console.log(h);
        $scope.result_text = h.MAHOP;
        $('#body-select-hop').removeClass('hien');
    }

    $scope.click_text_select = function () {
        $('#body-select-hop').addClass('hien');
    }

    window.onclick = function (event) {
        var lma = $('#selectlam').attr('data-lam');
        var selectlam = document.getElementById('selectlam');
        //var hop = document.getElementById('body-select-hop');
        console.log(event.target);
        var textselect = document.getElementsByClassName('text-select');
        var l = false;
        for (var i = 0; i < textselect.length; i++) {
            if (event.target == textselect[i]) l = true;
        }
        if (event.target == selectlam || l) {
            $('#body-select-hop').css('display', 'block');
        }
        else {
            $('#body-select-hop').css('display', 'none');
        }
    }
    
    $(document).ready(function () {
        $scope.loadphong();

        
    })

})