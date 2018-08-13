app.controller("qlphongController", function ($scope, $http) {
    $scope.nhomchucnang = "Quản lý người dùng";
    $scope.chucnang = "Quản lý phòng ban";

    $scope.btn_disable = true;
    $scope.flag = true;
    $scope.txtdisable = true;

    $scope.hienthicon = function () {
        var cq = document.getElementsByClassName('hienthicoquan');
        var cqcon = document.getElementsByClassName('coquancon');
        var madonvi = null;
        for (var i = 0; i < cq.length; i++) {
            cq[i].onclick = function () {
                for (var j = 0; j < cq.length; j++) {
                    cq[j].classList.remove("active-coquan");
                }
                this.classList.add("active-coquan");
                for (var i = 0; i < cqcon.length; i++) {
                    cqcon[i].style.display = "none";
                }
                madonvi = this.getAttribute("data-hienthi");
                $http({
                    method: 'POST',
                    url: '/hethong/ht_quanlyphong_loadBoPhanTheoCoQuan',
                    data: { madonvi: madonvi }
                }).then(function (response) {
                    $scope.listBoPhan = response.data;
                }, function (response) {
                    alert("Lỗi không tải được danh sách phòng");
                })
              
                for (var i = 0; i < cqcon.length; i++) {
                    var ht2 = cqcon[i].getAttribute("data-hienthi");
                    if (madonvi == ht2) {
                        cqcon[i].style.display = "block";
                    }
                }
            }
        }
    }

    $scope.clickcoquancon = function () {
        var cqc = document.getElementsByClassName('clickcoquancon');
        for (var i = 0; i < cqc.length; i++) {
            cqc[i].onclick = function () {
                var madonvi = this.getAttribute("data-madonvi");
                $http({
                    method: 'POST',
                    url: '/hethong/ht_quanlyphong_loadBoPhanTheoCoQuan',
                    data: { madonvi: madonvi }
                }).then(function (response) {
                    $scope.listBoPhan = response.data;
                })
            }
        }
    }

    
    // click phong
    $scope.click_phong = function (b) {
        var maphong = b.MAPHONG;
        $scope.btn_disable = false;
        var cp = document.getElementsByClassName('click_phong');

        for (var i = 0; i < cp.length; i++) {
            cp[i].onclick = function () {
                for (var j = 0; j < cp.length; j++) {
                    cp[j].classList.remove('active_nhom');
                }
                this.classList.add('active_nhom');
            }
            
        }

        var phongg = {
            maphong: b.MAPHONG,
            tenphong: b.TENPHONG,
            madonvi: b.MADONVI
        }
        $scope.phong = phongg;
    }

    // click modal
    $scope.modal = function (state) {
        $scope.state = state;
        if (state == "add") {
            $scope.txtdisable = false;
            if ($scope.flag) {
                $scope.phong = null;
            }
        }
        else {
            $scope.txtdisable = true;
        }
        // load select coquan 
        $http({
            method: 'GET',
            url: '/hethong/ht_qlphongban_LoadCoQuanJson'
        }).then(function (response) {
            $scope.danhsachCoQuan = response.data;
            
        }, function (response) {
            alert("Lỗi không tải được danh sách cơ quan");
        })
    }

    
    // them - sua
    $scope.save = function (state) {
        $scope.phong.dvquanly = "";
        //var macoquan = $scope.selectMadonvi.Macoquan;
        if ($scope.phong.madonvi == null) {
            alert("Vui lòng chọn cơ quan quản lý");
        }
        else {
            if (state == "add") {
                console.log($scope.phong);
                $http({
                    method: 'POST',
                    url: '/hethong/ht_qlphongban_them_sua',
                    data: { type: 1, phong: $scope.phong }
                }).then(function (response) {
                    if (response.data == "1") {
                        alert("Thêm thành công");
                        $scope.flag = true;
                    }
                    else { alert("Lỗi không thêm được"); $scope.flag = false; }
                }, function () {
                    alert("Lỗi không thực được chức năng");
                })
            }
            else if (state == "edit") {
                console.log($scope.phong);
                var conf = confirm("Bạn có chắc chắn muốn cập nhật thông tin phòng vừa chọn");
                if (conf) {
                    $http({
                        method: 'POST',
                        url: '/hethong/ht_qlphongban_them_sua',
                        data: { type: 2, phong: $scope.phong }
                    }).then(function (response) {
                        if (response.data == "1") {
                            alert("Cập nhật thành công");
                        }
                        else { alert("Lỗi không cập nhật được"); }
                    }, function () {
                        alert("Lỗi không thực được chức năng");
                    })
                }
            }
        }
        
    }

})

