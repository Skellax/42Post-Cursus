<?php

function array2hash($tab)
{
    $array_key = array();
    $array_values = array();

    foreach ($tab as $tab2) {
        if (!is_array($tab2)){
            break;
        }
        foreach ($tab2 as $value) {
            if (is_numeric($value)) {
               array_unshift($array_key, $value);
            }
            else {
                array_unshift($array_values, $value);
            }
        }
    }
    
    $retour = array();

    while(count($array_key) > 0) {
        $retour[array_pop($array_key)] = array_pop($array_values);
    }
    return $retour;
}
?>