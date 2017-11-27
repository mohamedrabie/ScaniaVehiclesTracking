


var hostUrl = 'http://localhost:17645/';
var apiUrl = hostUrl + 'api/';


$(document).ready(function () {

    initialize();

    $("#btn-status :input").change(function () {

        searchVehicles();
    });


    $('#ddl-customer').on('change', function () {
        OnCustomerChanged(this.value);
    })

});


function initialize() {
    $.ajax({
        url: hostUrl + 'oauth/token',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded',
        type: 'POST',
        data: {
            "username": "user1",
            "password": "123",
            "grant_type": "password"
        },
        error: function () {
            // error handler
        },
        success: function (data) {
            debugger;
            if (window.sessionStorage) {
                sessionStorage.setItem("accessToken", data.access_token);
            }

            GetCustomersList();
            GetAllVehciles();
        }
    });

}

function getServiceUrl() {

    var statusId = $('#btn-status input[type="radio"]:checked').val();;

    var customerId = $("#ddl-customer :selected").val();

    var serviceUrl = apiUrl + 'Vehicle/Get';

    if (statusId > 0 && customerId > 0) {

        serviceUrl = apiUrl + 'Vehicle/SearchVehicles?customerId=' + customerId + '&status=' + statusId
    }
    else if (customerId > 0) {

        serviceUrl = apiUrl + 'Vehicle/GetByCustomer/' + customerId
    }
    else if (statusId > 0) {

        serviceUrl = apiUrl + 'Vehicle/GetByStatus/' + statusId
    }
    else {
        serviceUrl = apiUrl + 'Vehicle/Get';
    }
    return serviceUrl;
}

function searchVehicles() {

    var serviceUrl = getServiceUrl();

    renderGrid(serviceUrl);

}
function GetAllVehciles() {

    renderGrid(apiUrl + 'Vehicle/Get');

}
function GetCustomersList() {

    $.ajax({
        type: 'GET',
        url: apiUrl + 'Customer/Get',
        headers: { Authorization: "Bearer " + sessionStorage.getItem("accessToken") },
    }).done(function (data) {

        var options = "";

        options = "<option value='-1'>All</option>";

        $.each(data, function (a, b) {
            options += "<option value='" + b.CustomerId + "'>" + b.CustomerName + "</option>";
        });

        $("#ddl-customer").html(options);

    }).error(function (jqXHR, textStatus, errorThrown) {
        alert(jqXHR.responseText || textStatus);
    });
}

function OnCustomerChanged(selectedValue) {
    searchVehicles();
}

function renderGrid(url) {

    $("#tblVehicles").jsGrid({
        height: 300,
        width: "100%",

        autoload: true,
        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: url,
                    dataType: "json",
                    headers: { Authorization: "Bearer " + sessionStorage.getItem("accessToken") },
                });
            },
        },
        fields: [
            { name: "CustomerName", title: "Customer Name", type: "text" },
            { name: "RegistrationNo", title: "Registration No", type: "text" },
            { name: "VehicleId", title: "Vehicle Id", type: "text" },
            {
                name: "VehicleStatus", itemTemplate: function (value) {
                    if (value == "1") {
                        return "<i class='fa fa-truck fa-lg text-success' aria-hidden='true'></i>";
                    }
                    else if (value == "2") {
                        return "<i class='fa fa-truck fa-lg text-danger' aria-hidden='true'></i>";
                    }

                    return "<i class='fa fa-truck fa-lg text-default' aria-hidden='true'></i>";

                }, title: "Vehicle Status", type: "text", width: 50
            }
        ]
    });
}




