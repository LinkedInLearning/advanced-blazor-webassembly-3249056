export function ToggleElement(element) {
    if (element == undefined) {
        return;
    }
    if (element.style.display == "none") {
        element.style.display = "block";
    }
    else {
        element.style.display = "none";
    }
}

export function JSDelayRedirect() {
    return DotNet.invokeMethodAsync("MyBlazorShopHosted.Web.Client", "RazorDelayRedirectAsync");
}

export function JSRedirectToCart(dotNetReference) {
    dotNetReference.invokeMethod("RazorRedirectToCart");
}