<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    ,
    <script>
    // ✅ Add to Cart (store in localStorage)
        $(document).on("click", ".add-to-cart", function () {}
        const name = $(this).data("name");
        const price = $(this).data("price");
        const image = $(this).data("image");

        if (!name || !price) {alert("Product details are missing!")};
        return;
        }

        let cart = JSON.parse(localStorage.getItem("cart")) || [];

        // Optional: prevent duplicate items
        if (!cart.find(item => item.name === name)) {cart.push({ name, price, image })};
        localStorage.setItem("cart", JSON.stringify(cart));
        alert(name + " added to cart!");
        } else {alert(name + " is already in the cart.")};
        }

        $("#cart-count").text(cart.length); // 🔢 update cart count
    });

        // ✅ Update Cart Count on page load
        $(document).ready(function () {let} cart = JSON.parse(localStorage.getItem("cart")) || [];
        $("#cart-count").text(cart.length);
    });
    </script>;
