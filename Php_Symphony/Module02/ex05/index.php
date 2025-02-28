<?php

require_once 'TemplateEngine.php';

$elem = new Elem('html');
$head = new Elem('head');
$body = new Elem('body');

$head->pushElement(new Elem('meta', '', ['charset' => 'utf-8']));
$head->pushElement(new Elem('title', 'test'));

$ul = new Elem('ul');

$ul->pushElement(new Elem('li', 'liste 1'));
$ul->pushElement(new Elem('li', 'liste 2'));

$ol = new Elem('ol');

$ol->pushElement(new Elem('p', 'liste 3'));


$body->pushElement($ul);
$body->pushElement($ol);

$elem->pushElement($head);
$elem->pushElement($body);
$file = new TemplateEngine($elem);

$file->createFile("ex05.html");
