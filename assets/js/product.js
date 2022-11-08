
// function khonghienthidanhsach(id,cc){ 
//     $(`#${cc}`).toggleClass("slow");
//     if($(`#plus-${id}`).hasClass("undisplay")) {
//         $(`#minus-${id}`).addClass("undisplay");
//         $(`#plus-${id}`).addClass("display");
//         $(`#plus-${id}`).removeClass("undisplay");
//     }
//     else {
//         $(`#plus-${id}`).addClass("undisplay");
//         $(`#minus-${id}`).addClass("display");
//         $(`#minus-${id}`).removeClass("undisplay");
//     }
// }
$(document).ready(function() {
    $('#filter').click(function(e){
        $('.filter-mobile').toggleClass('xyz');
        $('.overlay2').toggleClass('hidden');
    })
    $('.overlay2').click(function(e){
        $('.filter-mobile').toggleClass('xyz');
        $('.overlay2').toggleClass('hidden');
    })
})

function khonghienthidanhsach(id,cc){ 
    $(`#${cc}`).toggle("slow");
    $(`#plus-${id}`).toggleClass("hidden") 
    $(`#minus-${id}`).toggleClass("hidden");    
}