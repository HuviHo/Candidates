$(() => {
    $(".update-status").on('click', function () {
        var Id = $(this).data('id');
        var Confirmed = true;

        if ($(this).attr("id") == 'decline') {
            alert('declined');
            Confirmed === false;
        };

        $.post('/home/updateStatus', { Id: Id, Confirmed: Confirmed }, function (ViewBag) {
            $(".update-status").prop('disabled', true);
            $("#pending").text(ViewBag.Pending);
            $("#confirmed").text(ViewBag.Confirmed);
            $("#declined").text(ViewBag.Declined);
        });
    });

    $(".toggle").on('click', function () {
        $(".notes").toggle();
    });
});