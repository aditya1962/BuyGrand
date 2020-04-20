$(document).ready(function () {
    $(".user-div").hover(function () {
        $(".navigation-dropdown").show();
    },
        function () {
            $(".navigation-dropdown").hide();
        })
    $(".navigation-dropdown").mouseenter(function () {
        $(".navigation-dropdown").show();
    })
    $(".navigation-dropdown a").mouseenter(function () {
        $(".navigation-dropdown").show();
    })
    $(".navigation-dropdown").mouseleave(function () {
        $(".navigation-dropdown").hide();
    })
});