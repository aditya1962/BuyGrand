function loadSubreviews(e) {
    var targetId = e.target.id;
    var parentDiv = $("#" + targetId).parent().parent()[0];
    var review = $($("#" + targetId).parent().parent()[0]).find("#ReviewID").val();
    var product = $("#ProductValue").val();
    var subreviewHtml = "";
    if (!$(parentDiv).find(".subreviewProduct").length) {
        $.ajax({
            url: "Data/GetReviews.aspx",
            dataType: "json",
            data: { review: review, product: product },
            method: "get",
            contentType: "application/json",
            success: function (data) {
                data.forEach(function (subreview) {
                    subreviewHtml += "<div class='subreviewProduct'>";
                    subreviewHtml += "<input type='hidden' id='subreviewId' value=" + subreview.reviewID + ">";
                    subreviewHtml += "<div class='row' style='display: flex;'>";
                    subreviewHtml += "<img src='" + subreview.imagePath + "' alt='Profile' width='40px' />";
                    subreviewHtml += "<label style='padding:0px 10px;'>" + subreview.name + "</label>";
                    subreviewHtml += "<label>" + getDateDiff(subreview.datetime) + "</label>";
                    subreviewHtml += "</div>";
                    subreviewHtml += "<div class='row'>";
                    subreviewHtml += "<label>" + subreview.reviewDesc + "</label>";
                    subreviewHtml += "</div></div>";
                })
                $(parentDiv).find(".subreviews").append(subreviewHtml);
                $(parentDiv).find(".subreviews").css('visibility', 'visible');
            },
            error: function (err) {
                console.log(err);
                subreviewHtml += "<div class='subreviewProduct'>";
                subreviewHtml += "<label style='color:red;'>Error in loading reviews for the review </label>";
                subreviewHtml += "</div>";
                $(parentDiv).find(".subreviews").append(subreviewHtml);
                $(parentDiv).find(".subreviews").css('visibility', 'visible');
            }
        })
        $("#" + targetId).text("Hide reviews");
    }
    else {
        $(parentDiv).find(".subreviews").empty();
        $(parentDiv).find(".subreviews").css('visibility', 'visible');
        $("#" + targetId).text("View reviews");
    }
}

function loadSubreviewComment(e) {
    var parentDiv = $(e).parent().parent()[0];
    var subreview = "";
    if (!$(parentDiv).find(".subreviewComment").length) {
        subreview += "<div class='subreviewComment'>"
        subreview += "<textarea id='SubReview' placeholder='Enter Review' class='form-control' rows='5'></textarea>";
        subreview += "<br />";
        subreview += "<div class='display:flex;'>"
        subreview += "<button class='btn btn-primary' onclick='addSubReview(this)' type='button'> Comment </button>";
        subreview += "<button class='btn btn-default' onclick='cancel(this)' type='button'> Cancel </button>";
        subreview += "</div></div>";
    }
    $(parentDiv).find(".subreviews").append(subreview);
    $(parentDiv).find(".subreviews").css('visibility', 'visible');
}

function getDateDiff(value) {
    var dateNow = new Date();
    var date = new Date(value);
    var diff = "0 hours ago";

    if (dateNow.getFullYear() > date.getFullYear()) {
        diff = (dateNow.getFullYear() - date.getFullYear()) + " years ago";
    }
    else if (dateNow.getMonth() > date.getMonth()) {
        diff = (dateNow.getMonth() - date.getMonth()) + " months ago";
    }
    else if (dateNow.getDay() > date.getDay()) {
        diff = (dateNow.getDay() - date.getDay()) + " days ago";
    }
    else if (dateNow.getHours() > date.getHours()) {
        diff = (dateNow.getHours() - date.getHours) + " hours ago";
    }
    return diff;
}

function addReview() {
    var review = $("#Review").val();
    var product = $("#ProductValue").val();
    var comment = "";
    $.ajax({
        url: "Data/AddComment.aspx",
        dataType: "json",
        data: { review: review, product: product, reviewID: -1 },
        method: "get",
        contentType: "application/json",
        success: function (data) {
            if (data[0] == "1") {
                comment += "<div class='productReview'>";
                comment += "<div class='row' style='display: flex;'>";
                comment += "<img src='" + data[2] + "' alt='Profile' width='40px' />";
                comment += "<label style='padding:0px 10px;'>" + data[1] + "</label>";
                comment += "<label>" + getDateDiff(new Date()) + "</label>";
                comment += "</div>";
                comment += "<div class='row'>";
                comment += "<label>" + review + "</label>";
                comment += "</div></div>";
            }
            else {
                comment += "<div class='productReview'>";
                comment += "<label style='color:red;'>Error in adding a comment </label>";
                comment += "</div>";
            }
            $("#reviewDiv").append(comment);
        },
        error: function (err) {
            comment += "<div class='subreviewProduct'>";
            comment += "<label style='color:red;'>Error in adding a comment </label>";
            comment += "</div>";
            $("#reviewDiv").append(comment);
        }
    })
    $("#Review").val("");
}

