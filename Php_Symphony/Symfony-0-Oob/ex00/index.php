<?php 

include 'TemplateEngine.php';

$new_file = new TemplateEngine();

$new_file->createFile("nouveau.html", "book_description.html", ["Rambo vs JCVD", "Theodule", "Le plus grand livre d'action de tous les temps", "15,99$"]);