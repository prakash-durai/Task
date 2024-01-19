const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Import cors module

const app = express();
const port = process.env.PORT || 3000;

app.use(cors()); // Enable CORS for all routes
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.post('/submit-form', (req, res) => {
    // Process the form data received from the client
    const username = req.body.username;
    const email = req.body.email;

    // Perform necessary actions (e.g., save to a database)

    // Respond with a JSON message
    res.json({ message: 'Form submitted successfully!', username, email });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
