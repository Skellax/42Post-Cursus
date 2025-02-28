<?php
 
 require_once 'HotBeverage.php';

 class Coffee extends HotBeverage {

    private $description;
    private $comment;

    public function __construct()
    {
        $this->name = "cafe noir";
        $this->price = "2.50";
        $this->resistance = "3";
        $this->description = "cafe bio";
        $this->comment = "Le meilleur cafe de votre vie !";
    }

    public function getDescription() {
        return $this->description;
    }

    public function getComment() {
        return $this->comment;
    } 
 }