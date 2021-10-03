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
		
		$file=fopen('pesele_daty.txt', "w");
		
		foreach($pesel as $jeden){
			$rok = $jeden[0].$jeden[1];
			$miesiac = $jeden[2].$jeden[3];
			if($miesiac>19)
			{
				$rok="20".$jeden[0].$jeden[1];
				$miesiac = $jeden[2].$jeden[3]-20;
				if($miesiac < 10)
				{
					$miesiac = "0".($jeden[2].$jeden[3]-20);
				}
			}
			else
			{
				$rok="19".$jeden[0].$jeden[1];
			}
			$dzien = $jeden[4].$jeden[5];
			
			$pesel1 = $jeden[0].$jeden[1].$jeden[2].$jeden[3].$jeden[4].$jeden[5].$jeden[6].$jeden[7].$jeden[8].$jeden[9].$jeden[10].";";
			$data=$rok."-".$miesiac."-".$dzien;
			
			fwrite($file, $pesel1.$data."\n");
		}
		echo "Przetworzono pesele na daty";
		fclose($file);
		?>
	</div>
</body>
</html>

