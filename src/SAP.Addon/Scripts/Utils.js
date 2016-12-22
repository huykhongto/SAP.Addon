$(document).ready(function () {
    $(".mask-phone").mask("(999) 999-9999", { completed: function () { } });
    $(".datepicker").datepicker();
    $('.tree').treegrid();
    $('.datatable').DataTable();
    //InitMenuEvents();
    $('select, input, textarea').each(function(){
        if (!$(this).hasClass('form-control'))
            $(this).addClass('form-control');
    });

    $('.toggle input[type=checkbox]').click(function () {
        var isChecked = $(this).val().toLowerCase();
        if(isChecked == 'true')
            $(this).val(isChecked != "false");
        else
            $(this).val(isChecked != "true");
    });

    $('.delete-item').click(function (e) {
        e.preventDefault();
        var btn = $(this);
        ConfirmDialog('Xác nhận', 'Bạn có chắc chắn muốn '+btn.attr('title')+'?', 'warning', function () {
            DoDelete(btn.attr('href'), function () {
                btn.closest('tr').hide();
                swal("Đã xóa!", btn.attr('title'));
            });
        }, function () {
            //alert('cancel');
        });
    });
    return false;
});

function DoDelete(link, success_func,fail_func)
{
    //nsole.log(link);
    setTimeout(function () {
        $.ajax({
            url: link,
            type: "GET",
            success: function (data, status)
            {
                if (data.success == 1)
                    if (success_func)
                        success_func();
                    else
                        if(fail_func)
                            fail_func();
            }
        });
    }, 200);
}

function InitMenuEvents()
{
    $('.mainnav .partial-page').click(function (e) {
        //alert('ok');
        var url = $(this).attr('href');
        var innerHtml = $(this).html();
        if (url != "" && url != "#") {
            $.ajax({
                url: url,
                success: function (data) {
                    var html = data;
                    $('#main-container').html(html);
                    $('#heading-title').html(innerHtml);
                    },
                error: function () {
                    $('#heading-title').html(innerHtml);
                }
            });
        }

            
        return false;
    });
}



function ConfirmDialog(title, text, type, yes_func, no_func)
{
    swal({
        title: title,
        text: text,
        type: type,
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Đúng",
        cancelButtonText: "Hủy",
        closeOnConfirm: true,
        closeOnCancel: true
    },

    function (isConfirm) {
        if (isConfirm) {
            yes_func();
        } else {
            no_func();
        }
    });
}