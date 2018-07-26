$(document).ready(function () {
    getModule();
    getuserInfo();
    //loadmodule();
    $('#idthongtincanhan').click(getInforUser());
    $('#btncapnhatthongtin').click(capnhatthongtin);
    checkemail();
    capnhatmatkhau();
    document.getElementById("btncapnhatmatkhau").addEventListener("click", change_pass);
})


function getInforUser() {
    $.ajax({
        url: '/home/nguoidung_loadthongtin',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('input[name=txttaikhoan]').val(data[0].USERNAME);
            $('input[name=txtholot]').val(data[0].HOLOT);
            $('input[name=txtten]').val(data[0].TEN);
            $('input[name=txtemail2]').val(data[0].EMAIL);
            $('#labelchucvu').text(data[0].TENCHUCVU);
        }, error: function (err) {

        }
    })
}


function getModule() {
    $.ajax({
        url: '/home/user_module_list',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var row = '';
            $.each(data, function (i, item) {
                row += '<li>';
                row += '<a class="module_chinhly" href="' + item.Links + '/' + item.Id + '">';
                //row += '<a style="cursor: pointer;" class="module_chinhly" onclick="loadmodule()" data-link="' + item.Links + '"' + 'data-idModule="' + item.Id + '">';
                row += '<div class="clearfix">';
                row += '<span class="pull-left"><i class="fa fa-archive"></i></span>';
                row += '<span class="" style="font-size: 14px; margin-left: 10px;">' + item.Modulename + '</span>';
                row += '</div>';
                row += '</a>';
                row += '</li>';
            })
            $('#menu-topchinhly').html(row);
        }, error: function (err) {
            alert("loi cmnr");
        }
    })
}

function getuserInfo() {
    $.ajax({
        url: '/home/getUserInfo',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            var link = '/assets/img/avatars/' + data[0].Fileanh;
            $('#avartaChinhly').attr('src', link);
            $('#usernamechinhly').html(data[0].Username)
        }, error: function (err) {

        }
    })
}

function logout() {

    $.ajax({
        url: '/dangnhap/dangxuat',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            //console.log(data);
            location.href = "/dangnhap/login";
        }, error: function (err) {
            location.href = "/dangnhap/login";
        }
    })
}

function capnhatthongtin() {
    conf = confirm("Bạn có chắc chắn muốn cập nhật thông tin?");
    if (conf) {
        n = {
            holot: $('input[name=txtholot]').val(),
            ten:   $('input[name=txtten]').val(),
            email: $('input[name=txtemail2]').val()
        }
        $.ajax({
            url: '/home/nguoidung_capnhatthongtin',
            type: 'POST',
            dataType: 'json',
            data: { n: n },
            success: function (data) {
                if (data == 1) {
                    alert("Cập nhật thông tin thành công");
                    $('#thongtincanhan').modal("hide");
                } else {
                    alert("Lỗi không cập nhật được thông tin");
                }
            }, error: function (err) {
                alert("Lỗi không thực hiện được chức năng này");
            }
        })
    }
    
}

function checkemail() {
    $('#email').keyup(function () {
        emailtxt = $('#email').val();
        if (!isEmail(emailtxt)) {
            $('#errEmail').removeClass("hidden-span");
            $('#btncapnhatthongtin').attr("disabled", "disabled");
        }
        else {
            $('#errEmail').addClass("hidden-span");
            check_email(emailtxt);
        }
        
    })
}
//document.getElementById("email").keyup = function () {
//    if (!isEmail(document.getElementById("email").value)) {
//        $('#errEmail').removeClass("hidden-span");
//    }
//    else {
//        $('#errEmail').addClass("hidden-span");
//    }
//}

function check_email(email) {
    $.ajax({
        url: '/home/check_email?email=' + email,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data == 1) {
                $('#errEmailTontai').removeClass('hidden-span');
                $('#btncapnhatthongtin').attr("disabled", "disabled");
            }
            else {
                $('#errEmailTontai').addClass('hidden-span');
                $('#btncapnhatthongtin').removeAttr("disabled");
            }
        }, error: function (err) {
            alert("Không kiểm tra được email vui lòng tải lại trang");
            //location.reload();
            $('#btncapnhatthongtin').attr("readonly", "readonly");
        }
    })
}

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}


function capnhatmatkhau(){
    $('#txtmkcu').keyup(function () {
        var mkcu = $('input[name=txtmkcu]').val();
        //console.log(mkcu);
        if (mkcu.length > 0) {
            $('#err_mkcuNull').addClass("hidden-span");
            $('#btncapnhatmatkhau').removeAttr("disabled");
        } else {
            $('#err_mkcuNull').removeClass("hidden-span");
            $('#btncapnhatmatkhau').attr("disabled", "disabled");
        }
    })
}


function change_pass()
{
    pass = $('input[name=txtmkcu]').val();
    $.ajax({
        url: '/home/nguoidung_doimatkhau',
        type: 'POST',
        dataType: 'json',
        data: { pass: pass },
        success: function (data) {
            if (data == 1) {
                alert("Cập nhật mật khẩu thành công thành công");
                $('#err_mkcuK').addClass("hidden-span");
                $('#doimatkhau').modal("hide");
            }
            else if(data == 0){
                //alert("Mật khẩu cũ không trùng khớp");
                $('#err_mkcuK').removeClass("hidden-span");
                //$('#btncapnhatmatkhau').attr("disabled", "disabled");
            }
            else {
                alert("Lỗi không cập nhật được thông tin");
            }
        }, error: function (err) {
            alert("Lỗi không thực hiện được chức năng này");
        }
    })
}