function GetLocalOffsetMinutes() {
    var date = new Date();

    return date.getTimezoneOffset();
}
function AddToCart(productName) {
    alert(productName + " has been added to the cart");
}