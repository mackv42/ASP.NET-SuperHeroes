function DeleteHero(id) {
    if (confirm("Delete This hero?")) {
        $.ajax({
            type: "POST",
            url: "/SuperHero/Delete/" + id,

            success: function (result) {
                alert("Hero Deleted");
                document.location.reload(true); 
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
