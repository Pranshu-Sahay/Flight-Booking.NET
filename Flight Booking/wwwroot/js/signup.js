document.addEventListener("DOMContentLoaded", function ()
{
    const signUpForm = document.querySelector(".signup-form");

    if (signUpForm)
    {
        signUpForm.addEventListener("submit", function (event)
        {
            event.preventDefault();

            // Retrieve sign-up data from the form
            const uid = document.getElementById("uid").value;
            const username = document.getElementById("username").value;
            const email = document.getElementById("email").value;
            const password = document.getElementById("password").value;
            const confirmPassword = document.getElementById("confirm_password").value;
            const phoneNumber = document.getElementById("phone").value;
            const dob = document.getElementById("dob").value;

            // Check if passwords match
            if (password !== confirmPassword)
            {
                alert("Passwords do not match. Please try again.");
                return;
            }

            // Check if the user already exists
            const existingUsers = JSON.parse(localStorage.getItem("users")) || [];
            const userExists = existingUsers.some(user => user.username === username || user.email === email);

            if (userExists)
            {
                alert("User with the provided username or email already exists. Please try again with different credentials.");
                return;
            }

            // Create user object
            const newUser =
            {
                uid: uid,
                username: username,
                email: email,
                password: password
            };

            // Add the new user to the existing users array
            existingUsers.push(newUser);

            // Store the updated user data in localStorage
            localStorage.setItem("users", JSON.stringify(existingUsers));

            // Redirect the user to the login page
            return RedirectToAction("Index", "Login");
        });
    } else
    {
        console.error("Sign-up form not found.");
    }
});