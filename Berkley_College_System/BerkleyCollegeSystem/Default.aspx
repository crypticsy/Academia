<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BerkleyCollegeSystem._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="CSSContent" runat="server">

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700,800,900" rel="stylesheet">

    <!-- Additional CSS Files -->
    <link rel="stylesheet" href="Content/home/css/fontawesome.css">
    <link rel="stylesheet" href="Content/home/css/templatemo-grad-school.css">
    <link rel="stylesheet" href="Content/home/css/owl.css">
    <link rel="stylesheet" href="Content/home/css/lightbox.css">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="section main-banner" id="top" data-section="section1">
        <video autoplay muted loop id="bg-video">
            <source src="Content/home/images/course-video.mp4" type="video/mp4" />
        </video>

        <div class="video-overlay header-text">
            <div class="caption">
                <h6>School of Tigers</h6>
                <h2><em>Berkley</em> University</h2>
            </div>
        </div>
    </section>

    <section class="features card">
        <div class="container">
          <div class="row">
            <div class="col-lg-4 col-12">
              <div class="features-post">
                <div class="features-content">
                  <div class="content-show">
                    <h4><i class="fa fa-pencil"></i>All Courses</h4>
                  </div>
                  <div class="content-hide">
                    <p>Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet. Donec maximus elementum ex. Cras convallis ex rhoncus, laoreet libero eu, vehicula libero.</p>
                    <p class="hidden-sm">Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet.</p>
                </div>
                </div>
              </div>
            </div>
            <div class="col-lg-4 col-12">
              <div class="features-post second-features">
                <div class="features-content">
                  <div class="content-show">
                    <h4><i class="fa fa-graduation-cap"></i>Virtual Class</h4>
                  </div>
                  <div class="content-hide">
                    <p>Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet. Donec maximus elementum ex. Cras convallis ex rhoncus, laoreet libero eu, vehicula libero.</p>
                    <p class="hidden-sm">Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet.</p>
                </div>
                </div>
              </div>
            </div>
            <div class="col-lg-4 col-12">
              <div class="features-post third-features">
                <div class="features-content">
                  <div class="content-show">
                    <h4><i class="fa fa-book"></i>Athletic Team</h4>
                  </div>
                  <div class="content-hide">
                    <p>Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet. Donec maximus elementum ex. Cras convallis ex rhoncus, laoreet libero eu, vehicula libero.</p>
                    <p class="hidden-sm">Curabitur id eros vehicula, tincidunt libero eu, lobortis mi. In mollis eros a posuere imperdiet.</p>
                </div>
                </div>
              </div>
            </div>
          </div>
        </div>
    </section>
    
    <section class="section why-us card" data-section="section2">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-heading">
                        <h2>Why choose Berkley?</h2>
                    </div>
                </div>
                <div class="col-md-12">
                    <div id='tabs'>
                        <ul>
                            <li><a href='#tabs-1'>Best Education</a></li>
                            <li><a href='#tabs-2'>Student Council</a></li>
                            <li><a href='#tabs-3'>Holistic Curriculum</a></li>
                        </ul>
                        <section class='tabs-content'>
                            <article id='tabs-1'>
                                <div class="row">
                                    <div class="col-md-6">
                                        <img src="Content/home/images/choose-us-image-01.png" alt="">
                                    </div>
                                    <div class="col-md-6">
                                        <h4>Best Education</h4>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lectus quam id leo in vitae turpis massa. Lacus vel facilisis volutpat est velit egestas dui id. Nibh venenatis cras sed felis eget velit aliquet. Odio ut enim blandit volutpat maecenas volutpat blandit aliquam. Faucibus turpis in eu mi bibendum neque. Aenean et tortor at risus. Tristique et egestas quis ipsum suspendisse. Ornare massa eget egestas purus. Interdum velit euismod in pellentesque massa placerat duis. Vel facilisis volutpat est velit egestas dui id ornare arcu. Convallis tellus id interdum velit. Ac turpis egestas integer eget aliquet. Sed tempus urna et pharetra pharetra massa massa. Amet consectetur adipiscing elit pellentesque habitant morbi tristique senectus et.</p>
                                    </div>
                                </div>
                            </article>
                            <article id='tabs-2'>
                                <div class="row">
                                    <div class="col-md-6">
                                        <img src="Content/home/images/choose-us-image-02.png" alt="">
                                    </div>
                                    <div class="col-md-6">
                                        <h4>Student Council</h4>
                                        <p>Vitae proin sagittis nisl rhoncus mattis rhoncus urna neque. Ultrices tincidunt arcu non sodales neque sodales. Fames ac turpis egestas sed tempus urna et. Orci dapibus ultrices in iaculis nunc sed augue lacus viverra. Placerat vestibulum lectus mauris ultrices eros in cursus. Pharetra magna ac placerat vestibulum lectus mauris ultrices eros. Mauris cursus mattis molestie a iaculis</p> 
                                        <p>Suspendisse tincidunt, magna ut finibus rutrum, libero dolor euismod odio, nec interdum quam felis non ante.</p>
                                    </div>
                                </div>
                            </article>
                            <article id='tabs-3'>
                                <div class="row">
                                    <div class="col-md-6">
                                        <img src="Content/home/images/choose-us-image-03.png" alt="">
                                    </div>
                                    <div class="col-md-6">
                                        <h4>Holistic Curriculum</h4>
                                        <p>Risus at ultrices mi tempus imperdiet nulla malesuada. Diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus. Sed libero enim sed faucibus turpis. Proin nibh nisl condimentum id venenatis a condimentum. Diam volutpat commodo sed egestas. Sed faucibus turpis in eu mi bibendum neque egestas congue. Nunc eget lorem dolor sed viverra ipsum nunc. Penatibus et magnis dis parturient montes nascetur ridiculus. Commodo viverra maecenas accumsan lacus vel facilisis volutpat est.</p>
                                    </div>
                                </div>
                            </article>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="section courses" data-section="section4">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-12">
              <div class="section-heading">
                <h2>Available Course</h2>
              </div>
            </div>
            <div class="owl-carousel owl-theme">
              <div class="item">
                <img src="Content/home/images/courses-01.jpg" alt="Course #1">
                <div class="down-content">
                  <h4>Digital Marketing</h4>
                  <p>Quis lectus nulla at volutpat diam. Urna nec tincidunt praesent semper. Malesuada bibendum arcu vitae elementum curabitur vitae nunc.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-01.png" alt="Author 1">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-02.jpg" alt="Course #2">
                <div class="down-content">
                  <h4>Business World</h4>
                  <p>Quisque cursus augue ut velit dictum, quis volutpat enim blandit. Maecenas a lectus ac ipsum porta.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-02.png" alt="Author 2">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-03.jpg" alt="Course #3">
                <div class="down-content">
                  <h4>Media Technology</h4>
                  <p>Pellentesque ultricies diam magna, auctor cursus lectus pretium nec. Maecenas finibus lobortis enim.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-03.png" alt="Author 3">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-04.jpg" alt="Course #4">
                <div class="down-content">
                  <h4>Communications</h4>
                  <p>Quis lectus nulla at volutpat diam. Urna nec tincidunt praesent semper. Malesuada bibendum arcu vitae elementum curabitur vitae nunc.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-04.png" alt="Author 4">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-05.jpg" alt="">
                <div class="down-content">
                  <h4>Business Ethics</h4>
                  <p>Pellentesque ultricies diam magna, auctor cursus lectus pretium nec. Maecenas finibus lobortis enim.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-05.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-01.jpg" alt="">
                <div class="down-content">
                  <h4>Photography</h4>
                  <p>Quisque cursus augue ut velit dictum, quis volutpat enim blandit. Maecenas a lectus ac ipsum porta.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-01.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-02.jpg" alt="">
                <div class="down-content">
                  <h4>Web Development</h4>
                  <p>Pellentesque ultricies diam magna, auctor cursus lectus pretium nec. Maecenas finibus lobortis enim.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-02.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-03.jpg" alt="">
                <div class="down-content">
                  <h4>Learn HTML CSS</h4>
                  <p>Quis lectus nulla at volutpat diam. Urna nec tincidunt praesent semper. Malesuada bibendum arcu vitae elementum curabitur vitae nunc.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-03.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-04.jpg" alt="">
                <div class="down-content">
                  <h4>Social Media</h4>
                  <p>Pellentesque ultricies diam magna, auctor cursus lectus pretium nec. Maecenas finibus lobortis enim.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-04.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-05.jpg" alt="">
                <div class="down-content">
                  <h4>Digital Arts</h4>
                  <p>Quisque cursus augue ut velit dictum, quis volutpat enim blandit. Maecenas a lectus ac ipsum porta.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-05.png" alt="">
                  </div>
                </div>
              </div>
              <div class="item">
                <img src="Content/home/images/courses-01.jpg" alt="">
                <div class="down-content">
                  <h4>Media Streaming</h4>
                  <p>Pellentesque ultricies diam magna, auctor cursus lectus pretium nec. Maecenas finibus lobortis enim.</p>
                  <div class="author-image">
                    <img src="Content/home/images/author-01.png" alt="">
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

