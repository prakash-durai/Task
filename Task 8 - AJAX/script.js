function submitForm() {
    // Get form data
    const formData = new FormData(document.getElementById('myForm'));

    // Make an AJAX request using the fetch API
    fetch('http://localhost:3000/submit-form', {
        method: 'POST',
        body: formData
    })
    .then(response => response.json())
    .then(data => {
        // Handle the response data
        console.log(data);
    })
    .catch(error => {
        // Handle errors
        console.error('Error:', error);
    });
}