var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $("#btnContinue").off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Soluong: $(item).val();
                    SanPham: {
                        IDSanPham: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                contentType: 'json',
                type: 'Post',
                success: function (res) {
                    if (res.status == true)
                    {
                        window.location.href = "/Cart"
                    }
                  
                }
            })
        });
    }
}
cart.init();