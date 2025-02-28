<?php 

include 'Text.php';
include 'TemplateEngine.php';

$text = new Text(["Hello", "World"]);
$new_file = new TemplateEngine();
$new_file->createfile("test.html", $text);