<!doctype html>
<html lang="pl" dir="ltr">
<head>
	<meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="auto.css">
	<title>Komis Samochodowy</title>
</head>
<body>
	<div class="baner">
		<h1>SAMOCHODY</h1>
	</div>
	<div class="lewy">
		<h2>Wykaz samochodów</h2>
		<ul>
			<?php
				$db = mysqli_connect("localhost","root","","Komis");
					
				$plik = "kwerendy.txt";
				
				$handle = fopen($plik ,"r");
				$line = fgets($handle);
				$kw = mysqli_query($db, $line);
				while($wynik = mysqli_fetch_row($kw))
				{
					echo "<li>".$wynik[0]." ".$wynik[1]." ".$wynik[2]."</li>";
				}
				
				fclose($handle);
					
				mysqli_close($db);
			?>
		</ul>
		<h2>Zamówienia</h2>
		<ul>
			<?php
				$db = mysqli_connect("localhost","root","","Komis");
					
				$plik = "kwerendy.txt";
				
				$handle = fopen($plik ,"r");
				
				for($i = 0; $i < 2; $i++)
				{
					$line = fgets($handle);
				}
				
				$kw = mysqli_query($db, $line);
				while($wynik = mysqli_fetch_row($kw))
				{
					echo "<li>".$wynik[0]." ".$wynik[1]."</li>";
				}
				
				fclose($handle);
					
				mysqli_close($db);
			?>
		</ul>
	</div>
	<div class="prawy">
		<h2>Pełne dane: Fiat</h2>
		<?php
			$db = mysqli_connect("localhost","root","","Komis");
					
			$plik = "kwerendy.txt";
				
			$handle = fopen($plik ,"r");
				
			for($i = 0; $i < 3; $i++)
			{
				$line = fgets($handle);
			}
				
			$kw = mysqli_query($db, $line);
			while($wynik = mysqli_fetch_row($kw))
			{
				echo $wynik[0]." / ".$wynik[1]." / ".$wynik[2]." / ".$wynik[3]." / ".$wynik[4]." / ".$wynik[5]."</br>";
			}
				
			fclose($handle);
					
			mysqli_close($db);
		?>
	</div>
	<div class="stopka">
		<table>
			<tr>
				<td><a href="kwerendy.txt">Kwerendy</a></td>
				<td>Autor: PESEL</td>
				<td><img src="auto.png" alt="komis samochodowy"/></td>
			</tr>
		</table>
	</div>
</body>
</html>