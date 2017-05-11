/// <reference path="C:\Users\chouhan's\Documents\Visual Studio 2015\Projects\IntroducationToWebAPI\TokenAuthentication\Scripts/jquery-1.10.2.min.js" />

function getaccesstoken() {
    debugger;
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            console.log("issue register");
            var accesstoken = location.hash.split('access_token=')[1].split('&')[0];
            if (accesstoken) {

                isuserReigster(accesstoken);
            }

        }
    }

}

function isuserReigster(accesstoken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accesstoken 

        },
        success: function (response) {
            console.log("issue register");
            if (response.HasRegistered) {
                localStorage.setItem('accessToken', accesstoken);
                localStorage.setItem('userName', response.Email);
                window.location.href = "Data.html";
            }
            else {
                singupExternalUser(accesstoken,response.LoginProvider);
            }
        }

        
    })

}


function singupExternalUser(accesstoken,provider) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accesstoken

        },
        success: function () {
            console.log("issue register");
            window.location.href = "/api/Account/ExternalLogin?provider="+provider+"&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A60418%2FLogin.html";


        }


    })

}


