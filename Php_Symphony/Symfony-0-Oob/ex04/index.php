<?php

require_once 'TemplateEngine.php';

$elem = new Elem('html');
$body = new Elem('body');
$body->pushElement(new Elem('p', 'Lorem ipsum', ['class' => 'text-muted']));
$elem->pushElement($body);

$file = new TemplateEngine($elem);

$file->createFile("ex04.html");
