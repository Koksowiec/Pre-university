<!DOCTYPE HTML>
<html lang='pl' dir='ltr'>
<head>
	<meta charset="utf-8" />
	<link rel="icon" href="favicon.ico" type="image/x-icon" />
	<link rel="stylesheet" type="text/css" href="../style/topologie.css">
</head>
<body>
	<div>
		<?php
		$myfile = file_get_contents("../../baza/pesele.txt");
		$pesel = explode("\n", $myfile);
		
		$file=fopen('pesele_plec.txt', "w");
		
		foreach($pesel as $jeden){
			$plec = $jeden[9];
			
			if($plec%2==0)
			{
				$plec = "k";
			}
			else
			{
				$plec = "m";
			}
			
			$pesel1 = $jeden[0].$jeden[1].$jeden[2].$jeden[3].$jeden[4].$jeden[5].$jeden[6].$jeden[7].$jeden[8].$jeden[9].$jeden[10].";";
			
			fwrite($file, $pesel1.$plec."\n");
		}
		echo "Przetworzono pesele na płeć";
		fclose($file);
		?>
	</div>
</body>
</html>


