<?php
 

 class Elem{

    private string $element;
    private $content;

    //atribut who contents all tags
    private array $children;

    public function __construct($element, $content = null)
    {
        $balises = ["meta", "img", "hr", "br", "html", "head", "body", "title", "h1", "h2" , "h3", "h4", "h5", "h6", "p", "span", "div"];
        foreach($balises as $balise) {
            if ($element == $balise) {
                $this->element = $element;
                $this->content = $content;
                $this->children = [];
            }
        }
        
    }

    public function getHTML($indenation = 0)
    {
        //Respsect indentation for html
        $indentation = str_repeat(" ", $indenation);

        // add the first tag
        $html = "{$indentation}<{$this->element}>";

        //add content if is not empty
        if ($this->content !== "")
        {
            $html .= $this->content;
        }

        //recursive metho to add other child 
         foreach ($this->children as $child) {
            $html .= "\n". $child->getHTML($indenation + 1);
         }

         if (end($this->children)){
            $html .= "\n{$indentation}</{$this->element}>";
         }
         else {
            $html .= "</{$this->element}>";
         }
         
         return $html;
        
    }

    public function  pushElement($elem)
    {
        $this->children[] = $elem;

    } 
 }