let firstName = document.getElementsByClassName('firstName')[0];
let lastName = document.getElementsByClassName('lastName')[0];
let date = document.getElementsByClassName('dateOfBirth')[0];
let acceptBtn = document.getElementsByClassName('acceptBtn')[0];
let form = document.getElementsByClassName('form')[0];
let errorName = document.getElementsByClassName('errorName')[0];
let errorlastName = document.getElementsByClassName('errorLastName')[0];
let errorDOB = document.getElementsByClassName('errorDOB')[0];

function validator(){

    var dateInput = date.value;
    var dateEntered = new Date(dateInput);
    
    if(firstName.value == "" || firstName.value.length > 50){
        event.preventDefault();
        
        firstName.focus();
        
        errorName.style.color = 'red';
        errorName.textContent = 'Поле не может быть пустым, не более 50 символов';
        errorName.style.fontStyle = "italic";
        errorName.style.fontSize = 14;
        form.insertBefore(errorName, firstName.nextSibling);
    }
    else{
        errorName.textContent = '';
    }
    
    if(lastName.value == "" || lastName.value.length > 50){
        event.preventDefault();
        lastName.focus();
        errorlastName.style.color = 'red';
        errorlastName.textContent = 'Поле не может быть пустым, не более 50 символов';
        errorlastName.style.fontStyle = "italic";
        errorlastName.style.fontSize = 14;
        form.insertBefore(errorlastName, lastName.nextSibling);
    }
    else{
        errorlastName.textContent = '';
        
    }
    
    
    
    if((dateEntered == 'Invalid Date') || (Date.parse(dateEntered) > Date.now()) || ( (Date.parse(dateEntered) - Date.now())/1000/60/60/24/365.2425*(-1) > 150)){
        event.preventDefault();
        date.focus();
        errorDOB.style.color = 'red';
        errorDOB.textContent = 'Поле не может быть пустым, не более 150 лет';
        errorDOB.style.fontStyle = "italic";
        errorDOB.style.fontSize = 14;
        form.insertBefore(errorDOB, date.nextSibling);
    }
    else{
        errorDOB.textContent = '';
    }
    
    
}

acceptBtn.addEventListener("click", validator);