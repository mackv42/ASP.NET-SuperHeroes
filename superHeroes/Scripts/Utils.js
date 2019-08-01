function DeleteHero(id) {
    if (confirm("Delete This hero?")) {
        $.ajax({
            type: "POST",
            url: "/SuperHero/Delete/" + id,

            success: function (result) {
                setTimeout(document.location.reload(true), 1000); 
            }
        });
    }
}

function increment(id) {
    $.ajax({
        type: "POST",
        url: "/SuperHero/Click/" + id,
    });
}
