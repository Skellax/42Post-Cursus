<?php
 $file = file_get_contents('ex06.txt');

 echo "file create\n";

 //Erase word for formate  the file.txt
 $file = str_replace(["position:", "number:", "small:", "molar:", "electron:"], "", $file);

 echo "formate file.txt\n";

 //Erase the = to replace  ',' beacause is very annoying ! 
 $file = str_replace("=", ",", $file);

 //Create ther tab who contains each elements
 $tab_elem = explode("\n", trim($file));

 echo "tab periodic created\n";

 $html = '
 <!DOCTYPE html>
 <html lang="en">
 <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tableau de Mendeliev</title>
    <style>
      li {
         font-size: x-small;
      }
      ul {
         list-style: none;
      }
      table {
         border-collapse: collapse;
      }
      h4 {
         font-size: smaller;
         color: white; 
         background-color: black;
      }
    </style>
 </head>
   <body>
      <table>

 ';

 foreach ($tab_elem as $elem) {
    $data = explode(",", $elem);
    if (count($data) == 6)
    {
      $name = trim($data[0]);
      $position = trim($data[1]);
      $number = trim($data[2]);
      $small = trim($data[3]);
      $molar = trim($data[4]);
      $electron = trim($data[5]);
      if ($position == 0)
      {
         $html .= '     <tr>';
         $html .= "\n";
         $new_position = 0;
      }
      for ($i = $new_position; $i <=  $position; $i++)
      {
         if ($i == $position)
         {
            $html .= '        <td style="border: 1px solid black; padding: 7px">
                                 <h4>' . $name . '</h4>
                                 <ul>
                                    <li>' . $number . '</li>
                                    <li>' . $small . '</li>
                                    <li>' . $molar . '</li>
                                    <li>' . $electron . ' electron </li>
                                 </ul>
                              </td>';
            $html .= "\n";
         }
         else {
            $html .= '        <td></td>';
            $html .= "\n";
         }
         $new_position++;
      }
      if ($position == 17) {
         $html .= '        </tr>';
         $html .="\n";
      }
    }
 }

 $html .= "    </table>\n";
 $html .= " </body>\n";
 $html .= "</html>\n";

file_put_contents('mendeliev.html', $html);

