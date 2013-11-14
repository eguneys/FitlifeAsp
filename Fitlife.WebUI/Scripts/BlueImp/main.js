$(function () {
    $('#fileupload').fileupload({
        send: function (e, options) {
            options.headers = {
                'Authorization': 'Client-ID c497c0dc511a4fa'
            }
        },
        done: function (e, data) {
            $('#fileuploadbutton').trigger('uploadRequest', data);


        },
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#fileuploadprogress').css('width', progress + '%');
        },
        add: function (e, data) {
            // data.context = $("<p/>").text("Uploading").appendTo(document.body);
            $("#fileuploadbutton").toggle('visible').click(function () {
                data.submit();
            });
        }
    });
});

$(function () {
    $("#photolinedatepicker").datepicker();

    $("#photolinedatepicker").datepicker("setDate", moment().format("l"));


});

$(function () {
    $('#fileuploaduserphoto').fileupload({
        send: function (e, options) {
            options.headers = {
                'Authorization': 'Client-ID c497c0dc511a4fa'
            }
        },
        done: function (e, data) {
            var response_obj = {
                photo: data.result.data.link
            }
         
            $.post("User/ChangePicture", response_obj, function (data) {
                console.log(data);
            });
            


        },
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#fileuploaduserphotoprogress').css('width', progress + '%');
            $('#userphotoprogress').text(progress + "%");
        }
    });
});
