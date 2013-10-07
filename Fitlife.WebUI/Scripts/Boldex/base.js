$('.carou1').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: {
        visible: {
            min: 1,
            max: 3
        }
    },
    prev: '#prev3',
    next: '#next3',
    auto: {
        play: false
    }
});
$('.carou2').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: {
        visible: {
            min: 1,
            max: 3
        }
    },
    prev: '#prev1',
    next: '#next1',
    auto: {
        play: false
    }
});
$('.carou3').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: {
        visible: {
            min: 1,
            max: 3
        }
    },
    prev: '#prev5',
    next: '#next5',
    auto: {
        play: false
    }
});
$(window).resize(function () {
    $('.carou1').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: ($(window).width() > 767 ? 3 : 1),
    prev: '#prev3',
    next: '#next3',
    auto: {
        play: false
    }
    });
    $('.carou2').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: ($(window).width() > 767 ? 3 : 1),
    prev: '#prev1',
    next: '#next1',
    auto: {
        play: false
    }
    });
    $('.carou3').carouFredSel({
    responsive: true,
    scroll: 1,
    circular: false,
    infinite: false,
    items: ($(window).width() > 767 ? 3 : 1),
    prev: '#prev5',
    next: '#next5',
    auto: {
        play: false
    }
    });
});

//$('.socket').tooltip({
//    selector: "a[data-toggle=tooltip]"
//});

$().UItoTop({ easingType: 'easeOutQuart' });

$("a[rel^='prettyPhoto']").prettyPhoto();

$(".wrapper").fitVids();


$(window).load(function () {
// run code
// cache container
var $container = $('.portfolio .p-items');
var $filter = $('.portfolio-filter');
// initialize isotope
$container.isotope({
    // options...
    masonry: {
        columnWidth: 5
    }
});
// filter items when filter link is clicked
$('#filters a').click(function () {
    var selector = $(this).attr('data-filter');
    $container.isotope({ filter: selector });
    return false;
});
// Filter items when filter link is clicked
$filter.find('a').click(function () {
    var selector = $(this).attr('data-filter');
    $filter.find('a').removeClass('selected');
    $(this).addClass('selected');
});
});

// update columnWidth on window resize
$(window).smartresize(function () {
    $container.isotope('reLayout');
});
	
jQuery('.open-close').click(function() {
    if (jQuery(this).parent().css('left') == '-158px') {
    jQuery(this).parent().animate({
    "left": "0"
    }, 300);
    } else {
    jQuery(this).parent().animate({
    "left": "-158px"
    }, 300);
    }
});

$(window).resize(function(){
    if ($(this).width() < 768 ) {
    $('.theme-changer-wrap').css({display: 'none'});
    }
		
    if ($(this).width() > 768 ) {
    $('.theme-changer-wrap').css({display: 'block'});
    }		
});


