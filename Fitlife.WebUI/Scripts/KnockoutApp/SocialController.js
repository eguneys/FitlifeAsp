
// highlihgt side navigation on social page
    $(document).ready(function () {
        $('#sidenav li a').each(function (index) {
            if (this.href.trim() == window.location)
                $(this).parent().addClass("active");
        });
    });
