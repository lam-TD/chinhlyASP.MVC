app.controller("timkiemvanbanController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.keyword = "";

    $scope.timkiemvanban = function () {
        if ($scope.textSearch != "" && $scope.textSearch != null) {
            $scope.keyword = $scope.textSearch.trim();
            $http({
                method: 'GET',
                url: '/chinhlytailieu/chinhly_timkiemvanban?keyword=' + $scope.keyword
            }).then(function (response) {
                console.log(response.data);
                $scope.danhsachketquavb = response.data;

                if ($scope.danhsachketquavb.length > 0) {
                    $scope.totalresult = $scope.danhsachketquavb.length;
                }
                else { $scope.totalresult = "Không tìm thấy"; }
            }, function (response) {
                //alert('Không tải được danh sách mục lục');
            })
        }
        else {
            alert("Vui lòng nhập từ khóa để tìm kiếm");
        }
    }

    $scope.xemchitiet = function (n) {
        $scope.TRICHYEU = n.TRICHYEU;
        $scope.SOKYHIEU = n.SOKYHIEU;
        $scope.TOSO = n.TOSO;
        $scope.MAHOP = n.MAHOP;
        $scope.MAHOSO = n.MAHOSO;
        $scope.phong = n.TENPHONG;
        $scope.THOIGIAN = n.THOIGIAN;
        $scope.TACGIA = n.TACGIA;
        $scope.GHICHU = n.GHICHU;

    }

    $scope.timkiem_click = function (state) {
        if (state == "1") { link = "#!/timkiemvanbannangcao"; }
        else if (state == "2") { link = "#!/timkiemhoso"; }
        else if (state == "3") { link = "#!/timkiemhosonangcao"; }
        location.href = link;
        //$rootScope = $scope.keyword.trim();
        //$http({
        //    method: 'GET',
        //    url: '/chinhlytailieu/session_keyword?keyword=' + $scope.keyword
        //}).then(function (response) {
        //    location.href = link;
        //}, function (response) {
        //    //alert('Không tải được danh sách mục lục');
        //})
    }

    $scope.check_keyword = function () {
        $http({
            method: 'GET',
            url: '/chinhlytailieu/get_sesion_keyword_vanban'
        }).then(function (response) {
            if (response.data != null && response.data != "") {
                if ($scope.textSearch != "" && $scope.textSearch != null) { return; }
                $scope.textSearch = response.data;
                $scope.timkiemvanban();
            }
        }, function (response) {
            //alert('Không tải được danh sách mục lục');
        })
    }

    $scope.doimauchu = function (str, keyword) {
        str = $('.tenhoso').text;
        //console.log(str);
        chuoi = '<span style="background-color:yellow;font-weight:700;">' + $scope.keyword + '</span>';
        //var lam = str.replace(keyword, chuoi);
        //return lam;
    }

    $scope.convertDate = function (date) {
        var d = new Date(date);
        day = d.getDay() + 1;
        month = d.getMonth() + 1;
        year = d.getFullYear();
        //console.log(d);
        //console.log(day + '-' + month + '-' + year);
    }


    $(document).ready(function () {
        $('#txtsearch').focus();
        setTimeout($scope.check_keyword(), 2000);
    })
    $('#txtsearch').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $scope.timkiemvanban();
        }
        event.stopPropagation();
    });

})