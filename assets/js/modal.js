function modal(id, name, Promotion, price) {
    document.getElementById('name-modal-product').innerHTML = name;
    if (Promotion > 0) {
        document.getElementById('special-price').innerHTML = `<span>${price}</span>`
    }
    else {
        document.getElementById('special-price').innerHTML = `Giá gốc:
                                    <del>${price}</del>
                                    <span class="discount">(-20%)</span>`
    }

}