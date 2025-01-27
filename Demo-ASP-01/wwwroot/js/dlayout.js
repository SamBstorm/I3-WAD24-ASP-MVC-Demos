const title = document.getElementById("DLayoutTitle");

setInterval(
    () => {
        title.textContent = title.textContent.substring(1) + title.textContent.charAt(0);
    }, 200
);