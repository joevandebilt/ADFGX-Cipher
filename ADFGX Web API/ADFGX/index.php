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
<button id=cmdStart onclick="DecoderTick();">Start Decoding</button><button id=cmdStop onclick="StopProcessing();">Stop Decoding</button><br><br>
<!--<button onclick="TestNewFeature();">Test New Feature</button>-->
<div id="ResultsPane"></div><br>
KeySquares Processed<h2 id=ProcessedBanner>0</h2>
</center>

<script>
var bStopProcessing;
var WordArray;

$( document ).ready(function() { 
    document.getElementById("cmdStop").disabled = true;  
    WordArray = null;
});

    function StopProcessing()
    {
        bStopProcessing = true;
        document.getElementById("cmdStart").disabled = false;
        document.getElementById("cmdStop").disabled = true;   
    }

    function DecoderTick()
    {
        bStopProcessing = false;
        document.getElementById("cmdStart").disabled = true;
        document.getElementById("cmdStop").disabled = false;
        document.getElementById("ResultsPane").innerHTML = "<p>Starting Decoder process</p>"
        var Limit = document.getElementById("ddlBandwidth").value;
       
        if (WordArray == null)
        {
            APIGetDictionary(function(APIDictonary) {

                if (APIDictonary.length > 0)
                {
                    WordArray = APIDictonary.slice(0);
                    DecoderTick();
                }
                else 
                {
                    document.getElementById("ResultsPane").innerHTML = "<p>Problem initialising language array.</p>";
                    StopProcessing();
                }
            });
        }
        else 
        {
            APIGetCalcEntryPoint(Limit, function(EntryPoint) 
            {
                console.log('Generating KeySquares');
                var KeySquares = GenerateKeySquares(EntryPoint.LastPoint, EntryPoint.LastKey, EntryPoint.NextPoint, Limit);

                var ResultsHTML;
                var ResultsTable = new Array();
                if (KeySquares.length > 0)
                {

                    //Record how many Keysquares we've got now
                    APIRecordKeySquareGeneration({"CharMap":ToCharMap(KeySquares[KeySquares.length-1]), "EntryPoint":(parseInt(EntryPoint.NextPoint) + parseInt(Limit) - 1)}, function(Success) {
                        //This is an async call so we can just keep going now
                        if (Success)
                        {
                            //Yes nice one
                        }
                    });

                    console.log('Decoding those keysquares');
                    for (i=0; i < KeySquares.length; i++)
                    {
                        //console.log("Decoding keysquare " + (i + 1) + " of " + KeySquares.length);
                        var DecodedResults = DecodeKeySquare(KeySquares[i]);
                        ResultsTable[i] = { "KeySquare":KeySquares[i], "KeySquareResults":DecodedResults };
                    }        
                    console.log("Finished Decoding this Packet");
                    var NewProcessedVal = parseInt(document.getElementById("ProcessedBanner").innerHTML) + KeySquares.length;
                    document.getElementById("ProcessedBanner").innerHTML = NewProcessedVal;

                    

                    //Start Language Interface
                    var FinalResults = new Array();
                    var z=0;
                    for (x=0; x < ResultsTable.length; x++)
                    {
                        for (y=0; y < ResultsTable[x].KeySquareResults.length; y++)
                        {
                            var WordsFound = ParseCipherText(WordArray, ResultsTable[x].KeySquareResults[y]);
                            if (WordsFound != "")
                            {
                                FinalResults[z] = { "KeySquare":ResultsTable[x].KeySquare, "CipherText":ResultsTable[x].KeySquareResults[y], "MatchingWords":WordsFound };
                                z++;
                            }
                        }
                    }

                    
                    if (FinalResults.length > 0)
                    {
                        //Now save our valid replies
                        APISaveValidAnswers(FinalResults, function(Success) {
                            if (Success && !bStopProcessing) {
                                DecoderTick();
                            }
                            else if(!Success) {
                                document.getElementById("ResultsPane").innerHTML = "<p>Failure to save KeySquare results. Stopping Decoder</p>";
                                StopProcessing();
                            }
                            else if (bStopProcessing) {
                                document.getElementById("ResultsPane").innerHTML = "<p>Stopping decoder processes</p>";
                                StopProcessing();
                            }
                        });
                    }
                    else if (!bStopProcessing) 
                    {
                        DecoderTick();
                    }
                    else 
                    {
                        document.getElementById("ResultsPane").innerHTML = "<p>Stopping decoder processes.</p>";
                        StopProcessing();
                    }
                }
                else 
                {
                    document.getElementById("ResultsPane").innerHTML = "<p>No keysquares found. Stopping decoder until more can be generated</p>";
                    StopProcessing();
                }
            });    
        }        
    }
</script>
