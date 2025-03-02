<?php

namespace App\Controller;

use App\Entity\Form;
use App\Form\FormType;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Attribute\Route;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\Filesystem\Filesystem;
use Symfony\Component\DependencyInjection\ParameterBag\ParameterBagInterface;


class FormController extends AbstractController {

    #[Route('/e02', name: 'form')]
    public function index(Request $request, ParameterBagInterface $params): Response
    {
        $form = new Form();
        $form->setMessage('');
        $form->setResponse(false);

        $form2 = $this->createForm(FormType::class, $form);

        $form2->handleRequest($request);
        if ($form2->isSubmitted() && $form2->isValid()){
                $filesystem = new Filesystem();

                $fileName = $params->get('notes_file');
                $filePath = $this->getParameter('kernel.project_dir') . '/'. $fileName ;

                if (!$filesystem->exists($filePath)) {
                    $filesystem->touch($filePath);
                }

                $message = $form->getMessage();
                if ($form->getResponse())
                {
                    $timestamp = date("Y-m-d H:i:s");
                    $message = $timestamp . " " . $message;
                }

                $filesystem->appendToFile($filePath, $message . PHP_EOL);
                $this->addflash('sucess', $message);
                return $this->redirectToRoute('form');
        }
        return $this->render('form.html.twig', [
            'form' => $form2,
        ]);
    }
}