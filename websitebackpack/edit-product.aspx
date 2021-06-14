<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit-product.aspx.cs" Inherits="websitebackpack.edit_product" EnableEventValidation="false" %>

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


    <link href="https://fonts.googleapis.com/css2?family=Quicksand:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

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
                    <a class="nav-link1 page-scroll" href="index.aspx">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link1 page-scroll" href="index.aspx">Services</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link1 page-scroll" href="product-admin.aspx">Products</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link1 page-scroll" href="index.aspx">About</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link1 page-scroll" href="index.aspx">Contact</a>
                </li>

            </ul>
            <span class="nav-item social-icons">
                <span class="fa-stack">
                    <a href="shop-admin.aspx">
                        <i class="fas fa-circle fa-stack-2x shopping"></i>
                        <i class="fas fa-shopping-cart fa-stack-1x"></i>
                    </a>
                </span>
                <span class="fa-stack">
                    <a href="user-admin.aspx">
                        <i class="fas  fa-circle fa-stack-2x user"></i>
                        <i class="far fa-user fa-stack-1x"></i>
                    </a>
                </span>
            </span>
        </div>
    </nav> <!-- end of navbar -->
    <!-- end of navigation -->

    <div id="pricing" class="cards-3">

        <main class="container">
            <div class="row">
                <!-- Left Column Image -->
                <div class="col-lg-8">
                    <h2 class="header-product">Edit Product</h2>
                    <span class="product-back">/</span>
                    <span> <a class="product-back backk" href="product-admin.aspx">Manage Product</a></span>
                   <asp:Image ID="vas" runat="server" class='img-product-detail'  />
                    
                </div>

                <!-- Right Column -->
                <div class="col-md-4">

                    <!-- Product Description -->
                    <div class="product-description">
                         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>

                    <!-- Product Configuration -->
                    <div class="product-configuration">

                        <!-- Cable Configuration -->
                        <div class="cable-config">
                            <span>Cable configuration</span>
                            <div class="button-wrapper">
                                <a class="btn-solid-reg1 page-scroll" href="#request">M</a>
                                <a class="btn-solid-reg1 page-scroll" href="#request">L</a>
                            </div>
                        </div>
                    </div>

                    <div class="card2">
                        <!-- Product Pricing -->
                        <div class="card-body">

                            <div class="price">
                                <span class="currency">$</span>
                                 <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="product-price">

                                <div class="button-wrapper">
                                    <a class="btn-solid-reg page-scroll" runat="server" onserverclick="clickshow" >EDIT</a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <!-- Edit -->
                <div class="col-sm-3">
                </div>
                <asp:Label class="col-sm-6" ID="Label1" runat="server" Text="" >
                     <asp:FileUpload id="imgload"                 
           runat="server"  onchange="ShowButton();">
       </asp:FileUpload>

                        <div class="form-group">
                            <label class="" for="cname">Name</label>
                            <input type="text" runat="server" class="form-control-input1" id="cname" required>
                        </div>
                        <div class="form-group">
                            <label class="" for="number">Price ($)</label>
                            <input type="text" runat="server" class="form-control-input1" id="number" required>
                        </div>
                        <div class="form-group">
                            <label class="" for="Description">Description</label>
                            <textarea class="form-control-input1" runat="server" name="" id="Description" cols="20"
                                rows="5"></textarea>
                        </div>

                    <div class="button-wrapper">
                            <asp:Button class="btn-solid-reg page-scroll" ID="Button1" runat="server" OnClick="save_click" Text="Save" />
                            
                        </div>
                </asp:Label>
                
                        
               
                    
                </div>
                <div class="col-sm-3">
                </div>
                <!-- End Edit -->
        </main>

    </div>

    </div>

    <!-- Footer -->
    <div class="footer1">
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
                    <p class="p-small">Copyright © 2021 <a href="https://www.facebook.com/ht38nhatphan">Template by
                            NhatTin</a> - All rights reserved</p>
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
    <script>

    $('document').ready(function() {
        $("#imgload").change(function() {
            if (this.files && this.files[0]) {
                var reader = new FileReader();
                reader.onload = function(e) {
                    var  a = e.target.result;
                    $('#vas').attr('src', a);
                    
                }
                reader.readAsDataURL(this.files[0]);
                
            }
        });
    });
    
</script>

</html>
