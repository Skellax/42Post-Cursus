<?php

namespace App\Controller;

use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Attribute\Route;

class HomeController
{
    #[Route('/e00/firstpage', name: 'firstpage')]
    public function helloWorld(): Response
    {
        return new Response('<html><body><h1 style="color:red">Hello World !</h1></body></html>');

    }
}