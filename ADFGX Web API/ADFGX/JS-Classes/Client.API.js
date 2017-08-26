/* 
	API SETTINGS
*/

function getValue(Key)
{
	var Value = null;
	switch(Key) { 
		case "ReturnKey":
			Value = "d5740caf-1a42-47d4-b807-dfb572a0736a";
			break;
		case "EndPoint":
			Value = "https://adfgx.nkode.uk/api.php";											//User Testing Server
			break;
		case "DebugOptions":
			Value = true;	//Switch to false to stop console logging
			break;	
		case "CookieExpireDays":
			Value = 1;		//How long to keep client cookies for (in days)
			break;
	}
	return Value;
}

/*
	MAIN API FUNCTIONS

*/
function APIStartSession()
{
	if (getCookie('SessionID') == "")
	{
 		var DataPacket = ConstructDataPacket("StartSession",null);
		SendJSONPacket(DataPacket, function(SessionID) {
			setCookie("SessionID", SessionID, getValue("CookieExpireDays"));
		});
	}
}

function APIGetKeySquares(Limit, CallbackFunction)
{
	var DataPacket = ConstructDataPacket("GetKeySquares", Limit);
	SendJSONPacket(DataPacket, CallbackFunction);
}

function APISaveResults(ResultsTable, CallbackFunction)
{
	var DataPacket = ConstructDataPacket("SaveKeySquares", ResultsTable);
	SendJSONPacket(DataPacket, CallbackFunction);
}


/* 
	API OPERATION FUNCTIONS 
*/
function ConstructDataPacket(command, data)
{
    var RequestObject = { "Key":getCookie('SessionID'), "Command":command, "Data":data, "TimeStamp":Date.now() };
    return RequestObject;
}

function SendJSONPacket(DataPacket, CallbackFunction)
{
	if (getValue('DebugOptions')) console.log(DataPacket);

	//Send the request to the API via ajax
	$.ajax({ 
		url: getValue('EndPoint'),
		data: { 'Request' : JSON.stringify(DataPacket) },
		type: 'POST',
		ContentType: 'JSON',
		success: function(response) 
		{ 	
			//Get the response data from our validate procedure
			var ResponseData = ValidateJSONResponse(response);

			if (getValue('DebugOptions')) console.log("Passing '" + ResponseData + "' to callback function");
			
			//Response data will be null if validation rules not met, the callback function should be able to handle this
			CallbackFunction(ResponseData);
		},
		error: function (xhr, ajaxOptions, thrownError) 
		{
			//There was a problem with the AJAX call - report it
			if (getValue('DebugOptions')) {
				console.log(xhr.responseText);
				console.log(thrownError);
			}
		}
	});	
}

//Parameters: JSON Response Object
//Returns: Response data, depending on validation rules met
function ValidateJSONResponse(jsonObject)
{
	//Debug Option
	if (getValue('DebugOptions')) console.log(jsonObject);
	
	//Our Response should be a standard response object
	try {
		
		//It should already be an object so we don't need to parse it anymore
		//var JSONResponse = JSON.parse(jsonObject);
		var JSONResponse = jsonObject;
		
		//Decode the response items	
		var ResponseKey = JSONResponse.Key;
		if (getValue('ReturnKey') != ResponseKey)
		{
			//The reply is not from our server, abandon!
			if (getValue('DebugOptions')) console.log("API Response Key is not valid");
			return null;
		}
		
		var ErrorMessages = JSONResponse.ErrorMessages; //Array
		if (ErrorMessages != null && ErrorMessages.length > 0) 
		{
			//Errors have been returned by the API
			if (getValue('DebugOptions')) console.log(ErrorMessages);
			return null;
		}
		
		var TimeStamp = JSONResponse.ResponseObject;   	//String
		if (TimeStamp > Date.now() )
		{
			//Response is from the future?
			if (getValue('DebugOptions')) console.log("Response if from the future, potential validation rule?");
			//return null;
		}
		
		var ResponseData = JSONResponse.ResponseObject;	//varying Object
		return ResponseData;
	}
	catch(err) 
	{
		//The JSON object is not formatted - likely to be a PHP error. Output it to console for debugging and return null
		if (getValue('DebugOptions')) console.log(err.message);
		return null;
	}
}
$.support.cors = true;
$( document ).ready(function() { APIStartSession() });