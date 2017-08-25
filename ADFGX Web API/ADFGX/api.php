<?php

//Make this page JSON based and allow CORS functionality
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type, X-Requested-With");
header("Content-Type: application/json; charset=utf-8");

//header("Access-Control-Allow-Credentials: true");
//header('P3P: CP="CAO PSA OUR"'); // Makes IE to support cookies

//Load all the important PHP Scripts
require_once($_SERVER["DOCUMENT_ROOT"].'/PHP-Classes/Class.PHP-Classes.php');

//print_r($_POST);
if (isset($_POST["Request"]))
{
    //Init the data interface
	$DI = new DataInterface();
    
    //We've gotten a request so we need to create a response packet
    $Response = new Response();

    //Init our Database interface
    $DB = new MySQL();

    //Decode our request object into something PHP Friendly
    $RequestObject = new Request($_POST["Request"]);


    if ($RequestObject->Command == "StartSession")
    {
        $GUID = $DI->StartSession($DB);
        $Response->ResponseObject = $GUID;
    }
    else 
    {
        $UserID = $DI->ValidateSession($DB, $RequestObject->Key);
        if ($UserID > 0)
        {
            if ($RequestObject->Command == "GetKeySquares")
            {
                $KeySquares = $DI->GetKeySquares($DB, $UserID, $RequestObject->Data);
                $Response->ResponseObject = $KeySquares;
            }
            elseif ($RequestObject->Command == "SubmitKeySquare")
            {

            }
            else
            {
                $Response->AddErrorMessage("Command not recognised.");
            }
        }
        else 
        {
            $Response->AddErrorMessage("Session Not Authenticated.");
        }
    }


	//Now encode our response and send it out
	$json = json_encode($Response);
	echo $json;

	//Now some cleanup
	$DB->disconnect();
	unset($DB);
	unset($Request);
	unset($Response);
}
else
{
	echo "Post not detected";
}
ob_flush();
?>