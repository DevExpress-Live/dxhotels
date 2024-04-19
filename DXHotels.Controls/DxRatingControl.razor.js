export function getFraction(element, args) {
    var x = args.pageX - element.offsetLeft; // Get the horizontal coordinate of the mouse
    var width = element.offsetWidth; // Get the width of the star rating control
    var fraction = x / width; // Calculate the fraction of the star that the mouse is over    
    return fraction;
}