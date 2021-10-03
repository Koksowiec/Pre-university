<?php
	
	$tytul = $_POST["tytul"];
	$gatunek = $_POST["gatunek"];
	$rok = $_POST["rok"];
	$ocena = $_POST["ocena"];

	$db = mysqli_connect("localhost","root","","dane");
	
	$kw="INSERT INTO filmy(gatunki_id, tytul, rok, ocena) VALUES ('$gatunek','$tytul','$rok','$ocena')";
	
	if($result = mysqli_query($db, $kw))
	{
		echo "Film ".$tytul." został dodany do bazy";
	}
	else
	{
		echo "NIE UDALO SIE DODAC".mysqli_error($db);
	}
	
	mysqli_close($db);
?>