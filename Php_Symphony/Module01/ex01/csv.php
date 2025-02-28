<?php

$file = file_get_contents('ex01.txt');
$numbers =  explode(",", $file);

foreach ($numbers as $number)
{
    if ($number == end($numbers))
    {
        echo $number;
    }
    else {
        echo $number . "\n";
    }   
}
?>