<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error_Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Error Page</title>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />
    <!--end::Fonts -->
    <!--begin::Page Custom Styles(used by this page) -->
    <link href="assets/css/asidedark.css" rel="stylesheet" />
    <link href="assets/css/dark.css" rel="stylesheet" />
    <link href="assets/css/error.css" rel="stylesheet" />
    <link href="assets/css/light.css" rel="stylesheet" />
    <link href="assets/css/menulight.css" rel="stylesheet" />
    <link href="assets/css/plugins.bundle.css" rel="stylesheet" />
    <link href="assets/css/style.bundle.css" rel="stylesheet" />
    <!--end::Layout Skins -->
    <link rel="shortcut icon" href="https://keenthemes.com/metronic/themes/metronic/theme/default/demo1/dist/assets/media/logos/favicon.ico" />
</head>
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--fixed kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-page--loading">
    
        <div class="kt-grid kt-grid--ver kt-grid--root">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid  kt-error-v6" style="background-image: url(Error/assets/media/bg6.jpg);">
                <div class="kt-error_container">
                    <div class="kt-error_subtitle kt-font-light">
                        <h1>Oops...</h1>
                    </div>
                    <p class="kt-error_description kt-font-light">
                        Looks like something went wrong.<br>
                        We're working on it			 
                    </p>
                </div>
            </div>
        </div>
      <form id="form1" runat="server">  
    </form>
    <script>
        var KTAppOptions = {
            "colors": {
                "state": {
                    "brand": "#5d78ff",
                    "dark": "#282a3c",
                    "light": "#ffffff",
                    "primary": "#5867dd",
                    "success": "#34bfa3",
                    "info": "#36a3f7",
                    "warning": "#ffb822",
                    "danger": "#fd3995"
                },
                "base": {
                    "label": [
                        "#c5cbe3",
                        "#a1a8c3",
                        "#3d4465",
                        "#3e4466"
                    ],
                    "shape": [
                        "#f0f3ff",
                        "#d9dffa",
                        "#afb4d4",
                        "#646c9a"
                    ]
                }
            }
        };
        </script>
        <script src="Error/assets/js/plugins.bundle.js"></script>
        <script src="Error/assets/js/scripts.bundle.js"></script>
</body>
</html>
