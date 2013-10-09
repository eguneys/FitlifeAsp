$(function () {
    $('#fileupload').fileupload({
        send: function (e, options) {
            options.headers = {
                'Authorization': 'Client-ID c497c0dc511a4fa'
            }
        },
        done: function (e, data) {
            var response_obj = {
            UserID: 1,
                Date: moment().format(),
                PhotoSource: data.result.data.link,
                MuscleGroup: 'chest'
            }
            $.post("api/ProgressApi", response_obj, function () {

            }).done(function () {
                console.log('done');
            });
        }
    });
})