function cancel(e) {
    var parentDiv = $(e).parent().parent()[0];
    $(parentDiv).remove();
}

function addSubReview(e) {
    var parentDivTop = $(e).parents().eq(4)[0];
    var originalReview = $(parentDivTop).find("#ReviewID").val();
    var review = $(parentDivTop).find("#SubReview").val();
    var parentDiv = $(e).parents().eq(2)[0];
    var product = $("#ProductValue").val();
    var comment = "";
    $.ajax({
        url: "Data/AddComment.aspx",
        dataType: "json",
        data: { review: review, product: product, reviewID: originalReview },
        method: "get",
        contentType: "application/json",
        success: function (data) {
            if (data[0] == "1") {
                comment += "<div class='subreviewProduct'>";
                comment += "<div class='row' style='display: flex;'>";
                comment += "<img src='" + data[2] + "' alt='Profile' width='40px' />";
                comment += "<label style='padding:0px 10px;'>" + data[1] + "</label>";
                comment += "<label>" + getDateDiff(new Date()) + "</label>";
                comment += "</div>";
                comment += "<div class='row'>";
                comment += "<label>" + review + "</label>";
                comment += "</div></div>";
            }
            else {
                comment += "<div class='subreviewProduct'>";
                comment += "<label style='color:red;'>Error in adding a comment </label>";
                comment += "</div>";
            }
            $(parentDiv).append(comment);
        },
        error: function (err) {
            comment += "<div class='subreviewProduct'>";
            comment += "<label style='color:red;'>Error in adding a comment </label>";
            comment += "</div>";
            $(parentDiv).append(comment);
        }
    })
    $(parentDiv).find(".subreviewComment").remove();
}

$(function () {
    $("#ImageFile").change(function () {
        readImageSrc(this);
    })
});

function readImageSrc(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#Image").attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function update() {
    var productValue = $("#ProductValue").val();
    var category = $("#CategoryDropdown").val();
    var subcategory = $("#SubcategoryDropdown").val();
    var name = $("#EditName").val();
    var description = $("#EditDescription").val();
    var price = $("#EditPrice").val();
    var discount = $("#EditDiscount").val();
    var quantity = $("#EditQuantity").val();
    var filename = "";
    if (($("#ImageFile"))[0].files[0] != undefined)
    {
        filename = ($("#ImageFile"))[0].files[0]["name"];
    }    
    var checkValArray = [ name, description, price, discount, quantity, filename ];
    var error = checkValues(checkValArray);
    if (!error) {
        $.ajax({
            url: "Data/UpdateProductData.aspx",
            dataType: "json",
            data: {
                productVal: productValue, category: category, subcategory: subcategory, name: name, description: description,
                price: price, discount: discount, quantity: quantity, filename: filename
            },
            method: "get",
            contentType: "application/json",
            success: function (data) {
                $("#UpdateMessage").text("Updated product");
            },
            error: function (err) {
                $("#UpdateMessage").text("Could not update product");
            }
        })
        $("#editProductModal").modal('toggle');
    }
    else {
        $("#EditModalError").text(error);
        $("#EditModalError").css("visibility", "visible");
    }
    
}

function deleteProduct() {
    var productValue = $("#ProductValue").val();
    $.ajax({
        url: "Data/DeleteProduct.aspx",
        dataType: "json",
        data: {
            productVal: productValue
        },
        method: "get",
        contentType: "application/json",
        success: function (data) {
            $("#UpdateMessage").text("Deleted product");
        },
        error: function (err) {
            $("#UpdateMessage").text("Could not delete product");
        }
    })
    $("#deleteModal").modal('toggle');
}

function checkValues(array) {
    var error = "";
    if (array.includes(undefined) || array.includes("")) {
        error = "One or more fields have not been filled";
    }
    else if (array[2] < 0 || array[3] < 0 || array[4] < 0)
    {
        error = "One or more fields have a negative value";
    }
    else if (array[2] < array[3])
    {
        error = "Discount can't be greater than the price";
    }
    else {
    var size = ($("#ImageFile"))[0].files[0]["size"];  
    var fileName = ($("#ImageFile"))[0].files[0]["name"];
    var filenameSize = fileName.length;
    var type = fileName.substr(fileName.lastIndexOf('.') + 1);
    
    if (size > 3145728) {
        error = "File size should be less than 3 MB";
    }
    else if (filenameSize > 170) {
        error = "File name should be less than 170 characters";
    }
    else if (type != "jpg" && type != "png") {
        error = "File should be either in JPEG or PNG format";
        }
    }
    return error;
}
