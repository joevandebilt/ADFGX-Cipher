<?php

//Set error reporting level
//comment out in release mode
error_reporting(E_ALL);				
ini_set('display_errors', 'on');	

//Set time zone on each page
date_default_timezone_set("Europe/London");	

//Include Major Classes
require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.Config.php');
require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.MySQL.php');

//Now the Not so important ones
require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.API.php');
require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.DataInterface.php');
require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.Joe.php');

?>