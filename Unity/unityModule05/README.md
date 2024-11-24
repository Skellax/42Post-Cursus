<h1 align='center'>🎮Unity Module 05: Caterpillar Adventures Part II 🎮</h1>

<h2>Description</h2>

This Module focus to Singleton, Corountine  and Playersprefs, we add differents levels on your game and create a UI who 
display the hp of our caterpilar , the score . The goal and this module is to save your data even you leave your game. 

<h2>Execise 00: A good leaf</h2>

In this exercice you need to create 3 levels wich contains platforms and ennemies.
each stage must contains : 

<ul>
  <li>An visible start point</li>
  <li>an end of the stage point</li>
  <li>An collectable leaf item</li>
</ul>

For pass the end stage point, the catterpillar will have to collect 5 leaves. each leaves bring 5 points so you need 25 points
at least to pass the level. 
If your caterpilar reaches th end of the point and doesn't have the required number of leaf, it won't be able to go to the 
next stage and you will have to display, in game a message telling the player that he doesn't have enough points. 

If you caterpillar has blocked, the player can restart the level when he pressed a button (esc key for exemple).

After all this , you just create your first singleton who call GameManager with the DontDestroMethod (with this method,
your GameManager could save with all yours scenes.)

<h2>Exercice 01: PlayersPrefs</h2>

You must create a user profile the will be saved the player preferences so it can reloads if you quit and restart the game.
To do that we can use PlayerPrefs.
For this exercice you muste saved the Hp fo your caterpilar, leaf points and the stages it has unlocked. 

Create a mainMenu scen, wich be your starting scene when you start the game. It should conatain:
--> Title of your game 
--> Resume button
--> New Game button
--> Diary Button 

When you choose Resume, your caterpllar must have the same number of HP, same number of leaf points and be at the start of the
last stage you unlocked. 
When you choose New Game , all PlayerPrefs must be reset and you caterpillar start  of the first level. 

You need to add a main button in all your stage that allow the player to return to the main mune at any time.(the progress
must save when you pressed this button).


<h2>Exercice 02: User Interface</h2>

It's time to create a graphical interface visible in all stages. 

It will be display:

--> Number of HP of the caterpillar. You must see in real time the HP decrease or increase according to the HP that the 
catrpillar loses or gains.
--> Number of leaf point.  You muste see in real time the number of points increase when the caterpillar collect the
leaf.

This two élement will have to reset to zero each time the caterpillar changes stage, or if the lavel is reset.

This Interface must be visible in all scenes but not duplicated in each scenes (Tips: you can add Ui elements in your GameManager).

You must also create a Diary scen that allows to view all informations of your caterpillar progression. 

This scene must contain:
-->The number of leaf points your caterpillar has obtained since the start of the game.
-->The number of time when your caterpillar has died since the start of the game.
-->The lock and unlock stages of tour caterpillar.

<h2>Links</h2>

🇫🇷

<ul>
  <li>https://www.youtube.com/watch?v=vQ3nrXOYiGU&list=LL&index=1</li>
  <li>https://www.gamecodeclub.com/le-singleton-dans-unity-un-objet-pour-les-gouverner-tous/</li>
</ul>






