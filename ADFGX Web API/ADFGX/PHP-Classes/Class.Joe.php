<?php
//Joe's handy php functions

//generates a string of alphanumeric characters for a specified length
function generateRandomText($length) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, strlen($characters) - 1)];
    }
    return $randomString;
}

function generateRandomString($length) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!�$%^&*()\/@#;:{}[]-=_+|\<,.>/?';
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, strlen($characters) - 1)];
    }
    return $randomString;
}

//generates a string of numbers for a specified length
function generateRandomNumber($length) {
    $characters = '0123456789';
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, strlen($characters) - 1)];
    }
    return $randomString;
}

//Get a new GUID
function getGUID()
{
    if (function_exists('com_create_guid'))
    {
        return com_create_guid();
    }
    else
    {
        mt_srand((double)microtime()*10000);    //optional for php 4.2.0 and up.
        $charid = strtoupper(md5(uniqid(rand(), true)));
        $hyphen = chr(45);  // "-"
        $uuid =  substr($charid, 0,  8).$hyphen
                .substr($charid, 8,  4).$hyphen
                .substr($charid, 12, 4).$hyphen
                .substr($charid, 16, 4).$hyphen
                .substr($charid, 20, 12);
        return $uuid;
    }
}

//Redirects page to a given location
function PageRedirect($Page) {
		$string = '<script type="text/javascript">';
		$string .= 'window.location = "' . $Page . '"';
		$string .= '</script>';

		echo $string;
}

//Output a read only
function AlertBox($AlertMessage) {
	echo '<script type="text/javascript">alert("'.$AlertMessage.'")</script>';
}

//great for debugging
function Output($OutputMessage) {
	echo '<script type="text/javascript">prompt("Sample Text","'.$OutputMessage.'")</script>';
}

function GetWebsiteURL()
{
    if(isset($_SERVER['HTTPS'])){
        $protocol = ($_SERVER['HTTPS'] && $_SERVER['HTTPS'] != "off") ? "https" : "http";
    }
    else{
        $protocol = 'http';
    }
    return $protocol . "://" . $_SERVER['HTTP_HOST'];// . $_SERVER['REQUEST_URI'];
}
?>