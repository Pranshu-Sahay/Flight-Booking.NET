// Function to toggle form container visibility
function toggleFormContainer() {
    const formContainer = document.getElementById('formContainer');
    formContainer.classList.toggle('active'); // Toggle the 'active' class
}

// Event listener for clicking on the class options
document.querySelectorAll(".booking__nav .class-option").forEach(option => {
    option.addEventListener("click", function () {
        handleClassOptionClick(option);
        toggleFormContainer(); // Toggle form container visibility
        // Show the form when a class option is clicked
    });
});

// Function to handle class option click
function handleClassOptionClick(option) {
    // Reset all options to default style
    const classOptions = document.querySelectorAll(".booking__nav .class-option");
    classOptions.forEach(opt => {
        opt.classList.remove("selected");
        opt.style.backgroundColor = "var(--extra-light)";
        opt.style.color = "var(--text-light)";
    });

    // Apply selected style to the clicked option
    option.classList.add("selected");
    option.style.backgroundColor = "var(--primary-color)";
    option.style.color = "var(--white)";

    // Update summary with selected class name and form details
    const className = option.textContent;
    updateSummary(className);
}

// Event listener for Air India class option
const airIndiaClassOption = document.querySelector('.air-india');
airIndiaClassOption.addEventListener('click', () => {
    handleAirlineClassSelection(airIndiaClassOption);
});

// Event listener for IndiGo class option
const indigoClassOption = document.querySelector('.indigo');
indigoClassOption.addEventListener('click', () => {
    handleAirlineClassSelection(indigoClassOption);
});

// Event listener for Vistara class option
const vistaraClassOption = document.querySelector('.vistara');
vistaraClassOption.addEventListener('click', () => {
    handleAirlineClassSelection(vistaraClassOption);
});

// Function to handle the selection of airline class option
function handleAirlineClassSelection(option) {
    if (firstLoad) {
        firstLoad = false;
        insertFormHTML();
    } else {
        setTimeout(() => {
            document.getElementById('formContainer').style.opacity = '0'; // Hide the form container before reloading
            setTimeout(() => {
                insertFormHTML();
            }, 500); // Wait for the animation duration before reloading
        }, 3000); // 3-second delay
    }
}

// Function to insert form HTML
function insertFormHTML() {
    const formContainer = document.getElementById('formContainer');
    // Trigger reflow to apply the animation
    void formContainer.offsetWidth;
    formContainer.style.opacity = '1'; // Show the form container after reflow
}

// Function to update summary table with the selected class name
function updateSummary(className) {
    const summaryClassName = document.getElementById('summaryClassName');
    summaryClassName.textContent = className;
}

let firstLoad = true;



// Declare the selectedOptionsTable variable
//const selectedOptionsTable = document.getElementById('selectedOptions');

/// Function to update the summary table with the selected class name and form details
//function updateSummary(className, departure, destination, travellers, departureDate, price, action) {
//    // Clear existing rows
//    selectedOptionsTable.innerHTML = '';

//    // Create a new row with the selected class name and form details
//    const row = document.createElement('tr');
//    row.innerHTML = `
//        <td>${className}</td>
//        <td></td>
//        <td></td>
//        <td>${travellers}</td >
//        <td></td>
//        <td></td>
//        <td></td>
//   `;

    //// Create the "Book" button
    //const bookButton = document.createElement('button');
    //bookButton.classList.add('book-btn');
    //bookButton.textContent = 'Book';

    //// Add an event listener to the button if an action is provided
    //if (action) {
    //    bookButton.addEventListener('click', action);
    //}

    //// Append the button to the last column
    //const actionColumn = row.querySelector('td:last-child');
    //actionColumn.appendChild(bookButton);

    //// Append the new row to the table body
    //selectedOptionsTable.appendChild(row);
}


//// Function to clear form inputs
//function clearFormInputs() {
//    document.getElementById('departureInput').value = '';
//    document.getElementById('destinationInput').value = '';
//    document.querySelector('input[type="number"]').value = '';
//    document.getElementById('departureDate').value = '';
//    document.getElementById('returnDate').value = '';
//}



// Function to handle form submission
function handleFormSubmission(event) {
    if (event) {
        event.preventDefault(); // Prevent form submission if event exists
    }

    if (!isAuthenticated()) {
        // If not authenticated, redirect to the login page
        window.location.href = 'login';
        return; // Stop further execution
    }

    // Update summary with latest form details
    const selectedClass = document.querySelector(".booking__nav .class-option.selected");
    if (selectedClass) {
        handleClassOptionClick(selectedClass);
    }

    // Clear the form inputs
    clearFormInputs();
}






