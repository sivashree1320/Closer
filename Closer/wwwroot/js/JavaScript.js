<script>
    $(document).ready(function () {
        // Contact Form Validation
        $("#formStatus").hide();

    $("#contactForm").submit(function (e) {
        e.preventDefault();

    const name = $("#name").val().trim();
    const email = $("#email").val().trim();
    const message = $("#message").val().trim();

    if (!name || !email || !message) {
        showError("❌ Please fill all required fields.");
    return;
        }

    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
        showError("❌ Enter a valid email address.");
    return;
        }

    showSuccess(`✅ Thank you, <strong>${name}</strong>!`);
    $("#contactForm")[0].reset();
    showPopup();
      });

    function showError(msg) {
        $("#formStatus").css("color", "red").html(msg).fadeIn();
      }

    function showSuccess(msg) {
        $("#formStatus").css("color", "green").html(msg).fadeIn();
      }

    // Newsletter toggle
    $("#toggleForm").click(function () {
        $("#subscribeForm").slideToggle();
      });
    });

    function showPopup() {
        $("#popupOverlay").fadeIn();
    $("#popup").fadeIn();
    }

    function closePopup() {
        $("#popup").fadeOut();
    $("#popupOverlay").fadeOut();
    }
</script>