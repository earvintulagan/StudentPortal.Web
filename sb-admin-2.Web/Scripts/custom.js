$(document).ready(function () {

    $("#Question").validate({
        rules: {
            Studentnum: {
                required: true
            },
            Email: {
                required: true
            },
            
            Subject: {
                required: true
                
            },
            Content: {
                required: true
            }

        },
        messages: {
            Studentnum:"Please provide you student number",
            Email: "Please provide your Email",
            Subject: "Please provide a Subject",
            Content: "Please enter your concern"
        },

        submitHandler: function (form) {
            var url = $(form).attr("action");
            var data = $(form).serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (res) {
                    
                },
                error: function (res) {

                }
            });

        }


    });

    
});