</asp:Content>



<asp:Content ID="JSContent" ContentPlaceHolderID="JavaScriptContent" runat="server">

    <script src="Content/home/js/isotope.min.js"></script>
    <script src="Content/home/js/owl-carousel.js"></script>
    <script src="Content/home/js/lightbox.js"></script>
    <script src="Content/home/js/tabs.js"></script>
    <script src="Content/home/js/video.js"></script>
    <script src="Content/home/js/slick-slider.js"></script>
    <script src="Content/home/js/custom.js"></script>
    <script>
        //according to loftblog tut
        $('.nav li:first').addClass('active');

        var showSection = function showSection(section, isAnimate) {
          var
          direction = section.replace(/#/, ''),
          reqSection = $('.section').filter('[data-section="' + direction + '"]'),
          reqSectionPos = reqSection.offset().top - 0;

          if (isAnimate) {
            $('body, html').animate({
              scrollTop: reqSectionPos },
            800);
          } else {
            $('body, html').scrollTop(reqSectionPos);
          }

        };

        var checkSection = function checkSection() {
          $('.section').each(function () {
            var
            $this = $(this),
            topEdge = $this.offset().top - 80,
            bottomEdge = topEdge + $this.height(),
            wScroll = $(window).scrollTop();
            if (topEdge < wScroll && bottomEdge > wScroll) {
              var
              currentId = $this.data('section'),
              reqLink = $('a').filter('[href*=\\#' + currentId + ']');
              reqLink.closest('li').addClass('active').
              siblings().removeClass('active');
            }
          });
        };

        $('.main-menu, .scroll-to-section').on('click', 'a', function (e) {
          if($(e.target).hasClass('external')) {
            return;
          }
          e.preventDefault();
          $('#menu').removeClass('active');
          showSection($(this).attr('href'), true);
        });

        $(window).scroll(function () {
          checkSection();
        });
    </script>

</asp:Content>