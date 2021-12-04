let name = document.getElementsByClassName('name')[0];
let description = document.getElementsByClassName('description')[0];
let acceptBtn = document.getElementsByClassName('acceptBtn')[0];
let form = document.getElementsByClassName('form')[0];

let errorName = document.getElementsByClassName('errorName')[0];
let errorDescription = document.getElementsByClassName('errorDescription')[0];

function validator(){
    if(name.value == "" || name.value.length > 50){
        event.preventDefault();
        
        name.focus();
        
        errorName.style.color = 'red';
        errorName.textContent = 'Поле не может быть пустым, не более 50 символов';
        errorName.style.fontStyle = "italic";
        errorName.style.fontSize = 14;
        form.insertBefore(errorName, name.nextSibling);
    }
    else{
        errorName.textContent = '';
    }
    
    if(description.value.length > 250){
        event.preventDefault();
        
        description.focus();
        
        errorDescription.style.color = 'red';
        errorDescription.textContent = 'Не более 250 символов';
        errorDescription.style.fontStyle = "italic";
        errorDescription.style.fontSize = 14;
        form.insertBefore(errorDescription, description.nextSibling);
    }
    else{
        errorDescription.textContent = '';
    }
}

acceptBtn.addEventListener("click", validator);