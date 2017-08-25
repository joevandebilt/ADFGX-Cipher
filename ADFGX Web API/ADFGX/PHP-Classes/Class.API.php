<?php

class Request
{
	public $Key = null;
	public $Command = null;
	public $Data = null;
	public $TimeStamp = null;

	public function __construct($JSONString)
	{
		$JSONObject = json_decode($JSONString);

		$this->Key = $JSONObject->{'Key'};
		$this->Command = $JSONObject->{'Command'};
		$this->Data = $JSONObject->{'Data'};
		if (is_string($this->Data))
		{
			//The data is a solid string, so we just need to clean it a bit
			$this->Data = str_replace(' ','+', $this->Data);
		}
		$this->TimeStamp = $JSONObject->{'TimeStamp'};
	}
}

class Response
{
	public $Key = null;
	public $ErrorMessages = null;
	public $ResponseObject = null;
	public $Timestamp = null;

	public function __construct()
	{
		//This is our response key, the client should validate all replies
		$this->Key = "d5740caf-1a42-47d4-b807-dfb572a0736a";
		$this->ErrorMessages = array();
		$this->Timestamp = time();
	}

	public function AddErrorMessage($Error)
	{
		$this->ErrorMessages[COUNT($this->ErrorMessages)] = $Error;
	}
}
?>
