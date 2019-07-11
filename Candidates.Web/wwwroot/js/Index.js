$(() => {
    $("#confirm").on('click', function () {
        var Id = $(this).data('id');
        UpdateStatus(Id, true);  
    });

    $("#decline").on('click', function () {
        var Id = $(this).data('id');
        UpdateStatus(Id, false);
            
        alert('hit');
    });

    function UpdateStatus(Id, Confirmed) {
        $.post('/home/updateStatus', { Id: Id, Confirmed: Confirmed }, function (ViewBag) {
            $(".update-status").prop('disabled', true);
            $("#pending").text(ViewBag.Pending);
            $("#confirmed").text(ViewBag.Confirmed);
            $("#declined").text(ViewBag.Declined);
        });
    }

    $(".toggle").on('click', function () {
        $(".notes").toggle();
    });
});