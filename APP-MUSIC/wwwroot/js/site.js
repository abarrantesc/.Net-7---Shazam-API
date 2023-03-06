// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



  
$(document).ready(function () {

    $('#keywdord1').on('keypress keyup keydown', function () {
        if ($('#keywdord1').val() == "") {
                
        $('#btnSearch1').prop('disabled', true);    
        $('#invalid-tooltip').css('display', 'flex');
        $('#invalid-tooltip').css('position', 'initial');

    }
    else {
        $('#btnSearch1').prop('disabled', false);
        $('#invalid-tooltip').css('display', 'none');


    }
  });
});

$("#btnSearch1").click(function (event) {
  

    ShowSpinner();

});

function ShowSpinner() {

    $('#cover-spin').show();
    window.onload = function () {
        $('#cover-spin').hide();
    }

}

