<?php
class TemplateEngine {

    public function createFile($fileName, $templateName, $parameters){

        $new_html = file_get_contents($templateName);

        $new_html = str_replace(array("{nom}", "{auteur}", "{description}", "{prix}"), $parameters, $new_html);

        file_put_contents($fileName, $new_html);
    }

}