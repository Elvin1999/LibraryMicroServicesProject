// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var book_id = 0;
var gatewayUrl = "https://localhost:7205/";

function RentBook(id) {
    let rentElement = document.getElementById("rent");
    rentElement.style.display = "block";
    book_id = id;
    console.log(id);
}





function SubmitRent() {
    let f = document.getElementById("fullname");
    let q = document.getElementById("quantity");

    let obj = {
        fullname: f.value,
        quantity: Number(q.value),
        bookId: Number(book_id)
    };
    $.ajax({
        method: "POST",
        url: gatewayUrl + "ra",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(obj),
        success: function (result) {
             alert('Successfully added Data ');
            console.log(result);
        },
        error: function () {
            alert('Failed to add the Data');
            console.log('Failed ');
        }
    })
}


function GetAllBooks() {

        $.ajax({
            url: gatewayUrl+"b",
            method: "GET",
            success: function (data) {
                let content = "";
                for (var i = 0; i < data.length; i++) {
                    let item = `<div class="card">
  <img src="/images/book.png" alt="Book Image" style="width:100%">
  <h1>${data[i].title}</h1>
  <h2>${data[i].author}</h2>
  
  <p class="price">$${data[i].price}</p>
  <p class='price'>Quantity ${data[i].quantity}</p>
  <p><button onclick=RentBook('${data[i].id}') >Rent Book</button></p>

</div>`;
                    content += item;
                }
                $("#books").html(content);
            },
            error: function (err) {
                console.log(err);
            }


        });
}


GetAllBooks();