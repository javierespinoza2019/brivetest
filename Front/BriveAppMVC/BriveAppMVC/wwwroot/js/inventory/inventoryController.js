function LoadInventory(filter) {
    if (!filter || (!filter.ProductName && (!filter.StoreId || filter.StoreId <= 0))) {
        filter = {
            ProductName: $("#txtFilter").val() ?? '',
            StoreId: $("#selStoreFilter").val() ?? 1
        };
    }
    $.post("/Inventory/GetAll", filter).done((data) => {
        $("#tableInventories tbody tr").remove();
        var inventories = JSON.parse(data);
        $.map(inventories, (item, index) => {
            $("#tableInventories tbody").append(
                "<tr>" +
                "<th scope='row'>" + (index + 1) +"</th>" +
                "<td>" + item.productName + "</td>" +
                "<td>" + item.barcode + "</td>" +
                "<td>" + item.existence + "</td>" +
                "<td>" + item.storeName + "</td>" +
                "<td>" + item.unitPrice + "</td>" +
                "</tr>"
            );
        });
    });
}
function LoadProducts() {
    $.getJSON("/Inventory/Products", (products) => {
        $("#selProduct option").remove();        
        $("#selProduct").append($("<option />").val(-1).text("Seleccione un producto"));
        $.each(products, function () {
            $("#selProduct").append($("<option />").val(this.barcode).text(this.name));
        });
    });
}

function LoadStores() {
    $.getJSON("/Inventory/Stores", (stores) => {      
        LoadSelectors("#selStore", stores);
        LoadSelectors("#selStoreFilter", stores, "Sucursal...", 1);
    });
}


function LoadSelectors(controlId, data, optionDefault = "Seleccione una sucursal", selectedIndex = -1) {  
    $(controlId+" option").remove();
    $(controlId).append($("<option />").val(-1).text(optionDefault));
    $.each(data, function () {
        $(controlId).append($("<option />").val(this.id).text(this.name));
    });   
    $(controlId).val(selectedIndex);
}

$(document).ready(function () {
    LoadInventory();
    LoadProducts();
    LoadStores();
});

function CloseNewMovement()
{
    $("#selStore").val(-1);
    $("#selProduct").val(-1);
    $("#txtQuantity").val('');
    $('#newMovementModal').modal('hide');
}

function CloseNewProduct() {
    $("#txtName").val('');
    $("#txtCost").val('');
    $('#newProductModal').modal('hide');
}

$("#btnSaveNewMovement").click(function ()
{   
    var movement = {
        StoreId: $("#selStore").val(),
        Barcode: $("#selProduct").val(),
        Quantity: $("#txtQuantity").val()
    };

    $.post("/Inventory/AddMovement", movement).done((data) => {
        var response = JSON.parse(data);
        if (response && response.success) {
            LoadInventory();
            CloseNewMovement();
        }       
    });
});

$("#btnSaveNewProduct").click(function () {
    var product = {
        Name: $("#txtName").val(),
        Barcode: $("#txtBarcode").val(),
        UnitPrice: $("#txtCost").val()
    };

    $.post("/Inventory/AddProduct", product).done((data) => {
        var response = JSON.parse(data);
        if (response && response.success) {
            LoadProducts();
            CloseNewProduct();
        }
    });
});

$("#btnSearch").click(function () {
    var filter = {
        ProductName: $("#txtFilter").val(),
        StoreId: $("#selStoreFilter").val()
    };
    LoadInventory(filter);
});


$("#btnCloseNewMovement").click(function () {    
    CloseNewMovement();       
});

$("#btnCloseNewProduct").click(function () {    
    CloseNewProduct();
});