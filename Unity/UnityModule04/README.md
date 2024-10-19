<h1 align='center'>🎮Unity Module 04: Caterpillar Adventures Part I🎮</h1>

<h2>Description</h2>

This Moduls focus to animation and sound. You need to create a caterpillar  and you'll add differents 
animations (jump, move, idle,...)


<h2>Exercice 00: A life of a caterpillar</h2>

The goal is to create a gameObject player who can  jump and move. First you need to create 
the PlayerController script  after that you need to add differents animation for your player.
<ul>
  <li> Idle</li>
  <li>Walk</li>
  <li>Jump</li>
  <li>Take dmg</li>
  <li>Defeated</li>
  <li>Respawn</li>
</ul>

You can use the Animator for merge all your animations and add the conditions to trigger.
Exemple q bool triger isJumping for animation jump.

<h2>Exercice 01: A strange environment</h2>

Now you have your caterpillar, it will be necessary to give a little movement to your environnement.

You must have at leave 2 types of animated object on the background (Moving tree, falling leaves etc...)

And two ennemies animated who can interacte with the caterpillar.

<ul>
  <li>A liana, animated when the catrpillar get close to it</li>
  <li>A cactus that throw poisonous jelly if you are too close</li>  
</ul>

When the caterpillar hited by a projectile and by the liana he lost 1hp.(you can give 3hp)
When the hp fallen to 0 your caterpillar must die  with die animation accompanied by a fade
from transparent to a black screen.
And after your caterpillar die , you nedd to respawn at the start of the level with a WakeUp animation
and with a fade from black screnn to transparent screen.

<h2>The sound</h2>

Very simple, you just add differents sound and music in your game.

<ul>
  <li>Add Background music</li>
  <li>Add sound when your catterpilar jump</li>
  <li>Add sound when your catterpilar take damage</li>
  <li>Add sound when your catterpilar die</li>
  <li>Add sound when your catterpilar respawn</li>
  <li>Add sound when the liana Attack</li>
  <li>Add sound when the catcus send jelly</li>
</ul>

<h2>Links</h2>

https://www.youtube.com/watch?v=Sg_w8hIbp4Y&list=LL&index=1&t=85s
