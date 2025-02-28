<?php

class TemplateEngine {

    public function createFile($fileName, $text){

        $html = '<!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Text</title>
        </head>
        <body>';

        $html .= $text->readData();

        $html .= "\n";
        $html .= '      </body>';
        $html .= "\n";
        $html .= '      </html>';

        file_put_contents($fileName, $html);


               
    }

}