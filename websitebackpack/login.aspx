<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="websitebackpack.login" %>

<!DOCTYPE html>

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
                    <a runat ="server" id ="home" class="nav-link1 page-scroll" href="index.aspx">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a runat ="server" id="service" class="nav-link1 page-scroll" href="index.aspx">Services</a>
                </li>
                <li class="nav-item">
                    <a runat ="server" id ="product" class="nav-link1 page-scroll" href="index.aspx">Products</a>
                </li>

                <li class="nav-item">
                    <a runat ="server" id="about" class="nav-link1 page-scroll" href="index.aspx">About</a>
                </li>

                <li class="nav-item">
                    <a runat ="server" id ="contact" class="nav-link1 page-scroll" href="index.aspx">Contact</a>
                </li>

            </ul>
            <span class="nav-item social-icons">
                <span class="fa-stack">
                    <a runat ="server" id ="shop" >
                        <i class="fas fa-circle fa-stack-2x shopping"></i>
                        <i class="fas fa-shopping-cart fa-stack-1x"></i>
                    </a>
                </span>
            <span class="fa-stack">
                    <a runat ="server" id ="profile">
                        <i class="fas  fa-circle fa-stack-2x user"></i>
                        <i class="far fa-user fa-stack-1x"></i>
                    </a>
                </span>
            </span>
        </div>
    </nav>
    <!-- end of navbar -->
    <!-- end of navigation -->

   <header id="header1" class="header1">
        <div class="header-content1">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="text-container">
                            <h2>Log In</h2>
                            <form id="contactForm" data-toggle="validator" data-focus="false">
                                <div class="form-group">
                                    <input runat="server" type="email" class="form-control-input" id="email" required>
                                    <label class="label-control" for="email">Email</label>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group">
                                    <input runat ="server" type="password" class="form-control-input" id="pass" required>
                                    <label class="label-control" for="pass">Password</label>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group">
                                    <button runat ="server" OnServerClick="sumit1_click" type="submit" class="form-control-submit-button">LOG IN</button>
                                </div>
                            </form>
                        </div>
                        <!-- end of text-container -->
                    </div>
                    <!-- end of col -->
                    <div class="col-lg-6">
                        <div class="text-container">
                            <h2>Sign Up</h2>
                                <div class="form-group">

                                    <input runat ="server" type="text" class="form-control-input" id="cname" required>
                                    <label class="label-control" for="cname">Name</label>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group">
                                    <input runat ="server" type="email" class="form-control-input" id="cemail" required>
                                    <label class="label-control" for="cemail">Email</label>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group">
                                    <input runat ="server" type="password" class="form-control-input" id="cpass" required>
                                    <label class="label-control" for="cpass">Password</label>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group checkbox">
                                    <input runat ="server" type="checkbox" id="cterms" value="Agreed-to-Terms" required>I have read and agree with Evolo's stated <a href="privacy-policy.html">Privacy Policy</a> and <a href="terms-conditions.html">Terms Conditions</a>
                                    <div class="help-block with-errors"></div>
                                </div>
                                <div class="form-group">
                                    <button runat ="server" onserverclick="sumit2_click" type="submit" class="form-control-submit-button">SIGN UP</button>
                                </div>
                            
                        </div>
                        <!-- end of text-container -->
                    </div>
                    <!-- end of col -->
                </div>
                <!-- end of row -->
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            <!-- end of container -->
        </div>
        <!-- end of header-content -->
    </header>
    <!-- end of header -->
    <!-- end of header -->

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
