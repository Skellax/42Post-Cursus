<?php

Require_once 'MyException.php'; 

 class Elem{

    protected string $element;
    protected $content;
    protected array $attributes;
    protected array $errors;

    //atribut who contents all tags
    protected array $children;

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
                $this->errors = [];
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
         

        
        return $html;     
    }

    public function  pushElement(Elem $elem)
    {
        $this->children[] = $elem;

    }

    public function getErrors() {
        return $this->errors;
    }

    public function ValidPage() : bool 
    {
        //
        $is_valid = true;
        //all count tags
        $body_count = 0;
        $head_count = 0;
        $title_count = 0;
        $meta_count = 0;

        echo  $this->element . "\n";
        echo "------------\n";

        //Check if the first tag contain html;
        if ($this->element !== 'html') {
            $this->errors[] = "La balise html parent n'existe pas.";
            $is_valid = false;
        }

        //Check the head tag
        foreach ($this->children as $key => $child) {
            if ($child->element == 'head') {
                $head_count++;
                foreach ($child->children as $child_head) {
                    if (!in_array($child_head->element, ['meta', 'title']))
                    {
                        $this->errors[] = "La balise head contient une balise incorrect.";
                        $is_valid = false;
                    }
                    if ($child_head->element  == 'title') {
                        $title_count++;
                    }
                    else if ($child_head->element == 'meta' && isset($child_head->attributes['charset'])) {
                        $meta_count++;
                    }
                }
            }

            //Check the tag head follow body tags;
            if ($child->element == 'head' && $this->children[$key + 1]->element != 'body') {
                $this->errors[] = "La balise head n'est pas suivi de la balise body.";
                $is_valid = false;
            }

            //Check the tag body
            if ($child->element == 'body') {
                $body_count++;
            
                foreach ($child->children as $key => $child_body) {

                    echo "Entre dans body \n";

                    //Check the tags p 
                    if ($child_body->element == 'p') {
                        echo 'Entre dans p';
                        if (!empty($child_body->children) || !is_string($child_body->content)){
                            $this->errors[] = "La balise p contient un element enfant ou le contenu de l'element p n'est pas une chaine de caractere.";
                            $is_valid = false;
                        }

                    }

                    // check the tags li, tr, th, td  has the correct parent
                    else if (in_array($child_body->element, ['li', 'tr', 'th', 'td'])) {
                        $this->errors[] = "La balise {$child_body->element}  n'est pas dans la balise parent convenu";
                        $is_valid = false;

                    }

                    // check the ul  tags 
                    else if (in_array($child_body->element, ['ul', 'ol']))
                    {
                        foreach($child_body->children as $child_list) {
                            if ($child_list->element !== 'li') {
                                $this->errors[] = " La balise {$child_body->element} contient un element different de li.";
                                $is_valid = false;
                            }
                        }
                    }

                    //check the table tags 
                    else if ($child_body->element == 'table') {
                        foreach($child_body->children as $child_table) {
                            if ($child_table->element !== 'tr') {
                                $this->errors[] = "La balise table contient d'autres balises que la balise tr.";
                                $is_valid = false;  
                            }
                            else {
                                foreach($child_table->children as $child_row) {
                                    if (!in_array($child_row->element, ['td', 'th'])) {
                                        $this->errors[] = "La balise tr contient d'autres balises autres que td ou th.";
                                        $is_valid = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //check the count of tags
        if ($body_count !== 1)
        {
            $this->errors[] = "La balise body n'existe pas ou apparait trop de fois.";
            $is_valid = false;
        }
        
        if ($head_count !== 1)
        {
            $this->errors[] = "La balise head n'existe pas ou apparait trop de fois.";
            $is_valid = false;
        }

        if ($meta_count !== 1)
        {
            $this->errors[] = "La balise meta n'existe pas ou apparait trop de fois.";
            $is_valid = false;
        }

        if ($title_count !== 1)
        {
            $this->errors[] = "La balise title n'existe pas ou apparait trop de fois.";
            $is_valid = false;

        }

        //if all goods, return true
        return $is_valid;      
    }
 }

