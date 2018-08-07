app.controller("timkiemvanbannangcaoController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.keyword = "";
    $scope.flag_add = false;
    $scope.sokyhieu = "";
    $scope.trichyeu = "";
    $scope.thoigian = "";
    $scope.tacgia = "";
    $http({
        method: 'GET',
        url: '/chinhlytailieu/nhapmucluc_loadphong'
    }).then(function (response) {
        //console.log(response.data);
        $scope.danhsachphong = response.data;
    }, function (response) {
        alert('Không tải được danh sách Phông');
    })

    $scope.timkiemvanbannangcao = function () {
        if ($('select[name=selectphong]').val() == "") { alert("Vui lòng chọn phông tài liệu"); return; }
        if ($scope.trichyeu != "" && $scope.trichyeu != null) {
            $scope.phongid = $('select[name=selectphong]').val();
            $scope.loaitl = $('select[name=selectloaitl]').val();
            path = 'phongid=' + $scope.phongid + '&loaitl=' + $scope.loaitl + '&sokyhieu=' + $scope.sokyhieu + '&trichyeu=' + $scope.trichyeu + '&thoigian=' + $scope.thoigian + '&tacgia=' + $scope.tacgia;
            $http({
                method: 'GET',
                url: '/chinhlytailieu/chinhly_timkiemvanbannangcao?' + path
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
            alert("Vui lòng nhập trích yếu văn bản để tìm kiếm");
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
        if (state == "1") { link = "#!/timkiemhosonangcao"; }
        else if (state == "2") { link = "#!/timkiemvanban"; }
        else if (state == "3") { link = "#!/timkiemvanbannangcao"; }
        $rootScope = $scope.keyword.trim();
        $http({
            method: 'GET',
            url: '/chinhlytailieu/session_keyword?keyword=' + $scope.keyword
        }).then(function (response) {
            location.href = link;
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
        //$('#txtsearch').focus();
    })

    $('#frmhosonangcao').submit(function (e) {
        //e.preventdefault();
        $scope.timkiemvanbannangcao();
    });

})