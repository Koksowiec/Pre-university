<!doctype html>
<html lang="pl" dir="ltr">
<head>
	<meta charset="utf-8">
	<title>Prognoza pogody Poznań</title>
    <link rel="stylesheet" type="text/css" href="styl4.css">
</head>
<body>
	<div class="baner">
		<div class="baner-lewy">
			<p>maj, 2019</p>
		</div>
		<div class="baner-srodkowy">
			<h2>Prognoza dla Poznania</h2>
		</div>
		<div class="baner-prawy">
			<img src="logo.png" alt="prognoza"/>
		</div>
	</div>
	<div class="lewy">
		<a href="kwerendy.txt">Kwerendy</a>
	</div>
	<div class="prawy">
		<img src="obraz.jpg" alt="Polska, Poznań"/>
	</div>
	<div class="glowny">
		<table>
			<tr>
				<th>Lp.</th>
				<th>DATA</th>
				<th>NOC - TEMPERATURA</th>
				<th>DZIEŃ - TEMPERATURA</th>
				<th>OPDAY [mm/h]</th>
				<th>CIŚNIENIE [hPa]</th>
			</tr>
			<?php
				$db = mysqli_connect("localhost","root","","prognoza");
				
				$kw = mysqli_query($db, "SELECT * FROM pogoda WHERE pogoda.miasta_id = 2 ORDER BY pogoda.data_prognozy DESC");
				while($wynik = mysqli_fetch_row($kw))
				{
					echo "<tr>";
					echo "<td>".$wynik[0]."</td>";
					echo "<td>".$wynik[2]."</td>";
					echo "<td>".$wynik[3]."</td>";
					echo "<td>".$wynik[4]."</td>";
					echo "<td>".$wynik[5]."</td>";
					echo "<td>".$wynik[6]."</td>";
					echo "</tr>";
				}
				
				mysqli_close($db);
			?>
		</table>
	</div>
	<div class="stopka">
		<p>Stronę wykonał: 01230500919</p>
	</div>
</body>
</html>