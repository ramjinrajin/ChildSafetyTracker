
$("img").hide();


$("#myModal").draggable({
    handle: ".modal-header"
});




$('#timepicker1').timepicker();
$('#timepicker2').timepicker();

$('#sm').keyup(function () {
    var len = $.trim(this.value).match(/\d/g).length;
    if (len == 5) {
        GetTrainStation();

    }
})

function GetTrainStation() {
    //GetTodayDate
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();

    var date = d.getFullYear() + '' +
        (('' + month).length < 2 ? '0' : '') + month + '' +
        (('' + day).length < 2 ? '0' : '') + day;

    //Get Train no
    var TrainNo = $('#sm').val();
    $.ajax({

        url: 'http://api.railwayapi.com/live/train/' + TrainNo + '/doj/' + date + '/apikey/jvhco9710/',
        datatype: 'json',
        method: 'GET',
        ContentType: 'application/json',
        beforeSend: function () {
            $("img").show();
        },

        success: function (data) {
            // alert('NO :16649 ' + data.position);
            // alert('Expected arival at ' + data.route[6].station_.name + ' is at' + data.route[6].actarr + ' train is ' + data.route[6].status + ' in your station');
            // alert(data.route.length);

            // CallServer(data.position, 'Expected arival at ' + data.route[38 - 1].station_.name + ' is at ' + data.route[38 - 1].actarr + ' .Train is ' + data.route[38 - 1].status + ' in your station', data.route[38 - 1].status);
            //$("#cs3").append($("<option></option>").val(1).html(data.route[37].station_.name));



            $.each(data, function (i, item) {

            });

            for (i = 0; i < data.route.length; i++) {
                $("#cs3").append($("<option></option>").val(i).html(data.route[i].station_.name));

            }

            $("img").hide();
        }


    });




}


$('#btn').click(function () {
    var temp = $('#timepicker1').text;
    alert(temp);
});