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

function SetFullHeight(control, adjustHeight) {
    if (control) {
        var body = document.body,
        html = document.documentElement;

        var height = Math.max(body.scrollHeight, body.offsetHeight,
                               html.clientHeight, html.scrollHeight, html.offsetHeight);

        height = height - adjustHeight;
        control.css("height", height + "px");
    }

}

var box;
function ShowPopup(sUrl, sTitle, nW, nH, sOK, fOK, sCancel, fCancel, fClose) {

    box = bootbox.dialog({
        message: '<div class="row" id="PopupContainer">Loading...</div>',
        title: sTitle,
        buttons: {
            danger: {
                label: "<i class='fa fa-remove'></i> " + sCancel,
                className: "btn-danger",
                callback: fCancel,
                icon: 'fa fa-remove'
            },
            main: {
                label: "<i class='fa fa-check'></i> " + sOK,
                className: "btn-primary",
                callback: function () {
                    var obj = GetObject();
                    fOK(obj);
                    return false;
                },
            }

        },
        onEscape: fClose
    });

    box.on("shown.bs.modal", function () {
        $('.modal-body').css("height", nH + "px");
        $('.modal-dialog').css("width", nW + "px");
        var url = sUrl;
        $.ajax({
            url: url,
            cache: false,
            success: function (html) {
                $('#PopupContainer').html(html);
            },
            error: function (html) {
                alert(html);
            }
        });
    });


    return box;
}

function ShowNotify(mess, type, timeout, icon) {

    if (isNaN(timeout))
        timeout = 1000;

    if (!type)
    {
        type = 'info';
    }

    $.gritter.add({
        // (string | mandatory) the heading of the notification
        title: '',
        // (string | mandatory) the text inside the notification
        text: mess,
        // (int | optional) the time you want it to be alive for before fading out
        time: timeout,
        // (string) specify font-face icon  class for close message
        close_icon: 'entypo-icon-cancel s12',
        // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
        icon: icon,
        // (string | optional) the class name you want to apply to that specific message
        class_name: type+'-notice'
    });
}

function GetErrorMessage(errors) {
    var mess = '<ul>';

    var p = errors;
    for (var key in p) {
        if (p.hasOwnProperty(key)) {
            mess += '<li>' + p[key].errors + '</li>';
        }
    }

    mess += '</ul>';
    return mess;
}

