<?php 

require_once "Coffee.php";
require_once "Tea.php";
require_once "TemplateEngine.php";

$tea = new Tea();

$coffee = new Coffee();

$new_file = new TemplateEngine();


//Create file html who content tea class
$new_file->createFile($tea);

//Create file html who content cofee class
$new_file->createFile($coffee);





