<?php

//Set error reporting level
//comment out in release mode
error_reporting(E_ALL);				
ini_set('display_errors', 'on');	

//Set time zone on each page
date_default_timezone_set("Europe/London");	

//Include Major Classes
require_once($_SERVER['DOCUMENT_ROOT'].'/Classes/Class.MySQL.php');


?>