<?php
function capital_city_from($state){

    $key_state = null;

    $states = [
        'Oregon' => 'OR',
        'Alabama' => 'AL',
        'New Jersey' => 'NJ',
        'Colorado' => 'CO',
    ];

    $capitals = [
        'OR' => 'Salem',
        'AL' => 'Montgomery',
        'NJ' => 'trenton',
        'KS' => 'Topeka',
    ];

    while($state_name = current($states)) {
        if ($state == key($states)) {
            $key_state = $state_name;
        }
        next($states);
    }

    while($capitals_name = current($capitals)){
        if ($key_state == key($capitals)) {
            echo current($capitals) . "\n";
            return;
        }
        next($capitals);
    }

    echo "Unknown\n";
    return;


}