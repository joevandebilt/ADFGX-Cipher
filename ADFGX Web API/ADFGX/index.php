<head>
<?php
    require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.Main.php');
?>
</head>
<title>Hello World.</title>
<center>
<h1>ADFGX</h1>
<button onclick="GetKeySquares(50);">Get 50 KeySquares</button><br>
<div id="ResultsPane"></div>
</center>

<script>
function GetKeySquares(limit)
{
    APIGetKeySquares(limit, function(KeySquares) {

        var ResultsHTML;
        if (KeySquares.length > 0)
        {
            ResultsHTML = '<ul>';
            for (i=0; i< KeySquares.length; i++)
            {
                ResultsHTML += '<li>' + KeySquares[i] + '</li>';
            }        
            ResultsHTML += '</ul>';
        }
        else 
        {
            ResultsHTML = "<p>No Results Found</p>";
        }
        document.getElementById("ResultsPane").innerHTML = ResultsHTML

    });
}
</script>
