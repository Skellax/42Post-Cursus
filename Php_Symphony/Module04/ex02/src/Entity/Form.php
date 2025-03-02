<?php

namespace App\Entity;

use Symfony\Component\Validator\Constraints as Assert;

use App\Exception\CustomException;

class Form {

    #[Assert\NotBlank(message: "Le message ne peut pas etre vide.")]
    protected string $message = '';

    protected bool $response;

    public function getMessage(): string
    {
        return $this->message;
    }

    public function setMessage(string $newMessage): void
    {
        $this->message = $newMessage;
    }

    public function getResponse(): bool
    {
        return $this->response;
    }

    public function setResponse(bool $newResponse): void
    {
        $this->response = $newResponse;
    }
}