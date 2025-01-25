
function passwordValid(password) {
    if ((password.length >= 6 && password.length <= 10) 
        && /^[A-Za-z0-9]+$/.test(password)
        && (password.match(/\d/g) || []).length >= 2) {
            console.log("Password is valid");
        }
    else {
        if (password.length < 6 || password.length > 10) {
            console.log("Password must be between 6 and 10 characters");
        }
        if (!/^[A-Za-z0-9]+$/.test(password)) {
            console.log("Password must consist only of letters and digits");
        }
        if ((password.match(/\d/g) || []).length < 2) {
            console.log("Password must have at least 2 digits");
        }
    } 
}