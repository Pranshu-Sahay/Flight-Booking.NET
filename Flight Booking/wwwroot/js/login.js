//document.addEventListener("DOMContentLoaded", function () {
//    //const loginForm = document.querySelector(".login-form");

//    //if (loginForm) {
//    //    loginForm.addEventListener("submit", function (event) {
//    //        event.preventDefault();

//    //        // Retrieve username and password from the form
//    //        const uid = document.getElementById("uid").value;
//    //        const username = document.getElementById("username").value;
//    //        const password = document.getElementById("password").value;

//    //        // Retrieve existing users from localStorage
//    //        const existingUsers = JSON.parse(localStorage.getItem("users")) || [];

//    //        // Check if the entered username and password match with any existing user
//    //        const user = existingUsers.find(user => user.username === username && user.password === password);

//    //        if (user)
//    //        {
//    //            // Store the username in localStorage for future use
//    //            localStorage.setItem("username", username);

//    //            // Redirect the user to the main page
//    //            return RedirectToAction("Index", "Home");
//    //        } else
//    //        {
//    //            // Display an error message or handle authentication failure
//    //            alert("Invalid username or password. Please try again.");
//    //        }
//    //    });
//    //} else
//    //{
//    //    console.error("Login form not found.");
//    //}
//});