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
		
		$file=fopen('poprawny.txt', "w");
		
		foreach($pesel as $jeden){
			$poprawnosc = 1*$jeden[0] + 3*$jeden[1] + 7*$jeden[3] + 9*$jeden[4] + 1*$jeden[5] + 3*$jeden[6] + 7*$jeden[7] + 9*$jeden[8] + 1*$jeden[9] + 3*$jeden[10];
			
			$cyfra = 0;
			
			if($poprawnosc % 10 == 0)
			{
				$cyfra = 0;
				
				if($jeden[10] == $cyfra)
				{
					$poprawnosc = "1";
				}
				else
				{
					$poprawnosc = "0";
				}
			}
			else
			{
				$cyfra = $poprawnosc%10;
				
				if($jeden[10] == $cyfra)
				{
					$poprawnosc = "1";
				}
				else
				{
					$poprawnosc = "0";
				}
			}
			
			$pesel1 = $jeden[0].$jeden[1].$jeden[2].$jeden[3].$jeden[4].$jeden[5].$jeden[6].$jeden[7].$jeden[8].$jeden[9].$jeden[10].";";
			
			fwrite($file, $pesel1.$poprawnosc."\n");
		}
		echo "Przetworzono poprawność peseli";
		fclose($file);
		?>
	</div>
</body>
</html>