///
//------------- notifications.js -------------//
$(document).ready(function () {

    ////------------- Title notifications -------------//
    //$('#add-notification').click(function () {
    //    titlenotifier.add();
    //});
    //$('#subsctract-notification').click(function () {
    //    titlenotifier.sub();
    //});
    //$('#number-notification').click(function () {
    //    titlenotifier.set(5);
    //});
    //$('#reset-notification').click(function () {
    //    titlenotifier.reset();
    //});

    ////------------- Gritter notices -------------//

    ////info notice
    //$('#regular-notice').click(function () {
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Jonh Doe',
    //        // (string | mandatory) the text inside the notification
    //        text: 'User is just logged into system.',
    //        // (string | optional) the image to display on the left
    //        image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //    });
    //});

    ////info notice
    //$('#info-notice').click(function () {
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Email send',
    //        // (string | mandatory) the text inside the notification
    //        text: 'Just let you know, you send last email without problems',
    //        // (int | optional) the time you want it to be alive for before fading out
    //        time: '',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //        // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
    //        icon: 'fa fa-envelope',
    //        // (string | optional) the class name you want to apply to that specific message
    //        class_name: 'info-notice'
    //    });
    //});

    //success notice
    $('#success-notice').click(function () {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Done !!!',
            // (string | mandatory) the text inside the notification
            text: 'You successfull delete 13 files.<br> <a href="#" class="btn btn-xs btn-default mt10">Roll back</a>',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'eco-trashcan',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'success-notice'
        });
    });

    //warning notice
    //$('#warning-notice').click(function () {
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Warrning !!!',
    //        // (string | mandatory) the text inside the notification
    //        text: '22 users closed their accounts, due to spam issues on server.',
    //        // (int | optional) the time you want it to be alive for before fading out
    //        time: '',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //        // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
    //        icon: 'icomoon-icon-user',
    //        // (string | optional) the class name you want to apply to that specific message
    //        class_name: 'warning-notice'
    //    });
    //});

    ////error notice
    //$('#error-notice').click(function () {
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Error',
    //        // (string | mandatory) the text inside the notification
    //        text: 'User Jonh Doe is not added to database.',
    //        // (int | optional) the time you want it to be alive for before fading out
    //        time: '',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //        // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
    //        icon: 'icomoon-icon-user-plus-2',
    //        // (string | optional) the class name you want to apply to that specific message
    //        class_name: 'error-notice'
    //    });
    //});

    ////sticky notice
    //$('#sticky-notice').click(function () {
    //    var unique_id = $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Jonh Doe',
    //        // (string | mandatory) the text inside the notification
    //        text: 'I just send you email, please check it out and tell me what you think',
    //        // (string | optional) the image to display on the left
    //        image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
    //        // (bool | optional) if you want it to fade out on its own or just sit there
    //        sticky: true,
    //        // (int | optional) the time you want it to be alive for before fading out
    //        time: '',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //        // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
    //    });
    //});

    //$('#topleft-notice').click(function () {
    //    $.extend($.gritter.options, {
    //        position: 'top-left',
    //    });
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Jonh Doe',
    //        // (string | mandatory) the text inside the notification
    //        text: 'User is just logged into system.',
    //        // (string | optional) the image to display on the left
    //        image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //        sticky: true,
    //    });
    //});

    //$('#bottomleft-notice').click(function () {
    //    $.extend($.gritter.options, {
    //        position: 'bottom-left',
    //    });
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Jonh Doe',
    //        // (string | mandatory) the text inside the notification
    //        text: 'User is just logged into system.',
    //        // (string | optional) the image to display on the left
    //        image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //    });
    //});

    //$('#bottomright-notice').click(function () {
    //    $.extend($.gritter.options, {
    //        position: 'bottom-right',// possibilities: bottom-left, bottom-right, top-left, top-right
    //    });
    //    $.gritter.add({
    //        // (string | mandatory) the heading of the notification
    //        title: 'Jonh Doe',
    //        // (string | mandatory) the text inside the notification
    //        text: 'User is just logged into system.',
    //        // (string | optional) the image to display on the left
    //        image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
    //        // (string) specify font-face icon  class for close message
    //        close_icon: 'entypo-icon-cancel s12',
    //    });
    //});

    //------------- Sweet alerts -------------//
    //document.querySelector('.sweet-1').onclick = function () {
    //    swal("Here's a message!");
    //};

    //document.querySelector('.sweet-2').onclick = function () {
    //    swal("Here's a message!", "It's pretty, isn't it?");
    //};

    //document.querySelector('.sweet-3').onclick = function () {
    //    swal("Good job!", "You clicked the button!", "success");
    //};

    //document.querySelector('.sweet-4').onclick = function () {
    //    swal({
    //        title: "Are you sure?",
    //        text: "You will not be able to recover this imaginary file!",
    //        type: "warning",
    //        showCancelButton: true,
    //        confirmButtonClass: 'btn-danger',
    //        confirmButtonText: 'Yes, delete it!',
    //        closeOnConfirm: false
    //    },
    //    function () {
    //        swal("Deleted!", "Your imaginary file has been deleted!", "success");
    //    });
    //};

    //document.querySelector('.sweet-5').onclick = function () {
    //    swal({
    //        title: "Are you sure?",
    //        text: "You will not be able to recover this imaginary file!",
    //        type: "warning",
    //        showCancelButton: true,
    //        confirmButtonClass: 'btn-danger',
    //        confirmButtonText: 'Yes, delete it!',
    //        cancelButtonText: "No, cancel plx!",
    //        closeOnConfirm: false,
    //        closeOnCancel: false
    //    },
    //    function (isConfirm) {
    //        window.console.log('fuck', isConfirm);
    //        if (isConfirm) {
    //            swal("Deleted!", "Your imaginary file has been deleted!", "success");
    //        } else {
    //            swal("Cancelled", "Your imaginary file is safe :)", "error");
    //        }
    //    });
    //};

    //document.querySelector('.sweet-6').onclick = function () {
    //    swal({
    //        title: "Sweet!",
    //        text: "Here's a custom image.",
    //        imageUrl: 'img/thumbs-up.jpg'
    //    });
    //};

});

