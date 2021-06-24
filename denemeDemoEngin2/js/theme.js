"use strict"; // Start of use strict
(function($) {
    if ($('.accrodion-grp').length) {
        var accrodionGrp = $('.accrodion-grp');
        accrodionGrp.each(function() {
            var accrodionName = $(this).data('grp-name');
            var Self = $(this);
            var accordion = Self.find('.accrodion');
            Self.addClass(accrodionName);
            Self.find('.accrodion .accrodion-content').hide();
            Self.find('.accrodion.active').find('.accrodion-content').show();
            accordion.each(function() {
                $(this).find('.accrodion-title').on('click', function() {
                    if ($(this).parent().hasClass('active') === false) {
                        $('.accrodion-grp.' + accrodionName).find('.accrodion').removeClass('active');
                        $('.accrodion-grp.' + accrodionName).find('.accrodion').find('.accrodion-content').slideUp();
                        $(this).parent().addClass('active');
                        $(this).parent().find('.accrodion-content').slideDown();
                    };


                });
            });
        });

    };
    if ($('.contact-form-validated').length) {
        $('.contact-form-validated').validate({ // initialize the plugin
            rules: {
                name: {
                    required: true
                },
                fname: {
                    required: true
                },
                lname: {
                    required: true
                },
                email: {
                    required: true,
                    email: true
                },
                message: {
                    required: true
                },
                subject: {
                    required: true
                }
            },
            submitHandler: function(form) {
                // sending value with ajax request
                $.post($(form).attr('action'), $(form).serialize(), function(response) {
                    $(form).parent().find('.result').append(response);
                    $(form).find('input[type="text"]').val('');
                    $(form).find('input[type="email"]').val('');
                    $(form).find('textarea').val('');
                });
                return false;
            }
        });
    }
    if ($('.scroll-to-target').length) {
        $(".scroll-to-target").on('click', function() {
            var target = $(this).attr('data-target');
            // animate
            $('html, body').animate({
                scrollTop: $(target).offset().top
            }, 1000);

            return false;

        });
    }
    if ($('.counter').length) {
        $('.counter').counterUp({
            delay: 10,
            time: 3000
        });
    }
    if ($('.wow').length) {
        var wow = new WOW({
            boxClass: 'wow', // animated element css class (default is wow)
            animateClass: 'animated', // animation css class (default is animated)
            offset: 250, // distance to the element when triggering the animation (default is 0)
            mobile: true, // trigger animations on mobile devices (default is true)
            live: true // act on asynchronously loaded content (default is true)
        });
        wow.init();
    }
    if ($('.image-popup').length) {
        var groups = {};
        $('.image-popup').each(function() {
            var id = parseInt($(this).attr('data-group'), 10);

            if (!groups[id]) {
                groups[id] = [];
            }

            groups[id].push(this);
        });


        $.each(groups, function() {

            $(this).magnificPopup({
                type: 'image',
                closeOnContentClick: true,
                closeBtnInside: false,
                gallery: { enabled: true }
            });

        });

    };
    if ($('.video-popup').length) {
        $('.video-popup').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: true,

            fixedContentPos: false
        });
    }
    if ($('.main-navigation .navigation-box .sub-menu').length) {
        var subMenu = $('.main-navigation .sub-menu');
        subMenu.parent('li').children('a').append(function() {
            return '<button class="sub-nav-toggler"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>';
        });
        var mainNavToggler = $('.header-navigation .menu-toggler');
        var subNavToggler = $('.main-navigation .sub-nav-toggler');
        mainNavToggler.on('click', function() {
            var Self = $(this);
            var menu = Self.data('target');
            $(menu).slideToggle();
            $(menu).toggleClass('showen');
            return false;
        });
        subNavToggler.on('click', function() {
            var Self = $(this);
            Self.parent().parent().children('.sub-menu').slideToggle();
            return false;
        });
    }
    if ($('.side-navigation').length) {
        $('.side-nav-opener').on('click', function() {
            $('.side-navigation').addClass('open');
            return false;
        });
        $('.side-navigation-close-btn, .page-wrapper').on('click', function() {
            $('.side-navigation').removeClass('open');
        });
    };
    if ($('.popup-with-zoom-anim').length) {
        $('.popup-with-zoom-anim').magnificPopup({
            type: 'inline',

            fixedContentPos: false,
            fixedBgPos: true,

            overflowY: 'auto',

            closeBtnInside: true,
            preloader: false,

            midClick: true,
            removalDelay: 300,
            mainClass: 'my-mfp-zoom-in'
        });
    }

    function bootstrapAnimatedLayer() {

        function doAnimations(elems) {
            //Cache the animationend event in a variable
            var animEndEv = "webkitAnimationEnd animationend";

            elems.each(function() {
                var $this = $(this),
                    $animationType = $this.data("animation");
                $this.addClass($animationType).one(animEndEv, function() {
                    $this.removeClass($animationType);
                });
            });
        }

        //Variables on page load
        var $myCarousel = $("#minimal-bootstrap-carousel"),
            $firstAnimatingElems = $myCarousel
            .find(".carousel-item:first")
            .find("[data-animation ^= 'animated']");

        //Initialize carousel
        $myCarousel.carousel();

        //Animate captions in first slide on page load
        doAnimations($firstAnimatingElems);

        //Other slides to be animated on carousel slide event
        $myCarousel.on("slide.bs.carousel", function(e) {
            var $animatingElems = $(e.relatedTarget).find(
                "[data-animation ^= 'animated']"
            );
            doAnimations($animatingElems);
        });
    }

    bootstrapAnimatedLayer();


    function isotopeActivator() {
        if ($('.masonary-layout').length) {
            $('.masonary-layout').isotope({
                layoutMode: 'masonry',
                itemSelector: '.masonary-item',
                masonry: {
                    columnWidth: 100
                }
            });
        }
        if ($('.masonary-layout-no-grid-width').length) {
            $('.masonary-layout-no-grid-width').isotope({
                layoutMode: 'masonry',
                itemSelector: '.masonary-item'
            });
        }

        if ($('.post-filter').length) {
            var postFilterList = $('.post-filter li');
            postFilterList.children('span').on('click', function() {
                var Self = $(this);
                var selector = Self.parent().attr('data-filter');
                postFilterList.children('span').parent().removeClass('active');
                Self.parent().addClass('active');


                $('.filter-layout').isotope({
                    filter: selector,
                    animationOptions: {
                        duration: 500,
                        easing: 'linear',
                        queue: false
                    }
                });
                return false;
            });
        }

        if ($('.post-filter.has-dynamic-filter-counter').length) {
            // var allItem = $('.single-filter-item').length;

            var activeFilterItem = $('.post-filter.has-dynamic-filter-counter').find('li');

            activeFilterItem.each(function() {
                var filterElement = $(this).data('filter');
                var count = $('.gallery-content').find(filterElement).length;
                $(this).children('span').append('<span class="count"><b>' + count + '</b></span>');
            });
        }
    }


    if ($('.service-style-one-carousel').length) {
        $('.service-style-one-carousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 2
                },
                1199: {
                    items: 3
                },
                1200: {
                    items: 3
                }
            }
        });
    }

    if ($('.service-style-two-carousel').length) {
        $('.service-style-two-carousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 2
                },
                1199: {
                    items: 3
                },
                1200: {
                    items: 3
                }
            }
        });
    }

    if ($('.blog-carousel-style-one').length) {
        $('.blog-carousel-style-one').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 2
                },
                1199: {
                    items: 2
                },
                1200: {
                    items: 3
                }
            }
        });
    }

    if ($('.blog-carousel-style-two').length) {
        $('.blog-carousel-style-two').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 2
                },
                1199: {
                    items: 2
                },
                1200: {
                    items: 2
                }
            }
        });
    }

    if ($('.testimonials-carousel-style-one').length) {
        $('.testimonials-carousel-style-one').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 2
                },
                1199: {
                    items: 2
                },
                1200: {
                    items: 3
                }
            }
        });
    }

    if ($('.testimonials-carousel-style-two').length) {
        $('.testimonials-carousel-style-two').owlCarousel({
            loop: true,
            margin: 0,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 1
                },
                1199: {
                    items: 1
                },
                1200: {
                    items: 1
                }
            }
        });
    }

    if ($('.testimonials-style-three-carousel').length) {
        $('.testimonials-style-three-carousel').owlCarousel({
            loop: true,
            margin: 0,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: true,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                767: {
                    items: 1
                },
                991: {
                    items: 1
                },
                1199: {
                    items: 1
                },
                1200: {
                    items: 1
                }
            }
        });
    }



    if ($('.brand-carousel-one').length) {
        $('.brand-carousel-one').owlCarousel({
            loop: true,
            margin: 10,
            nav: false,
            navText: [
                '<i class="fa fa-long-arrow-left"></i>',
                '<i class="fa fa-long-arrow-right"></i>'
            ],
            dots: false,
            autoWidth: false,
            autoplay: true,
            smartSpeed: 700,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 3
                },
                600: {
                    items: 3
                },
                991: {
                    items: 4
                },
                1000: {
                    items: 5
                },
                1200: {
                    items: 5
                }
            }
        });
    }

    if ($('.project-style-two').length) {
        let projectWrapper = $('.project-banner-wrapper'),
            projectImages  = projectWrapper.data('background-images'),
            projectImagesArry = projectImages.split(','),
            singleProjectWrap = $('.single-project-style-two');

        singleProjectWrap.on('mouseover', function () {
            let index = singleProjectWrap.index(this);
            projectWrapper.css({
                'background-image': 'url('+projectImagesArry[index]+')'
            });
        });
    }


    $(window).on('scroll', function() {
        if ($('.scroll-to-top').length) {
            var strickyScrollPos = 100;
            if ($(window).scrollTop() > strickyScrollPos) {
                $('.scroll-to-top').fadeIn(500);
            } else if ($(this).scrollTop() <= strickyScrollPos) {
                $('.scroll-to-top').fadeOut(500);
            }
        };
        if ($('.stricky').length) {
            var headerScrollPos = 100;
            var stricky = $('.stricky');
            if ($(window).scrollTop() > headerScrollPos) {
                stricky.removeClass('slideIn animated');
                stricky.addClass('stricky-fixed slideInDown animated');
            } else if ($(this).scrollTop() <= headerScrollPos) {
                stricky.removeClass('stricky-fixed slideInDown animated');
                stricky.addClass('slideIn animated');
            }
        };
    });


    $(window).on('load', function() {
        isotopeActivator();
        if ($('.preloader').length) {
            $('.preloader').fadeOut();
        }

        if ($(window).width() < 1200) {
            if ($('.masonary-destroy-lg').length) {
                $('.masonary-destroy-lg').isotope('destroy');
            }
        }
        if ($('.testimonials-style-one .slider').length) {
            $('.testimonials-style-one .slider').bxSlider({
                adaptiveHeight: true,
                auto: true,
                controls: true,
                nextText: '<i class="fa fa-angle-right"></i>',
                prevText: '<i class="fa fa-angle-left"></i>',
                pause: 5000,
                speed: 1000,
                pagerCustom: '#testi-pager-1'
            });
        }
    });

    $(window).on('resize', function() {
        // reactvating masonary
        isotopeActivator();

        if ($(window).width() < 1200) {
            if ($('.masonary-destroy-lg').length) {
                $('.masonary-destroy-lg').isotope('destroy');
            }
        }

    });

})(jQuery);