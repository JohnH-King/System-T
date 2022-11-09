// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// View and hide password for sign up page 
function ViewpasswordSignup(){
    document.getElementById("ViewPasswordSignup").style.display = "none";
    document.getElementById("HidepasswordSignup").style.display = "block";
    document.getElementById("passwordSignup").type = "text";
}

function HidePaswordSignup(){
    document.getElementById("ViewPasswordSignup").style.display = "block";
    document.getElementById("HidepasswordSignup").style.display = "none";
    document.getElementById("passwordSignup").type = "password";
}

// view and hide passwords for login page
function Viewpassword(){
    document.getElementById("ViewPassword1").style.display = "none";
    document.getElementById("Hidepassword1").style.display = "block";
    document.getElementById("passwordLogin").type = "text";
}

function HidePasword(){
    document.getElementById("ViewPassword1").style.display = "block";
    document.getElementById("Hidepassword1").style.display = "none";
    document.getElementById("passwordLogin").type = "password";
} 

function Test(){
    alert("test");
}