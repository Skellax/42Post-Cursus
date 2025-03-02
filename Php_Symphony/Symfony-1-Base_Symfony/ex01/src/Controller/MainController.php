<?php 

namespace App\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class MainController extends AbstractController
{

    #[Route('/e01', name: 'main')]
    public function index(): Response
    {
        $articles = ['Rathalos', 'Misutzune', 'Brachydios'];

        return $this->render('main.html.twig', [
            'articles' => $articles,
        ]);
    }
}