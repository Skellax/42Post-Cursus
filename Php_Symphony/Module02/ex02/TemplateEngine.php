<?php

class TemplateEngine {

    public function createFile(HotBeverage $text) {

        //create reflectionclass for getters.
        $reflection = new ReflectionClass($text);

        $new_html = file_get_contents("./template.html");

        //Replace the parameters withe the getter of each class.
        $new_html = str_replace(array("{nom}", "{price}", "{resistance}", "{description}", "{comment}")
        , array($reflection->getMethod('getName')->invoke($text), $reflection->getMethod('getPrice')->invoke($text), $reflection->getMethod('getResistance')->invoke($text),
        $reflection->getMethod('getDescription')->invoke($text), $reflection->getMethod('getComment')->invoke($text)), $new_html);

        //give the name of the class used coffee.html or tea.html
        file_put_contents($reflection->getName() . ".html", $new_html);

    }

 }