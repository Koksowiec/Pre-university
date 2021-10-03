<!doctype html>
<html lang="pl" dir="ltr">
<head>
	<meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="styl_1.css">
	<title>Wędkujemy</title>
</head>
<body>
	<div class="baner">
		<h1>Portal dla wędkarzy</h1>
	</div>
	<div class="lewy">
		<h2>Ryby drapieżne naszych wód</h2>
		<ul>
			<?php
				$db = mysqli_connect("localhost","root","","wedkowanie");
				
				$sql="SELECT ryby.nazwa, ryby.wystepowanie FROM ryby WHERE ryby.styl_zycia = 1";
				
				$kw = mysqli_query($db, $sql);
				
				while($wynik = mysqli_fetch_row($kw))
				{
					echo "<li>".$wynik[0].", występowanie: ".$wynik[1]."</li>";
				}
			
				mysqli_close($db);
			?>
		</uL>
	</div>
	<div class="prawy">
		<img src="ryba1.jpg" alt="Sum"/>
		<a href="kwerendy.txt">Pobierz kwerendy</a>
	</div>
	<div class="stopka">
		<p>Stronę wykonał: 01230500919</p>
	</div>
</body>
</html>