<?php

namespace App\Controller;

use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Attribute\Route;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\DependencyInjection\ParameterBag\ParameterBagInterface;

class ShadesController extends AbstractController
{
    function getShaders($colors) {
        $shades = [];
    
        switch ($colors) {
            case 'black':
                $shades = ['#000000', '#363536', '#2c030b', '#3a020d', '#0b1616', '#120d16', '#2f1e0e',
                '#232536','#332936', '#3d3d3d',];
                break;
            case 'red':
                $shades = ['#ff0000', '#ed0000', '#6e0b14', '#e0115f', '#de2916', '#e9383f', "#cc4e5c",
                '#f08080', '#b22222', '#730800'];
                break;
            case 'blue':
                $shades = ['#0000ff', '#1e7fcb', '#03224c', '#26619c', '#80d0d0', '#40e0d0', '#000080',
                '#7b68ee', '#afeeee', '#4682b4'];
                break;
            case 'green':
                $shades = ['#00ff00', '#18391e', '#3a9d23', '#556b2f', '#689d71', '#a5d152', '#57d53b',
                '#00ff7f', '#006400', '#16b84e'];
                break;
        }
        return $shades;
    }
    

    #[Route('/e03', name: 'index')]
    public function show(ParameterBagInterface $params): Response
    {
        $numbersOfShades = $params->get('e03.number_of_colors');
        $colors = ['black', 'red', 'blue', 'green'];
        $shades = [];

        foreach($colors as $color) {
            $allshades = $this->getShaders($color);

            //Reduit la taille du tableau a la taille de allshades si jamais le parametres numbers of 
            //shades est plus grand que la taille du tableau
            $shades[$color] = array_slice($allshades, 0, min($numbersOfShades, count($allshades)));
        }

        

        return $this->render('base.html.twig', [
            'shades' => $shades,
        ]);
    }


}

