<h1 align='center'> 🏰Create your Own Defense Tower Part I 🏰</h1>

<h2>Description</h2>

<div align='center'>
  <img src= "https://github.com/Skellax/42Post-Cursus/blob/main/Unity/unityModule02/Module%2002%20img%201.png" width=600/>
</div>

In this part of the module 02 , you need to create a defense tower game, this part focus to use palette , tiles  and sprites.
So let's begin :) !

<h2>Exercice 00: I see the world in 2D</h2>

First we need to create your own palette to draw our map. 

For create our own palette we need to download *2D Tilemap Editor* go to window -> package manager on scrolling until you found 
the package. 

<div align='center'>
  <img src="https://github.com/Skellax/42Post-Cursus/blob/main/Unity/unityModule02/Module%2002%20img%2002.png" width=400/>
</div>

After that  go to window -> 2D -> Tile palette , a window like this  must appear.

<div align='center'>
  <img src="https://github.com/Skellax/42Post-Cursus/blob/main/Unity/unityModule02/Module%2002%20img%2003.png" width=400/>
</div>

 you can import your own sprite inside this palette and use the pen to draw directly in your map. 

 you can check the links for more informations :  https://docs.unity3d.com/Manual/Tilemap-Palette.html

 <h2> Exercise 01: White Walkers</h2>

 Time to add enemies. 

 You can use a simple sprite like a square or a peronal sprite if you prefer. But they have a specific rules to respect:

 <ul>
   <li>Each ennemies has the same script</li>
   <li>The ennemies spawn and moving  toward the base (if one ennemis touch your base , it lost 1hp</li>
   <li>Your base begin 5hp</li>
 </ul>

 like the ennemies you can use your personal sprite for your base. 

 <h2>Exercise 02: Arms !</h2>

It's time to add turrets. 

In this exercise you need to create turret for destroy your ennemis and protect your base. 

They have 3 turrets and each one has a own features: 

<ul>
  <li>A turret has a low rate of fire with basics damages of 0,3.</li>
  <li>A turret has a medium rate of fire with basics damages of 0,2.</li>
  <li>A turret has a very fast rate of fire with basics damages of 0,1</li>
</ul>

Your turrets must have a detection zone and when an enemy enters in this zone, the
turret will have to target him and shoot him. She always target the closest enemy.
Turrets should not have too much range, and should not be placed far from the road
to be able to detect the enemies. If they are placed far from the road they should not be
able detect the enemies.


You must have only on scripts for all the turrets.
When the bullet has hit an enemy, it is destroyed and the enemy takes damages.

Your enemy will have 3HP and a bullet does one damage. Don’t forgot to take into
account the basic damage of your turret.
If your enemy is defeated, it will be destroyed.




 
 

 







