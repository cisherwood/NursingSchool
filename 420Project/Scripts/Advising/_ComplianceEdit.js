// Compliance Edit
$(document).ready(function () {
    $(document).on('click', '.advising-compliance-edit', function () {

        var data = { id: $(this).attr("data-student-compliance-id") }

        $.ajax({
            type: "GET",
            data: data,
            url: "/Advising/_ComplianceEdit",
            success: function (data) {
                $('#AdvisingModalBody').hide();
                $('#AdvisingModalBody').removeClass("hidden");
                $('#AdvisingModalBody').html(data);
                $('#AdvisingModalBody').show('fade', { duration: 300, easing: 'easeInCirc' });
            },
            error: function (data) {
                alert('error');

            }
        })
    });

})