//// Function to clear the summary table
//function clearSummaryTable() {
//    selectedOptionsTable.innerHTML = '';
//}

// Event listener for clicking on the search button
// Event listener for clicking on the search button





//document.querySelector('form').addEventListener('submit', handleFormSubmission);

//document.querySelector('form').addEventListener('submit', function (event)
//{
//    event.preventDefault(); // Prevent form submission

//function selectOption(value, inputId) {
//    const inputElement = document.getElementById(inputId);
//    inputElement.value = value;
//    const optionsContainer = document.getElementById(inputId + 'Options');
//    if (optionsContainer) {
//        optionsContainer.classList.remove('active'); // Hide options after selection
//    } else {
//        console.error('Options container not found:', inputId + 'Options');
//    }
//}








    document.addEventListener("DOMContentLoaded", function ()
    {
        document.getElementById("home-link").addEventListener("click", function (event)
        {
        event.preventDefault();
        document.querySelector('#home').scrollIntoView
            ({
                behavior: 'smooth'
            });
        });
    });



    document.addEventListener("DOMContentLoaded", function ()
    {
        document.getElementById("book-link").addEventListener("click", function (event)
        {
        event.preventDefault();
        document.querySelector('#book').scrollIntoView
            ({
                behavior: 'smooth'
            });
        });
    });


    document.addEventListener("DOMContentLoaded", function ()
    {
        document.getElementById("about-link").addEventListener("click", function (event)
        {
            event.preventDefault();
            document.querySelector('#about').scrollIntoView
            ({
                behavior: 'smooth'
            });
        });
    });


    document.addEventListener("DOMContentLoaded", function ()
    {
        document.getElementById("contact-link").addEventListener("click", function (event)
        {
            event.preventDefault();
            document.querySelector('#contact').scrollIntoView
            ({
                behavior: 'smooth'
            });
        });
    });
    //// Retrieve form input values
    //const departure = document.getElementById('departureInput').value;
    //const destination = document.getElementById('destinationInput').value;
    //const travellers = document.querySelector('input[type="number"]').value;
    //const departureDate = document.getElementById('departureDate').value;
    //const returnDate = document.getElementById('returnDate').value;

    //// Update localStorage with form input values
    //localStorage.setItem('departure', departure);
    //localStorage.setItem('destination', destination);
    //localStorage.setItem('travellers', travellers);
    //localStorage.setItem('departureDate', departureDate);
    //localStorage.setItem('returnDate', returnDate);

    // Update summary with latest form details
//    const selectedClass = document.querySelector(".booking__nav .class-option.selected");
//    if (selectedClass) {
//        handleClassOptionClick(selectedClass);
//    }

//    // Reset the form
//    document.querySelector('form').reset();
//});

//// Function to handle page load
//document.addEventListener("DOMContentLoaded", function ()
//{
//    // Clear the form inputs and summary table
//    clearformContainer();
//    clearSummaryTable();

//    //// Check if the user is authenticated
//    //const username = localStorage.getItem("username");
//    //if (username) {
//    //    // If authenticated, update the navigation buttons with the username
//    //    updateNavigationButtons(username);
//    //}
//});


//// Function to check if user is authenticated
//function isAuthenticated()
//{
//    // Check if the user is authenticated (e.g., by checking for a stored token)
//    // Return true if authenticated, false otherwise
//    const username = localStorage.getItem('Username');

//    return !!username; // Return true if username exists, false otherwise
//}



//// Function to update navigation buttons based on authentication status
//function updateNavigationButtons(username) {
//    const loginButtons = document.querySelector('.Log_in');
//    if (username) {
//        // If authenticated, show welcome message and logout button
//        loginButtons.innerHTML = `<p>Welcome, ${username}</p><button id="logoutBtn" class="btn">Logout</button>`;
//        // Add event listener for logout button
//        document.getElementById('logoutBtn').addEventListener('click', function () {
//            localStorage.removeItem('username');
//            // Redirect to the login page
//            window.location.href = 'Index.html';
//        });
//    } else {
//        // If not authenticated, show login and sign up buttons
//        loginButtons.innerHTML = `
//            <a asp-controller="login" asp-action="Index" class="btn">Log In</a>
//            <a asp-controller="SignUp" asp-action="Index" class="btn">Sign Up</a>
//        `;
//    }
//}







