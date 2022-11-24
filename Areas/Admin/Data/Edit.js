function GetId(name, id) {
    document.getElementById('Name-Modal').innerHTML = name;
    document.getElementById('id-Modal').innerHTML = id;
    
}
$(document).ready(function () {
    $('body').on('click', '.Ajax-delete', function (e) {
        e.preventDefault();
        var id = document.getElementById('id-Modal').innerHTML;
        alert(id)
        $.ajax({
            url: '/Categories/Remove',
            type: 'POST',
            data: { id: id },
            success: function (rs) {
                if (rs.Success) {
                    $('#trow-' +id).remove();
                }
            }
        });
    });
});
$(document).ready(function () {
    $('body').on('click', '.Ajax-delete-Brands', function (e) {
        e.preventDefault();
        var id = document.getElementById('id-Modal').innerHTML;
        $.ajax({
            url: '/Brands/Remove',
            type: 'POST',
            data: { id: id },
            success: function (rs) {
                if (rs.Success) {
                    $('#trow-' + id).remove();
                }
            }
        });
    });
});