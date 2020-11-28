function replyID(id) {
    $("#FeedbackID").val(id);
}

function reply() {
    var reply = $("#Reply").val();
    console.log(reply);
    var originalID = $("#FeedbackID").val();
    console.log(originalID);
    $.ajax({
        url: 'Data/ReplyFeedbacks.aspx',
        type: 'get',
        data: { reply: reply, originalID: originalID },
        dataType: "json",
        contentType: 'application/json',
        success: function (data) {
            $("#ReplyStatus").text("Replied");
        },
        error: function (err) {
            $("#ReplyStatus").text("Could not add reply");
        }
    });
    $("#replyFeedback").modal('toggle');
    $("#ReplyStatus").css('visibility', 'visible');
}