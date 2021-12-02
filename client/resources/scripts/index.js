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

//get user from local storage
function getCurrentUser(){
    const str = localStorage.getItem("User");

    // convert string to valid object
    const userObj = JSON.parse(str);

    console.log(userObj);
    return userObj;
}

//used to set user data to local storage
function userOnSubmit(){
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    console.log(email);
    var user = getUserID(email, password);

    saveCurrentUser(user);

    //should redirect to userdashborad page
    window.location.href="../userdashboard.html";

}

// used to get the information of a user from the controller 
function getUserID(username, password){
    const customerUrl = "https://localhost:5001/api/Customer"; 
    console.log (customerUrl);

    

    fetch(customerUrl).then(function(response){
        return response.json();
    }).then(function(json){
        var user;
        json.forEach(element=>
            {
                if((element.username == username)&&(element.password == password)){
                    user = element ;
                }
            });
        return user 
    }).catch(function(error){
        console.log(error);
    });

}

// saves user to local storage 
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

    var html = "<table id=\"table_id\" class=\"display\"><thead><tr><th>Item Name</th><th>Size</th><th>Link to Item</th><th>Price</th></tr></thead><tbody>";
    //type is the placeholder for name element link needs an a tag
    clothing.forEach(element => {
        html += `<tr><td>${element.type}</td><td>${element.size}</td><td>${element.link}</td><td>${element.price}</td></tr>`;
    });
    html+="</tbody></table>";
    dataTable.innerHTML = html;
    
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