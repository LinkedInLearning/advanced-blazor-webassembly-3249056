export function LoadImageThroughStream(imageElement, imageStream) {
    const arrayBuffer = imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);

    imageElement.onload = () => {
        URL.revokeObjectURL(url);
    }
    imageElement.src = url;
}