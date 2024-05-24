//document.addEventListener('DOMContentLoaded', function ()
//{
//    //// Retrieve form input values from localStorage
//    //const departure = localStorage.getItem('departure');
//    //const destination = localStorage.getItem('destination');
//    //const travellers = localStorage.getItem('travellers');
//    //const departureDate = localStorage.getItem('departureDate');
//    //const returnDate = localStorage.getItem('returnDate');

//    // Create a new table row
//    const newRow = document.createElement('tr');
//    newRow.innerHTML = `
//        <td>${UserId}</td>
//        <td>${Username}</td>
//        <td>${PhoneNumber}</td>
//        <td>${EmailId}</td>
//        <td>${DOB}</td>
//        <td>${departure}</td>
//        <td>${destination}</td>
//        <td>${travellers}</td>
//        <td>${departureDate}</td>
//        <td>${returnDate}</td>
//        <td><button class="cancel-btn">Cancel</button></td>
//    `;

//    // Append the new row to the table body
//    const tbody = document.querySelector('tbody');
//    tbody.appendChild(newRow);

//    // Add event listener to each "Cancel" button
//    const cancelButtons = document.querySelectorAll('.cancel-btn');
//    cancelButtons.forEach(function (cancelButton) {
//        cancelButton.addEventListener('click', function () {
//            const rowToRemove = this.closest('tr');
//            rowToRemove.remove();
//        });
//    });
//});