<?php

    //This will load the main site classes
    //If you need a non-html encrypted page (JSON/XML) then you need to just load Class.PHP 

    //PHP Classes
    require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.PHP-Classes.php');

    //CSS Styles
    echo '<link rel="stylesheet" type="text/css" href="https://'.$_SERVER['SERVER_NAME'].'/CSS/Site-CSS.css" />';

    //Javascript Libraries
    echo '<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>'; 
    echo '<script type="text/javascript" src="https://'.$_SERVER['SERVER_NAME'].'/JS-Classes/Client.Cookie.js"></script>';
    echo '<script type="text/javascript" src="https://'.$_SERVER['SERVER_NAME'].'/JS-Classes/Client.API.js"></script>';
    echo '<script type="text/javascript" src="https://'.$_SERVER['SERVER_NAME'].'/JS-Classes/Client.ADFGX.js"></script>';
?>