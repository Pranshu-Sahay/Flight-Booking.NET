// Function to toggle form container visibility
function toggleFormContainer()
{
    const formContainer = document.getElementById('formContainer');
    formContainer.classList.toggle('active'); // Toggle the 'active' class
}

// Event listener for clicking on the class options
document.querySelectorAll(".booking__nav .class-option").forEach(option =>
{
    option.addEventListener("click", function () {
        handleClassOptionClick(option);
        toggleFormContainer(); // Toggle form container visibility
        // Show the form when a class option is clicked
    });
});

// Function to handle class option click
function handleClassOptionClick(option)
{
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



document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("home-link").addEventListener("click", function (event) {
        event.preventDefault();
        document.querySelector('#home').scrollIntoView
            ({
                behavior: 'smooth'
            });
    });
});



document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("book-link").addEventListener("click", function (event) {
        event.preventDefault();
        document.querySelector('#book').scrollIntoView
            ({
                behavior: 'smooth'
            });
    });
});


document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("about-link").addEventListener("click", function (event) {
        event.preventDefault();
        document.querySelector('#about').scrollIntoView
            ({
                behavior: 'smooth'
            });
    });
});


document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("contact-link").addEventListener("click", function (event) {
        event.preventDefault();
        document.querySelector('#contact').scrollIntoView
            ({
                behavior: 'smooth'
            });
    });
});