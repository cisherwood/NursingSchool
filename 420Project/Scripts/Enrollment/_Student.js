$(document).ready(function () {
    alert('rea');
    // Fires when user clicks on a student
    // Updates advising area with student information
    $(document).on("click", ".enrollment-student-row", function () {
        $('#enrollment-student-enrollment-body').hide('fade', { duration: 100, easing: 'easeInCirc' });
        $(".enrollment-student-active").removeClass("danger");
        $(".enrollment-student-active").removeClass("enrollment-student-active");
        $(this).addClass("enrollment-student-active");
        $(this).addClass("danger");

        var data = {id: $(this).attr("data-student-id")};

        $.ajax({
            type: "GET",
            data: data,
            url: "/Enrollment/_StudentEnrollment",
            success: function (data) {
                $('#enrollment-student-enrollment-body').removeClass("hidden");
                $('#enrollment-student-enrollment-body').show('fade', { duration: 300, easing: 'easeInCirc' });
                $('#enrollment-student-enrollment-body').html(data);
            },
        error: function (data) {
            alert('error');

        }
    })
})
})