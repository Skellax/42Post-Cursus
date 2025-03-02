<?php 
function search_by_states($list_of_states){

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

    $states2 = explode(",", $list_of_states);


    foreach ($states2 as $state){
        $state = trim($state);
        $state_found = false;

        //Cas 1 si le parametre est un etat 

        if (array_key_exists($state, $states)) {
            $key_found = $states[$state];
            if (array_key_exists($key_found, $capitals)) {
                echo $capitals[$key_found] . " is the capital of " . $state . "\n";
                $state_found = true;
            }
        }
        //Cas 2 si le parametre est une capitale 
        else{
            $key = array_search($state, $capitals);
            if ($state_name = array_search($key, $states)) {
                echo $state . " is the capital of " . $state_name . "\n";
                $state_found = true;
            }
        }
        if (!$state_found){
            echo $state . " is neither a capital nor a state.\n";
        }
    }
}