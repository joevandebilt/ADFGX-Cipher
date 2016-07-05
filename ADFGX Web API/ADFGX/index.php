<head>
<?php
require_once($_SERVER['DOCUMENT_ROOT'].'/Classes/Class.Main-Classes.php');
?>
</head>
<title>Hello World.</title>
<center>
<h1>ADFGX</h1><br><br>
<?php
	
	$DB = new MySQL();
	$DB->query("SELECT COUNT(*) AS RecordCount FROM ADFGX_Permutations");
	$row = $DB->fetchObject();
	$TotalPermutations = $row->RecordCount;
	
	$DB->query("SELECT COUNT(*) AS RecordCount FROM ADFGX_Permutations WHERE perm_combination_1 IS NOT NULL");
	$row = $DB->fetchObject();
	$TotalDecoded = $row->RecordCount;

?>
There are currently <?php echo $TotalPermutations; ?> / 15511210000000000000000000 unique keysquares generated<br>
Of those <?php echo $TotalPermutations; ?>, <?php echo $TotalDecoded; ?> have been decoded.<br><br>

<form action="" method="POST"><font size=1>Expect lengthy search times...</font><br>
Search: <input type=textbox name=txtSearch maxlength=34><input type=submit value=Search name=cmdSearch>
</form>

<?php 
if (!empty($_POST['txtSearch']))
{
	$Query = "SELECT * FROM ADFGX_Permutations WHERE";
	$Query .= " (perm_combination_1 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_2 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_3 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_4 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_5 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_6 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_7 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_8 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_9 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_10 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_11 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_12 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_13 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_14 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_15 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_16 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_17 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_18 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_19 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_20 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_21 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_22 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_23 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_24 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_25 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_26 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_27 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_28 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_29 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_30 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_31 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_32 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_33 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_34 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_35 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_36 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_37 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_38 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_39 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_40 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_41 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_42 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_43 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_44 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_45 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_46 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_47 LIKE '%".$_POST['txtSearch']."%'";
	$Query .= " OR perm_combination_48 LIKE '%".$_POST['txtSearch']."%')";
	$Query .= " AND perm_deleted = 0";
	
	//echo $Query;
	$DB->query($Query);
	
	echo $DB->resultCount()." results found<br>";
	
	echo "<table width=95% border = 1>";
	echo "<th>Keysquare</th><th colspan=48>Results</th>";
	while ($row = $DB->fetchObject())
	{
		echo "<tr>";
		echo "<td><font size=2>".$str = chunk_split($row->perm_keysquare, 5, "<br>")."</font></td>";
		if (strpos($row->perm_combination_1, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_1."</font></td>";
		if (strpos($row->perm_combination_2, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_2."</font></td>";
		if (strpos($row->perm_combination_3, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_3."</font></td>";
		if (strpos($row->perm_combination_4, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_4."</font></td>";
		if (strpos($row->perm_combination_5, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_5."</font></td>";
		if (strpos($row->perm_combination_6, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_6."</font></td>";
		if (strpos($row->perm_combination_7, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_7."</font></td>";
		if (strpos($row->perm_combination_8, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_8."</font></td>";
		if (strpos($row->perm_combination_9, strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_9."</font></td>";
		if (strpos($row->perm_combination_10,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_10."</font></td>";
		if (strpos($row->perm_combination_11,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_11."</font></td>";
		if (strpos($row->perm_combination_12,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_12."</font></td>";
		if (strpos($row->perm_combination_13,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_13."</font></td>";
		if (strpos($row->perm_combination_14,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_14."</font></td>";
		if (strpos($row->perm_combination_15,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_15."</font></td>";
		if (strpos($row->perm_combination_16,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_16."</font></td>";
		if (strpos($row->perm_combination_17,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_17."</font></td>";
		if (strpos($row->perm_combination_18,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_18."</font></td>";
		if (strpos($row->perm_combination_19,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_19."</font></td>";
		if (strpos($row->perm_combination_20,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_20."</font></td>";
		if (strpos($row->perm_combination_21,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_21."</font></td>";
		if (strpos($row->perm_combination_22,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_22."</font></td>";
		if (strpos($row->perm_combination_23,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_23."</font></td>";
		if (strpos($row->perm_combination_24,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_24."</font></td>";
		if (strpos($row->perm_combination_25,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_25."</font></td>";
		if (strpos($row->perm_combination_26,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_26."</font></td>";
		if (strpos($row->perm_combination_27,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_27."</font></td>";
		if (strpos($row->perm_combination_28,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_28."</font></td>";
		if (strpos($row->perm_combination_29,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_29."</font></td>";
		if (strpos($row->perm_combination_30,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_30."</font></td>";
		if (strpos($row->perm_combination_31,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_31."</font></td>";
		if (strpos($row->perm_combination_32,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_32."</font></td>";
		if (strpos($row->perm_combination_33,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_33."</font></td>";
		if (strpos($row->perm_combination_34,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_34."</font></td>";
		if (strpos($row->perm_combination_35,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_35."</font></td>";
		if (strpos($row->perm_combination_36,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_36."</font></td>";
		if (strpos($row->perm_combination_37,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_37."</font></td>";
		if (strpos($row->perm_combination_38,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_38."</font></td>";
		if (strpos($row->perm_combination_39,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_39."</font></td>";
		if (strpos($row->perm_combination_40,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_40."</font></td>";
		if (strpos($row->perm_combination_41,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_41."</font></td>";
		if (strpos($row->perm_combination_42,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_42."</font></td>";
		if (strpos($row->perm_combination_43,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_43."</font></td>";
		if (strpos($row->perm_combination_44,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_44."</font></td>";
		if (strpos($row->perm_combination_45,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_45."</font></td>";
		if (strpos($row->perm_combination_46,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_46."</font></td>";
		if (strpos($row->perm_combination_47,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_47."</font></td>";
		if (strpos($row->perm_combination_48,strtoupper($_POST['txtSearch'])) !== false) echo "<td><font size=1>".$row->perm_combination_48."</font></td>";
		echo "</tr>";
	}
	echo "</table>";
}
?>
<center>
