$(document).ready(function () {

    // Fires when user clicks on a student
    // Updates advising area with student information
    $(document).on("click", ".enrollment-student-row", function () {
        $('#enrollment-student-enrollment-body').html($('#enrollment-student-loading').html());


        $(".enrollment-student-active").removeClass("danger");
        $(".enrollment-student-active").removeClass("enrollment-student-active");
        $(this).addClass("enrollment-student-active");
        $(this).addClass("danger");

        var data = {studentId: $(this).attr("data-student-id")};
        $.ajax({
            type: "GET",
            data: data,
            url: "/Enrollment/_StudentEnrollment",
            success: function (data) {

                $('#enrollment-student-enrollment-body').html(data);

                $.ajax({
                    type: "GET",
                    url: "/Enrollment/_StudentEnroll",
                    success: function (data) {

                       $('#enrollment-student-enroll').html(data);


                    },
                    error: function (data) {
                        alert('error');

                    }
                })



            },
        error: function (data) {
            alert('error');

        }
    })
})
})