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

    public function GetCalcEntryPoint($DB, $ID, $Iterations)
    {
        //Init our values
        $StartPoint = 0;
        $LastPoint = 0;
        $LastKey = "";

        //Get the last keysquare submitted as an entry point
        $SQL = "CALL ADFGX_GetEntryPoint(".$DB->cleanString($Iterations).")";
        $DB->query($SQL);
        while ($row = $DB->fetchObject())
		{
            if ($row->p_key == "EntryVal")
            {
                $LastPoint = $row->p_val;
            }
            elseif ($row->p_key == "EntryKey")
            {
                $LastKey = $row->p_val;
            }
            elseif ($row->p_key == "NextPoint")
            {
                $StartPoint = $row->p_val;
            }
        }

        //We now have the last keysquare saved to the system, what entry point we need and how many iterations we need
        return array("LastPoint"=>$LastPoint, "LastKey"=>$LastKey, "NextPoint"=>$StartPoint);
    }

    public function RecordKeySquareGeneration($DB, $ID, $CharMap, $EntryPoint)
    {
        $SQL = "UPDATE ADFGX_Permutation_Keys SET perm_value = CASE ";
        $SQL .= " WHEN perm_key = 'EntryKey' THEN '".$DB->cleanString($CharMap)."'";
        $SQL .= " ELSE ".$DB->cleanString($EntryPoint)." END,";
        $SQL .= " perm_last_updated = NOW(), perm_aus_id = ".$DB->cleanString($ID);
        $SQL .= " WHERE perm_key = 'EntryKey' OR perm_key = 'EntryVal'";
        $DB->query($SQL);
        return !$DB->hasErrors();
    }

    public function SaveValidAnswers($DB, $ID, $ResultsArray)
    {
        $Success = true;
        foreach ($ResultsArray as $Key)
        {
            if (!$this->SaveValidResults($DB, $ID, $Key->KeySquare, $Key->CipherText, $Key->MatchingWords))
            {
                $Success = false;
            }
        }
        return $Success;
    }

    public function SaveValidResults($DB, $ID, $KeySquare, $CipherText, $MatchingWords)
    {
        $SQL = "INSERT INTO ADFGX_Valid (VAL_KEYSQUARE, VAL_CIPHER_TEXT, VAL_MATCHING_WORDS) VALUES (";
        $SQL .= "'".$DB->cleanString($KeySquare)."', ";
        $SQL .= "'".$DB->cleanString($CipherText)."', ";
        $SQL .= "'".$DB->cleanString($MatchingWords)."')";
        $DB->query($SQL);

        return (!$DB->hasErrors());
    }

    public function GetDictionary($DB)
    {
        $SQL = "SELECT * FROM ADFGX_Common_Words";
        $DB->query($SQL);
        $i = 0;
        $Dictionary = array();
        while ($row = $DB->fetchObject())
		{
            $Dictionary[$i] = $row->ACW_VAL;
            $i++;
        }        
        return $Dictionary;
    }

    public function GetFilterText($DB)
    {
        $SQL = "SELECT * FROM ADFGX_Valid WHERE VAL_SCORE >= 0 AND VAL_SCORE < 3 LIMIT 1";
        $DB->query($SQL);
        $FilterItem = null;
        while ($row = $DB->fetchObject())
        {
            $FilterItem = array("ID"=>$row->VAL_ID, "CipherText"=>$row->VAL_CIPHER_TEXT, "MatchedWords"=>$row->VAL_MATCHING_WORDS); 
        }
        return $FilterItem;
    }

    public function SaveFilterText($DB, $ID, $Score)
    {
        $SQL = "UPDATE ADFGX_Valid SET VAL_SCORE = VAL_SCORE + " . $DB->cleanString($Score) . " WHERE VAL_ID = " . $DB->cleanString($ID);
        $DB->query($SQL);
        return (!$DB->hasErrors());
    }
}
?>