<div class="SectionContents">
<div id="FilterOutput"><button onclick="Getnext()">Show me what you got</button></div>
</div>
<script>

function Getnext()
{
    APIGetFilterText(function(FilterItem){

        var FilterOutputHTML = "";
        FilterOutputHTML += "<button id=nogood onclick='SaveFilterText(" + FilterItem.ID + ", -1);'>Not even close</button>";
        FilterOutputHTML += "<button id=yegood onclick='SaveFilterText(" + FilterItem.ID + ", 1);'>Looks good</button><h1>";
        FilterOutputHTML += FilterItem.CipherText;
        FilterOutputHTML += "</h1>";
        FilterOutputHTML += "<p>This cipher text was saved because it contains the following words<p><br><h2>";
        FilterOutputHTML += FilterItem.MatchedWords;
        FilterOutputHTML += "<h2>";
        
        document.getElementById("FilterOutput").innerHTML = FilterOutputHTML;
    });
}

function SaveFilterText(ID, Score)
{
    APISaveFilterText(ID, Score, function(Success) {
        if (Success)
        {
            Getnext();
        }
        else 
        {
            document.getElementById("FilterOutput").innerHTML = "Failed to save!";
        }
    });
}

</script>