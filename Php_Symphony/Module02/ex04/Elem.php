<?php

Require_once 'MyException.php'; 

 class Elem{

    private string $element;
    private $content;
    private array $attributes;

    //atribut who contents all tags
    private array $children;

    public function __construct($element, $content = null, $attributes = [])
    {
        $tag_finded  = false;
        $balises = ["meta", "img", "p", "hr", "br", "html", "head", "body", "title", "h1", "h2" , "h3", "h4", "h5", "h6", "p", "span", "div",
                    "table", "th", "tr", "td", "ul", "ol", "li"];
        foreach($balises as $balise) {
            if ($element == $balise) {
                $this->element = $element;
                $this->content = $content;
                $this->attributes = $attributes;
                $this->children = [];
                $tag_finded = true;
                break;
            }
        }

        if (!$tag_finded)
        {
            throw new MyException("Error, wrong tags !");
        }       
    }

    public function getHTML($indenation = 0)
    {
        //Respsect indentation for html
        $indentation = str_repeat(" ", $indenation);

        // add the first tag
        $html = "{$indentation}<{$this->element}";

        // add the attributes

        if (isset($this->attributes))
        {
            foreach ($this->attributes as $name => $value)
            {
                $html .= " {$name}=\"" . $value . "\"";
            }
        }
        
        //close the tags
        $html .= ">";

        //add content if is not empty
        if ($this->content !== "")
        {
            $html .= $this->content;
        }

        //recursive method to add other child 
         foreach ($this->children as $child) {
            $html .= "\n". $child->getHTML($indenation + 2);
         }

         if (end($this->children)){
            $html .= "\n{$indentation}</{$this->element}>";
         }
         else {
            $html .= "</{$this->element}>";
         }

         reset($this->children);
         
         return $html;
        
    }

    public function  pushElement($elem)
    {
        $this->children[] = $elem;

    } 
 }