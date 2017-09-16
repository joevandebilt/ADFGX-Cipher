<head>
<?php
    require_once($_SERVER['DOCUMENT_ROOT'].'/PHP-Classes/Class.Main.php');
?>
</head>
<title>Hello World.</title>
<center>
<h1>ADFGX</h1>
<div class="tab">
<div id=BufferingContainer>
    <button class="tablinks" onclick="OpenTab(event, 'KeySquare');">Calculate Solutions</button>
    <button class="tablinks" onclick="OpenTab(event, 'Filter');">View Solutions</button>
</div>

<div id="KeySquare" class="tabcontent">
    <?php require_once($_SERVER["DOCUMENT_ROOT"].'/Components/Home.Keysquare.php'); ?>
</div>

<div id="Filter" class="tabcontent">
    <?php require_once($_SERVER["DOCUMENT_ROOT"].'/Components/Home.Filter.php'); ?>
</div>
</center>

<script>
    //Javascript for the tabs

    function OpenTab(evt, TabName) 
    {
        // Declare all variables
        var i, tabcontent, tablinks;

        // Get all elements with class="tabcontent" and hide them
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }

        // Get all elements with class="tablinks" and remove the class "active"
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }

        // Show the current tab, and add an "active" class to the button that opened the tab
        document.getElementById(TabName).style.display = "block";
        evt.currentTarget.className += " active";
    }

    function LoadingEvent() {
        document.getElementById("imgBuffering").style.display = "block";
    }

    function LoadingEventComplete() {
        document.getElementById("imgBuffering").style.display = "none";
    }

</script>