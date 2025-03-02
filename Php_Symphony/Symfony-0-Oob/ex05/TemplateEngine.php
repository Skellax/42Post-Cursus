<?php

require_once 'Elem.php';

class TemplateEngine{

    private Elem $elem;


    public function __construct(Elem $elem)
    {
        $this->elem = $elem;
    }

    public function createFile($fileName) {

        if ($this->elem->ValidPage())
        {
            file_put_contents($fileName, $this->elem->getHTML());
        }
        else {
            throw new MyException("Erreur la page html est invalide ! \n". implode($this->elem->getErrors()) . "\n");
        }

        
    }


}