<?php

class DataInterface 
{
    public function StartSession($DB)
    {
        $GenerateKey = getGUID();
        $SQL = "INSERT INTO ADFGX_UserSession (AUS_KEY, AUS_CREATED) VALUES ('".$GenerateKey."', NOW())";
        $DB->query($SQL);

        return $GenerateKey;
    }

    public function ValidateSession($DB, $Key)
    {
        $SQL = "SELECT * FROM ADFGX_UserSession WHERE AUS_KEY = '".$DB->cleanString($Key)."'";
        $DB->query($SQL);

        $result = -1;
        while ($row = $DB->fetchObject())
		{
			$result = $row->AUS_ID;
		}
        return $result;
    }    

    public function GetKeySquares($DB, $ID, $Limit)
    {
        $SQL = "UPDATE ADFGX_Permutations SET perm_status = 1, perm_aus_id = ".$ID." WHERE perm_status = 0 LIMIT ".$Limit;
        $DB->query($SQL);

        $SQL = "SELECT * FROM ADFGX_Permutations WHERE perm_status = 1 AND perm_aus_id = ".$ID;
        $DB->query($SQL);

        $KeySquares = array();
        $i=0;
        while ($row = $DB->fetchObject())
		{
            $KeySquares[$i] = $row->perm_keysquare;
            $i++;
        }
        return $KeySquares;
    }

    public function SaveKeySquare($DB, $ID, $KeySquare, $KeySquareResults)
    {
        $SQL = "UPDATE ADFGX_Permutations SET perm_status = 2";
        for ($x=0; $x < COUNT($KeySquareResults); $x++)
        {
            $SQL .= ", perm_combination_".($x+1)." = '".$KeySquareResults[$x]."'";
        }
        $SQL .= "WHERE perm_keysquare = '".$KeySquare."' PERM_AUS_ID = ".$ID;
    }
    
    public function SaveKeySquares($DB, $ID, $ResultsArray)
    {
        foreach ($ResultsArray as $Key)
        {
            $this->SaveKeySquare($DB, $ID, $key->KeySquare, $key->KeySquareResults);
        }
    }
}
?>