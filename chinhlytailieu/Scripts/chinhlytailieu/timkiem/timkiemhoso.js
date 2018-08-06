app.controller("timkiemhosoController", function ($scope, $http, $rootScope) {
    $scope.title = "Hello";
    $scope.totalresult = 0;
    $scope.keyword = "";

    $scope.timkiemhoso = function () {
        if ($scope.textSearch != "" && $scope.textSearch != null) {
            $scope.keyword = $scope.textSearch.trim();
            $http({
                method: 'GET',
                url: '/chinhlytailieu/chinhly_timkiemhoso?keyword=' + $scope.keyword
            }).then(function (response) {
                console.log(response.data);
                $scope.danhsachketqua = response.data;
                $scope.totalresult = $scope.danhsachketqua.length;
                $scope.doimauchu();
            }, function (response) {
                //alert('Không tải được danh sách mục lục');
            })
        }
        else{
            alert("Vui lòng nhập từ khóa để tìm kiếm");
        }
    }

    $scope.doimauchu = function (str, keyword) {
        str = $('.tenhoso').text;
        //console.log(str);
        chuoi = '<span style="background-color:yellow;font-weight:700;">'+ $scope.keyword +'</span>';
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

    $scope.enter = function (keyevent) {
        alert('I 123');
        //if (keyEvent.which === 13)
        //    alert('I am an alert');
    }

    $(document).ready(function () {
        $('#txtsearch').focus();
    })
    $('#txtsearch').keypress(function (event) {

        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $scope.timkiemhoso();
        }
        event.stopPropagation();
    });
    
})