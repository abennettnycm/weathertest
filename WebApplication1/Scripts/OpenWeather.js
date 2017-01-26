$(document).ready(function () {
    $("#formSubmit").click(function (e) {
        $.ajax({
            url: "/Example/WeatherFetch",
            type: "POST",
            data: {
                zip: $("[name='zip']").val()
            },
            cache: false
        }).done(function (dataReturned) {
            var jsonResult = $.parseJSON(dataReturned.response);
            
            $("#weatherResult").html("<img src='http://openweathermap.org/img/w/" + jsonResult.weather[0].icon + ".png'> The current weather is " + jsonResult.weather[0].main + ", " + jsonResult.weather[0].description + " and the temperature is " + jsonResult.main.temp + "&#176; Fahrenheit");
        })
    });
});