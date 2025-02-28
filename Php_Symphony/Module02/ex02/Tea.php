<?php
 
 require_once 'HotBeverage.php';

 class Tea extends HotBeverage {

    private $description;
    private $comment;

    public function __construct()
    {
        $this->name = "The vert";
        $this->price = "1.75";
        $this->resistance = "4";
        $this->description = "The a la menthe et aux aromes d'agrumes";
        $this->comment = "Laissez vous submerger par son gout unique !";
    }

    public function getDescription() {
        return $this->description;
    }

    public function getComment() {
        return $this->comment;
    } 
 }