function handleOnLoad(){
    const customerUrl = "https://localhost:5001/api/Clothing"; 
    console.log (customerUrl);

    fetch(customerUrl).then(function(response){
        return response.json();
    }).then(function(json){
        displayClothingTable(json);
    }).catch(function(error){
        console.log(error);
    });
}

function getCurrentUser(){
    const str = localStorage.getItem("User");

    // convert string to valid object
    const userObj = JSON.parse(str);

    console.log(userObj);
    return userObj;
}

function userOnSubmit(){
    var password = document.getElementById("password").value;
    var email = document.getElementById("email").value;

    getUserID(email, password);
    window.location.href="../userdashboard.html;

}

function getUserID(username, password){
    const customerUrl = "https://localhost:5001/api/Customer"; 
    console.log (customerUrl);

    

    fetch(customerUrl).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach(element=>
            {
                if((element.username == username)&&(element.password == password)){
                    var user ;
                }
            });
        
    }).catch(function(error){
        console.log(error);
    });

}

function saveCurrentUser(user){
    const userObj = JSON.stringify(user);
    localStorage.setItem("User",userObj);
}

function displayClothingTable(json){
    var currentUser = getCurrentUser();
    let clothing = [];

    json.forEach(element => {
        if(element.userID == curentUser.id){
            clothing.pop(element);
        }
    });
    console.log(clothing);
    
    var dataTable = document.getElementById("dataTable");

    var html = "<table id=\"table_id\" class=\"display\"><thead><tr><th>Item Name</th><th>Size</th><th>Link to Item</th></tr></thead><tbody>";
    clothing.forEach(element => {
        html += `<tr><td>${element.type}</td><td>${element.size}</td></tr><td>${element.link}</td></tr>`;
    });
    html+="</tbody></table>";
    dataTable.innerHTML = html;
    
    
    
    
    // var html = "<table id = \"postTable\" class =\"table table-success table-striped\" id=><tr><th>ID</th><th>Post</th></tr>";
    // json.forEach(post => {
    //     html += `<tr><td>${post.id}</td><td>${post.message}</td></tr>`;
    // });
    // html += "</table>";
    // dataTable.innerHTML = html;
    // console.log(json)
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
    setCurrentUser(customer);
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