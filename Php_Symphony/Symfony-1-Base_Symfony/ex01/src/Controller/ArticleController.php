<?php

namespace App\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class ArticleController extends AbstractController
{
    private array $articles = [
        'Rathalos' => 'rathalos.html.twig',
        'Misutzune' => 'misutzune.html.twig',
        'Brachydios' => 'brachydios.html.twig',
     ];

     #[Route('/e01/{article}', name: 'article')]
     public function show(string $article): Response
     {
        if (!array_key_exists($article, $this->articles)) {
            return $this->redirectToRoute('main');
        }

        return $this->render($this->articles[$article], [
            'articles' => array_keys($this->articles),
        ]);
     }
}
