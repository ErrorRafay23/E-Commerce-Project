
////window risize
//window.onresize = function () {
//    location.reload();
//}

////owl carousel
//$(".carousel").owlCarousel({
//    margin: 0,
//    loop: true,
//    autoplay: true,
//    autoplayTimeout: 1000,
//    autoplayHoverPause: true,
//    responsive: {
//        0: {
//            items: 3,
//            nav: true
//        },
//        600: {
//            items: 4,
//            nav: true
//        },
//        700: {
//            items: 5,
//            nav: true
//        },
//        1000: {
//            items: 5,
//            nav: true
//        }
//    }
//});



////sheo color change
//let sheo = document.querySelector('#sheochange');

////active
//const sheos = document.querySelectorAll(".sheos");


//function sheoColorChange(img, num) {
//    sheo.src = img;

//    var current = document.getElementsByClassName('sheoActive');

//    current[0].className = current[0].className.replace(" sheoActive", "");

//    sheos[num].className += " sheoActive";

//}





////bracelet color change
//let bracelet = document.querySelector('#bracelet');

////active
//const bracelets = document.querySelectorAll(".bracelets");


//function braceletColorChange(img, index) {
//    bracelet.src = img;

//    var braceletActive = document.getElementsByClassName('braceletActive');

//    braceletActive[0].className = braceletActive[0].className.replace("braceletActive", "");

//    bracelets[index].className += " braceletActive";

//}


////bag color change
//let bag = document.querySelector('#bag');

////active
//const bags = document.querySelectorAll(".bag");

//function bagColorChange(img, index) {
//    bag.src = img;

//    var bagActive = document.getElementsByClassName('bagActive');

//    bagActive[0].className = bagActive[0].className.replace("bagActive", "");

//    bags[index].className += " bagActive";

//}



////menu bar

//let menu = document.querySelector('.fa-bars');
//let menubar = document.querySelector('.menu-bar');
//let a = true;
//menu.addEventListener("click", () => {

//    if (a == true) {
//        menubar.style.height = "180px";
//        menu.classList.replace("fa-bars", "fa-remove");
//        a = false;
//    } else {
//        menubar.style.height = "0px";
//        menu.classList.replace("fa-remove", "fa-bars");
//        a = true;
//    }

//});

////side menu bar
//let menubarside = document.querySelector('.menu-bar-side');
//let b = true;
//menubarside.addEventListener("click", () => {

//    if (b == true) {
//        menubarside.style.left = "0%";
//        b = false;
//    } else {
//        menubarside.style.left = "-162px";
//        b = true;
//    }

//});











    document.addEventListener("DOMContentLoaded", function () {
        const addToCartButtons = document.querySelectorAll(".add-to-cart");
        const cartItems = document.getElementById("cart-items");
        const cartTotal = document.getElementById("cart-total");
        const cartcount = document.getElementById("cart-count");


        const CardcartTotal = document.getElementById("cardCartTotal");
        const cardcartcount = document.getElementById("cardcartcount");
       
        addToCartButtons.forEach(button => {
            button.addEventListener("click", function () {
                const productId = this.getAttribute("data-id");
                addToCart(productId);
            });
        });

        function addToCart(productId) {
            fetch(`/Main/AddToCart?productId=${productId}`, { method: "POST" })
                .then(response => response.json())
                .then(cart => updateCartUI(cart));
        }

        function updateCartUI(cart) {
            cartItems.innerHTML = "";
         
            let total = 0;
            let count = 0;

            cart.forEach(item => {


                const li = document.createElement("li");
                li.setAttribute("class", "cart-body");
                li.innerHTML =`
                        <img class="cart_img" src="https://websitedemos.net/brandstore-02/wp-content/uploads/sites/150/2021/03/sports-shoe3-400x400.jpg" />
                        <span class="item-name"> ${item.productName}</span>
                        <span class="item-price"> $${item.prodPrice}</span>
                        <span class="item-quantity">Quantity: ${item.quantity}</span>
                   `

              /*  li.textContent = `${item.productName} - Quantity: ${item.quantity}- Price ${item.prodPrice}`;*/
              
               
                const removeButton = document.createElement("button");
                //removeButton.setAttribute("class", "remove-button");
                //removeButton.innerHTML =`<i class="fas fa-times-circle"></i>`

                removeButton.innerHTML = '<i class="fas fa-times-circle"></i> ';
                removeButton.classList.add("remove-button");
                removeButton.addEventListener("click", () => removeCartItem(item.productId));

                li.appendChild(removeButton);
               
                cartItems.appendChild(li);


                total += item.prodPrice * item.quantity;
                count += item.quantity;
               
               
            });
         
            cartTotal.textContent = total.toFixed(2);
            CardcartTotal.textContent = total.toFixed(2);

            cardcartcount.textContent = count;
            cartcount.textContent = count;

        }


        function removeCartItem(productId) {
            fetch(`/Main/RemoveFromCart?productId=${productId}`, { method: "POST" })
                .then(response => response.json())
                .then(cart => updateCartUI(cart));
        }
    });




(function () {

    
    $("#cart").on("click", function () {
        //$(".shopping-cart").css("display", "block");
        $(".shopping-cart").fadeToggle("fast");
    });

})();

//var numItems = $('.item-name').length;

//var sum = 0;
//$('.item-price').each(function () {
//    var thisPrice = $(this).text().replace("$", "");
//    thisPrice = parseFloat($(this).next().text().replace("Quantity: ", "")) * thisPrice;
//    sum += parseFloat(thisPrice);  // x quantity?
//});

//$('.badge').text(numItems);
//$('.main-color-text').text(sum.toFixed(2));
