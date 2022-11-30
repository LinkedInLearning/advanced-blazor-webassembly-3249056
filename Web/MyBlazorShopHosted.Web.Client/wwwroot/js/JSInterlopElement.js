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