<?php

require_once 'TemplateEngine.php';

$elem = new Elem('html');
$body = new Elem('body');
$body->pushElement(new Elem('h1', 'Lorem ipsum'));
$elem->pushElement($body);

$file = new TemplateEngine($elem);

$file->createFile("ex03.html");
