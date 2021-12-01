function handleOnLoad(){
    const customerUrl = "https://localhost:5001/api/Customer"; 
    console.log (customerUrl);

    fetch(customerUrl).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}


function handleOnSubmit(){
    var email = document.getElementById("email").value;
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var phone = document.getElementById("phone").value;
    var why = " ";
    var password = document.getElementById("password").value;
    var placeholder = "not provided";

    var customer = {
        Email : email,
        FirstName : firstName,
        LastName : lastName,
        Phone : phone,
        Why : why,
        Password : password
    }

    PostCustomer(customer); 
}

function PostCustomer(customer){
    const postCustomerApiUrl = "https://localhost:5001/api/customer"; 
    console.log("hello" + JSON.stringify(customer));
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
    document.getElementById("add_after_me").insertAdjacentHTML("afterend",
                "<div class=\"alert alert-success fade in\" role=\"alert\" id=\"success_message\">Success <i class=\"glyphicon glyphicon-thumbs-up\"></i></div>");
}