<?php

require_once($_SERVER['DOCUMENT_ROOT'].'/Classes/Class.Main-Classes.php');
$DB = new MySQL();

if (!empty($_GET['KeySquare']))
{
	$KeySquare = $_GET['KeySquare'];
	$DB->query("INSERT INTO ADFGX_Permutations (perm_keysquare, perm_deleted) VALUES ('".$KeySquare."',0)");
}
elseif (!empty($_GET['DecodedKeySquare']))
{
	$KeySquare = $_GET['DecodedKeySquare'];	
	
	$DB = new MySQL();
	$Query = "UPDATE ADFGX_Permutations SET ";
	$Query .= "perm_combination_1 = '".$_GET['val1']."'";
	for ($i=2;$i<=48;$i++)
	{
		$Query .= ", perm_combination_".$i." = '".$_GET['val'.$i]."'";
	}
	$Query .= " WHERE perm_keysquare = '".$KeySquare."'";
	
	//echo $Query;
	$DB->query($Query);
}
elseif (!empty($_GET['NextKeySquare']))
{
	$Query = "SELECT perm_keysquare FROM ADFGX_Permutations WHERE perm_combination_1 IS NULL AND perm_deleted = 0 LIMIT ".rand(1,50).",1";
	$DB->query($Query);
	$row = $DB->fetchObject();

	$KeySquareResult = $row->perm_keysquare;
	echo $KeySquareResult;
}
elseif (!empty($_GET['GetLastPermutation']))
{
	$Query = "SELECT perm_keysquare FROM ADFGX_Permutations ORDER BY perm_keysquare DESC LIMIT 1";
	$DB->query($Query);
	$row = $DB->fetchObject();

	$KeySquareResult = $row->perm_keysquare;
	echo $KeySquareResult;
}
?>
