<head>
<?php
    require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.Main.php');
?>
</head>
<title>Hello World.</title>
<center>
<h1>ADFGX</h1>
Keysquare Batch Size: <select id="ddlBandwidth">
        <option value=1>1</option>
        <option value=5>5</option>
        <option value=10>10</option>
        <option value=15>15</option>
        <option value=20>20</option>
        <option value=25>25</option>
        <option value=50>50</option>
        <option value=100>100</option>
        <option value=200>200</option>
        <option value=300>300</option>
        <option value=400>400</option>
        <option value=500>500</option>
</select>
<button id=cmdStart onclick="GetKeySquares();">Start Decoding</button><button id=cmdStop onclick="StopProcessing();">Stop Decoding</button><br><br>
<div id="ResultsPane"></div><br>
KeySquares Processed<h2 id=ProcessedBanner>0</h2>
</center>

<script>
var bStopProcessing;
$( document ).ready(function() { document.getElementById("cmdStop").disabled = true; });

    function StopProcessing()
    {
        bStopProcessing = true;
        document.getElementById("cmdStart").disabled = false;
        document.getElementById("cmdStop").disabled = true;   
    }

    function GetKeySquares()
    {
        bStopProcessing = false;
        document.getElementById("cmdStart").disabled = true;
        document.getElementById("cmdStop").disabled = false;
        document.getElementById("ResultsPane").innerHTML = "<p>Starting Decoder process</p>"
        var limit = document.getElementById("ddlBandwidth").value;
        APIGetKeySquares(limit, function(KeySquares) {

            var ResultsHTML;
            var ResultsTable = new Array();
            if (KeySquares.length > 0)
            {
                for (i=0; i < KeySquares.length; i++)
                {
                    //console.log("Decoding keysquare " + (i + 1) + " of " + KeySquares.length);
                    var DecodedResults = DecodeKeySquare(KeySquares[i]);
                    ResultsTable[i] = { "KeySquare":KeySquares[i], "KeySquareResults":DecodedResults };
                }        
                console.log("Finished Decoding This Packet");
                var NewProcessedVal = parseInt(document.getElementById("ProcessedBanner").innerHTML) + KeySquares.length;
                document.getElementById("ProcessedBanner").innerHTML = NewProcessedVal;

                APISaveResults(ResultsTable, function(Success) {
                    if (Success && !bStopProcessing) {
                        GetKeySquares();
                    }
                    else if(!Success) {
                        document.getElementById("ResultsPane").innerHTML = "<p>Failure to save keysquare results. Stopping Decoder</p>";
                        StopProcessing();
                    }
                    else if (bStopProcessing) {
                        document.getElementById("ResultsPane").innerHTML = "<p>Stopping decoder processes</p>";
                        StopProcessing();
                    }
                });
            }
            else 
            {
                document.getElementById("ResultsPane").innerHTML = "<p>No keysquares found. Stopping decoder until more can be generated</p>";
                StopProcessing();
            }            
        });
    }
</script>
