<!doctype html>
<html lang="pl" dir="ltr">
<head>
	<meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="styl1.css">
	<title>Portal ogłoszeniowy</title>
</head>
<body>
	<div class="baner">
		<h1>Portal Ogłoszeniowy</h1>
	</div>
	<div class="lewy">
		<h2>Kategorie ogłoszeń</h2>
		<ol>
			<li>Książki</li>
			<li>Muzyka</li>
			<li>Filmy</li>
		</ol>
		<img src="ksiazki.jpg" alt="Kupię / sprzedam książkę"/>
		<table>
			<tr>
				<td>Liczba ogłoszeń</td>
				<td>Cena ogłoszenia</td>
				<td>Bonus</td>
			</tr>
			<tr>
				<td>1 - 10</td>
				<td>1 PLN</td>
				<td rowspan="3"> Subskrypcja newslettera to upust 0,20 PLN na ogłoszenie</td>
			</tr>
			<tr>
				<td>11 - 50</td>
				<td>0,80 PLN</td>
			</tr>
			<tr>
				<td>51 i więcej</td>
				<td>0,60 PLN</td>
			</tr>
		</table>
	</div>
	<div class="prawy">
		<h2>Ogłoszenia kategorii książki</h2>
		<?php
			$db = mysqli_connect("localhost","root","","ogloszenia");
			
			$kw1 = "SELECT `id`, `tytul`, `tresc`, `uzytkownik_id` FROM `ogloszenie` WHERE `kategoria` = 1";
			
			if($wynik1 = mysqli_query($db, $kw1))
			{
				while($wypisz = mysqli_fetch_array($wynik1))
				{
					echo "<h3>".$wypisz[0]." ".$wypisz[1]."</h3> ".$wypisz[2]."</br>";
					
					$kw2 = "SELECT uzytkownik.telefon FROM uzytkownik JOIN ogloszenie ON ogloszenie.uzytkownik_id = uzytkownik.id WHERE ogloszenie.uzytkownik_id = '$wypisz[3]'";
					$wynik2 = mysqli_query($db, $kw2);
					
					$wypisz2 = mysqli_fetch_row($wynik2);
					
					echo "telefon kontaktowy: ".$wypisz2[0];
					
				}
			}
			else{
				echo "error, blad polaczenia".mysqli_errno($db);
			}
			
			mysqli_close($db);
		?>
	</div>
	<div class="stopka">
		<span>Portal ogłoszeniowy opracował: PESEL</span>
	</div>
</body>
</html>