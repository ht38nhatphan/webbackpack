<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs"  Inherits="websitebackpack.index" EnableEventValidation="false" %>

<!DOCTYPE html>
<script type="text/javascript">
    function call_click(clicked_id) {
        var name = clicked_id;
        '<%Session["IDindex"] = "' + name + '"; %>';
    }
    function showdetail(clicked_id) {
        var name = clicked_id;
    }
    
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Website Title -->
    <title>Backpack - Backpack Store</title>

    <!-- Styles -->
    <link href="https://fonts.googleapis.com/css?family=Raleway:400,400i,600,700,700i&amp;subset=latin-ext"
        rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/fontawesome-all.css" rel="stylesheet">

    <!-- Favicon  -->
    <link rel="icon" href="img/favicon.png">
</head>
<body data-spy="scroll" data-target=".fixed-top">
    <form id="form1" runat="server">
        
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark navbar-custom fixed-top">
        <!-- Text Logo - Use this if you don't have a graphic logo -->
        <!-- <a class="navbar-brand logo-text page-scroll" href="index.html">Evolo</a> -->

        <!-- Image Logo -->
        <a class="navbar-brand logo-image" href="index.aspx"><img src="img/logo.png" alt="alternative"></a>


        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#header">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#services">Services</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#pricing">Products</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#about">About</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#contact">Contact</a>
                </li>

            </ul>
            <span class="nav-item social-icons">
                <span class="fa-stack">
                    <a runat="server" onserverclick ="shopclick" >
                        <i class="fas fa-circle fa-stack-2x shopping"></i>
                        <i class="fas fa-shopping-cart fa-stack-1x"></i>
                    </a>
                </span>
                <span class="fa-stack">
                    <a runat="server" onserverclick ="userclick">
                        <i class="fas  fa-circle fa-stack-2x user"></i>
                        <i class="far fa-user fa-stack-1x"></i>
                    </a>
                </span>
            </span>
        </div>
    </nav> <!-- end of navbar -->
    <!-- end of navigation -->


    <!-- Header -->
    <header id="header" class="header">
        <div class="header-content">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="text-container">
                            <h1><span class="turquoise">Backpack Store</span> Page Sales Balo</h1>
                            <p class="p-large">Website Backpack Store created for customers to conveniently shop online
                            </p>
                            <a class="btn-solid-lg page-scroll" href="#services">DISCOVER</a>
                        </div> <!-- end of text-container -->
                    </div> <!-- end of col -->
                    <div class="col-lg-6">
                        <div class="image-container">
                            <img class="img-fluid" src="img/banner.png" alt="alternative">
                        </div> <!-- end of image-container -->
                    </div> <!-- end of col -->
                </div> <!-- end of row -->
            </div> <!-- end of container -->
        </div> <!-- end of header-content -->
    </header> <!-- end of header -->
    <!-- end of header -->

    <!-- Services -->
    <div id="services" class="cards-1">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Services</h2>
                    <p class="p-heading p-large">The website will have the following utility services, please take a
                        look to experience the website in the most optimal way</p>
                </div> <!-- end of col -->
            </div> <!-- end of row -->
            <div class="row">
                <div class="col-lg-12" runat="server" id ="add_services">

                </div> <!-- end of col -->
            </div> <!-- end of row -->
        </div> <!-- end of container -->
    </div> <!-- end of cards-1 -->
    <!-- end of services -->

    <!-- Pricing -->
    <div id="pricing" class="cards-2" >
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Best Sellers</h2>
                    <p class="p-heading p-large">The best selling products at the moment</p>
                </div> <!-- end of col -->
            </div> <!-- end of row -->
            <div class="row">
                <div class="col-lg-12" runat="server" id="show">

                </div> 
                <div class="col-lg-12" class="button-wrapper">
                         <a class="btn-solid-reg page-scroll" runat="server" onserverclick ="showall_click">SHOW ALL</a>
                    </div><!-- end of col -->
            </div> <!-- end of row -->
        </div> <!-- end of container -->
    </div> <!-- end of cards-2 -->
    <!-- end of pricing -->

    <!-- About -->
    <div id="about" class="basic-4">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>About The Team</h2>
                    <p class="p-heading p-large">Our team consists of 2 members, each of whom contributed to the creation of this website</p>
                </div> <!-- end of col -->
            </div> <!-- end of row -->
            <div class="row">
                <div class="col-lg-12">

                    <!-- Team Member -->
                    <div class="team-member">
                        <div class="image-wrapper">
                            <img class="img-fluid" src="img/team1.jpg" alt="alternative">
                        </div> <!-- end of image-wrapper -->
                        <p class="p-large"><strong>Nguyen Dinh Tin</strong></p>
                        <p class="job-title">Designer</p>
                        <span class="social-icons">
                            <span class="fa-stack">
                                <a href="https://www.facebook.com/nguyendinhductin/ " target="_blank">
                                    <i class="fas fa-circle fa-stack-2x facebook"></i>
                                    <i class="fab fa-facebook-f fa-stack-1x"></i>
                                </a>
                            </span>
                            <span class="fa-stack">
                                <a href="https://www.instagram.com/n_d_t.20/ " target="_blank">
                                    <i class="fas fa-circle fa-stack-2x twitter"></i>
                                    <i class="fab fa-instagram fa-stack-1x"></i>
                                </a>
                            </span>
                        </span> <!-- end of social-icons -->
                    </div> <!-- end of team-member -->
                    <!-- end of team member -->

                    <!-- Team Member -->
                    <div class="team-member">
                        <div class="image-wrapper">
                            <img class="img-fluid" src="img/team2.jpg" alt="alternative">
                        </div> <!-- end of image wrapper -->
                        <p class="p-large"><strong>Phan Van Nhat</strong></p>
                        <p class="job-title">Programmer</p>
                        <span class="social-icons">
                            <span class="fa-stack">
                                <a href="#your-link">
                                    <i class="fas fa-circle fa-stack-2x facebook"></i>
                                    <i class="fab fa-facebook-f fa-stack-1x"></i>
                                </a>
                            </span>
                            <span class="fa-stack">
                                <a href="#your-link">
                                    <i class="fas fa-circle fa-stack-2x twitter"></i>
                                    <i class="fab fa-instagram fa-stack-1x"></i>
                                </a>
                            </span>
                        </span> <!-- end of social-icons -->
                    </div> <!-- end of team-member -->
                    <!-- end of team member -->

                </div> <!-- end of col -->
            </div> <!-- end of row -->
        </div> <!-- end of container -->
    </div> <!-- end of basic-4 -->
    <!-- end of about -->


    <!-- Contact -->
    <div id="contact" class="form-2">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Contact Information</h2>
                    <ul class="list-unstyled li-space-lg">
                        <li class="address">Don't hesitate to give us a call or send us a contact form message</li>
                        <li><i class="fas fa-map-marker-alt"></i> 182 Le Duan, Ben Thuy, Vinh City, Nghe An</li>
                        <li><i class="fas fa-phone"></i><a class="turquoise" href="tel:003024630820">+84 975 617 669</a>
                        </li>
                        <li><i class="fas fa-envelope"></i><a class="turquoise"
                                href="mailto:office@evolo.com">dhv@vinhuni.edu.vn</a></li>
                    </ul>
                </div> <!-- end of col -->
            </div> <!-- end of row -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="map-responsive">
                        <iframe
                            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3780.1104339687013!2d105.69467821182063!3d18.65903973134359!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3139cddf0bf20f23%3A0x86154b56a284fa6d!2sVinh%20University!5e0!3m2!1sen!2sro!4v1622022482922!5m2!1sen!2sro"
                            allowfullscreen></iframe>
                    </div>
                </div> <!-- end of col -->
                <div class="col-lg-6">

                    <!-- Contact Form -->
                    <form id="contactForm" data-toggle="validator" data-focus="false" >
                        <div class="form-group">
                            <input type="text" class="form-control-input" id="cname"  runat="server">
                            <label class="label-control" for="cname">Name</label>
                        </div>
                        <div class="form-group">
                            <input type="email" class="form-control-input" id="cemail" onloadstart="test1" runat="server">
                            <label class="label-control" for="cemail">Email</label>
                        </div>
                        <div class="form-group">
                            <textarea class="form-control-textarea" id="cmessage" onchange="test2" runat="server"></textarea>
                            <label class="label-control" for="cmessage">Your message</label>
                         </div>
                        
                        <div class="form-group checkbox">
                            <input type="checkbox" id="cterms" value="Agreed-to-Terms" onchange="test3"  runat="server">I have read and agree
                            with Evolo's stated <a href="privacy-policy.html">Privacy Policy</a> and <a
                                href="terms-conditions.html">Terms Conditions</a>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="form-control-submit-button" runat="server" onserverclick="Feedback_click" >SUBMIT MESSAGE</button>
                        </div>
                        <div class="form-message">
                            <div id="cmsgSubmit" class="h3 text-center hidden"></div>
                        </div>
                    </form>
                    <!-- end of contact form -->

                </div> <!-- end of col -->
            </div> <!-- end of row -->
        </div> <!-- end of container -->
    </div> <!-- end of form-2 -->
    <!-- end of contact -->


    <!-- Footer -->
    <div class="footer">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="footer-col">
                        <h4>About Page</h4>
                        <p>The website we created to help backpack stores promote products and sell directly on the
                            site, was created in May 2021.</p>
                    </div>
                </div> <!-- end of col -->
                <div class="col-md-4">
                    <div class="footer-col middle">
                        <h4>Important Links</h4>
                        <ul class="list-unstyled li-space-lg">
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body">Useful: <a class="turquoise"
                                        href="https://www.w3schools.com/bootstrap/bootstrap_get_started.asp"
                                        target="_blank">Bootstrap</a> <span> <a class="turquoise"
                                            href="https://fontawesome.com/v5.15/how-to-use/on-the-web/setup/hosting-font-awesome-yourself?fbclid=IwAR14bbMo4TecCAtnHCG4ItU3SwQ9Il2qvWfweU2Q3QEoNk6lkFpAj331QXA"
                                            target="_blank">, Font Awesome</a></span> </div>
                            </li>
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body">Read our <a class="turquoise" href="terms-conditions.html">Terms
                                        & Conditions</a>, <a class="turquoise" href="privacy-policy.html">Privacy
                                        Policy</a></div>
                            </li>
                        </ul>
                    </div>
                </div> <!-- end of col -->
                <div class="col-md-4">
                    <div class="footer-col last">
                        <h4>Social Media</h4>
                        <span class="fa-stack">
                            <a href="#your-link">
                                <i class="fas fa-circle fa-stack-2x"></i>
                                <i class="fab fa-facebook-f fa-stack-1x"></i>
                            </a>
                        </span>
                        <span class="fa-stack">
                            <a href="#your-link">
                                <i class="fas fa-circle fa-stack-2x"></i>
                                <i class="fab fa-twitter fa-stack-1x"></i>
                            </a>
                        </span>
                        <span class="fa-stack">
                            <a href="#your-link">
                                <i class="fas fa-circle fa-stack-2x"></i>
                                <i class="fab fa-google-plus-g fa-stack-1x"></i>
                            </a>
                        </span>
                        <span class="fa-stack">
                            <a href="#your-link">
                                <i class="fas fa-circle fa-stack-2x"></i>
                                <i class="fab fa-instagram fa-stack-1x"></i>
                            </a>
                        </span>
                        <span class="fa-stack">
                            <a href="#your-link">
                                <i class="fas fa-circle fa-stack-2x"></i>
                                <i class="fab fa-linkedin-in fa-stack-1x"></i>
                            </a>
                        </span>
                    </div>
                </div> <!-- end of col -->
            </div> <!-- end of row -->
        </div> <!-- end of container -->
    </div> <!-- end of footer -->
    <!-- end of footer -->


    <!-- Copyright -->
    <div class="copyright">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p class="p-small">Copyright © 2021 <a href="https://www.facebook.com/ht38nhatphan">Template by NhatTin</a> - All rights                        reserved</p>
                </div> <!-- end of col -->
            </div> <!-- enf of row -->
        </div> <!-- end of container -->
    </div> <!-- end of copyright -->
    <!-- end of copyright -->


    <!-- Scripts -->
    <script src="js/jquery.min.js"></script> <!-- jQuery for Bootstrap's JavaScript plugins -->
    <script src="js/popper.min.js"></script> <!-- Popper tooltip library for Bootstrap -->
    <script src="js/bootstrap.min.js"></script> <!-- Bootstrap framework -->
    <script src="js/jquery.easing.min.js"></script> <!-- jQuery Easing for smooth scrolling between anchors -->
    <script src="js/swiper.min.js"></script> <!-- Swiper for image and text sliders -->
    <script src="js/jquery.magnific-popup.js"></script> <!-- Magnific Popup for lightboxes -->
    <script src="js/validator.min.js"></script> <!-- Validator.js - Bootstrap plugin that validates forms -->
    <script src="js/scripts.js"></script> <!-- Custom scripts -->
    </form>
</body>
</html>
