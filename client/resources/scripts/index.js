function handleOnLoad(){
    const customerUrl = "https://localhost:5001/api/customer"; 

    fetch(customerUrl).then(function(response){
        return response.json();
    }).catch(function(error){
        console.log(error);
    });
}


function handleOnSubmit(){
    var email = document.getElementById("email").value;
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var why = " ";
    var password = document.getElementById("password").value;
    var placeholder = "not provided";

    var customer = {
        Email : email,
        FirtName : firstName,
        LastName : lastName,
        Phone : phone,
        Why : why,
        Password : password
    }

    PostCustomer(customer); 
}

function PostCustomer(customer){
    const postCustomerApiUrl = "https://localhost:5001/api/customer"; 

    fetch(postCustomerApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(customer)
    }).then((response) =>{
        handleOnLoad();
    })
}