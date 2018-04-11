$(function () {
   // $('.edit').hide();
    /*$('.confirm-case').on('click', function () {
        var tr = $(this).parents('tr:first');
        tr.find('.edit, .read').toggle();
    });*/
    $('.confirm-case').on('click', function (e) {
        e.preventDefault();
        var tr = $(this).parents('tr:first');
        id = $(this).prop('id');
        //var gender = tr.find('#Gender').val();
        //var email = tr.find('#Email').val();
        //var confirmedFlag = "True"
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:55627/Default2/Edit",
            data: JSON.stringify({ "id": id, "gender": gender, "phone": phone }),
            dataType: "json",
            success: function (data) {
                tr.find('.edit, .read').toggle();
                $('.edit').hide();
                tr.find('#gender').text(data.person.Gender);
                tr.find('#phone').text(data.person.Phone);
            },
            error: function (err) {
                alert("error");
            }
        });
    });