<?php
class Text {

    function __construct($array_string)
    {
        $this->strings = $array_string;
    }

    function append($new_string)
    {
        $this->strings[] = $new_string;
    }

    function readData()
    {
        $html = "";
        foreach($this->strings as $string)
        {
            $html .= "\n";
            $html .= '          <p>' .$string . '</p>';

        }

        return $html;
    }
}