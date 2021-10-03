<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="styl3.css">
    <title>Twoje BMI</title>
</head>
<body>
    <section class="logo">
        <img src="wzor.png" alt="wzór BMI">
    </section>
    <section class="baner">
        <h1>Oblicz swoje BMI</h1>
    </section>
    <section class="glowny">
        <table>
            <tr>
                <th>Interpretacja BMI</th>
                <th>Wartość minimalna</th>
                <th>Wartość maksymalna</th>
            </tr>
            <?php
                $db = mysqli_connect("localhost","root","","egzamin");

                $query = mysqli_query($db, "SELECT bmi.informacja, bmi.wart_min, bmi.wart_max FROM bmi");

                while($wynik = mysqli_fetch_row($query))
                {
                    echo "<tr><td>".$wynik[0]."</td><td>".$wynik[1]."</td><td>".$wynik[2]."</td></tr>";
                }

                mysqli_close($db);
            ?>
        </table>
    </section>
    <section class="lewy">
        <h2>Podaj wagę i wzrost</h2>
        <form action="" method="post">
            <span>Waga:</span><input type="number" name="waga" min="1"/></br>
            <span>Wzrost:</span><input type="number" name="wzrost" min="1"/><br>
            <input type="submit" name="oblicz" value="Oblicz i zapamiętaj wynik"/>
        </form>
        <?php 
            if(!empty($_POST['waga']) || !empty($_POST['wzrost']))
            {
                $db = mysqli_connect("localhost","root","","egzamin");

                $waga = $_POST['waga'];
                $wzrost = $_POST['wzrost'];
                $data = date("Y-m-d");

                $bmi = ($waga/pow($wzrost, 2)) * 10000;

                echo "Twoja waga: ".$waga." Twój wzrost: ".$wzrost."</br>";
                echo "Twoje BMI: ".$bmi;
                
                if($bmi >=0 && $bmi <= 18)
                {
                    mysqli_query($db, "INSERT INTO wynik(id, bmi_id, data_pomiaru, wynik) VALUES (NULL, 1, $data, $bmi)");
                }
                else if($bmi >= 19 && $bmi <= 25)
                {
                    mysqli_query($db, "INSERT INTO wynik(id, bmi_id, data_pomiaru, wynik) VALUES (NULL, 2, $data, $bmi)");
                }
                else if($bmi >= 26 && $bmi <= 30)
                {
                    mysqli_query($db, "INSERT INTO wynik(id, bmi_id, data_pomiaru, wynik) VALUES (NULL, 3, $data, $bmi)");
                }
                else if($bmi >=31 && $bmi <= 100)
                {
                    mysqli_query($db, "INSERT INTO wynik(id, bmi_id, data_pomiaru, wynik) VALUES (NULL, 4, $data, $bmi)");
                }

                mysqli_close($db);
            }
        ?>
    </section>
    <section class="prawy">
        <img src="rys1.png" alt="ćwiczenia">
    </section>
    <section class="stopka">
        <span>Autor: 01230500919</span>
        <a href="kwerendy.txt">Zobacz kwerendy</a>
    </section>
</body>
</html>