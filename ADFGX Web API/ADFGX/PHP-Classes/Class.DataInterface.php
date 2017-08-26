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
        $SQL = "UPDATE ADFGX_Permutations SET perm_status = 1, perm_aus_id = ".$DB->cleanString($ID).", perm_last_updated = NOW() WHERE perm_status = 0 LIMIT ".$DB->cleanString($Limit);
        $DB->query($SQL);

        $SQL = "SELECT * FROM ADFGX_Permutations WHERE perm_status = 1 AND perm_aus_id = ".$DB->cleanString($ID);
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
        $SQL = "UPDATE ADFGX_Permutations SET perm_status = 2, perm_last_updated = NOW()";
        for ($x=0; $x < COUNT($KeySquareResults); $x++)
        {
            $SQL .= ", perm_combination_" . ($x+1) . " = '" . $DB->cleanString($KeySquareResults[$x]) . "'";
        }
        $SQL .= " WHERE perm_keysquare = '".$DB->cleanString($KeySquare)."' AND PERM_AUS_ID = ".$DB->cleanString($ID);
        $DB->query($SQL);

        return !$DB->hasErrors();
    }
    
    public function SaveKeySquares($DB, $ID, $ResultsArray)
    {
        $Success = true;
        foreach ($ResultsArray as $Key)
        {
            if (!$this->SaveKeySquare($DB, $ID, $Key->KeySquare, $Key->KeySquareResults))
            {
                $Success=false;
            }
        }
        return $Success;
    }
}
?>