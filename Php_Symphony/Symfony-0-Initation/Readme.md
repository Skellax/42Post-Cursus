<h1>Php symfony 0 Initiation</h1>

<h2>Exercice 00</h2>


  Si Twitter n’a aucun secret pour vous, vous connaissez très probablement bit.ly :
un raccourcisseur d’URLs bien pratique.
Le but de cet exercice est d’écrire et de rendre un script shell qui affiche l’adresse
réelle d’une adresse bit.ly (comprenez “L’adresse vers laquelle renvoie le lien bit.ly”).
Comme explicitement écrit dans le cartouche de cet exercice, vous n’avez droit d’uti-
liser que les trois commandes shell suivantes pour réaliser cet exercice : curl, grep et
cut. Votre meilleur point de départ est de lire le manuel de la commande curl. Pour
cela, tapez man curl dans votre terminal.
Voici un exemple du comportement attendu de votre script shell :

  ```
$> ./myawesomescript.sh bit.ly/1O72s3U
http://42.fr
$>
```


<h2>Exercice 01</h2>


  Vous devez réaliser un CV en HTML/css et respecter les contraintes suivantes :
  
- Vous devez respecter la sémantique de vos balises HTML, ainsi que la séparation
du fond et de la forme.
- Vous devez produire un fichier HTML cohérent dans sa structure avec un contenu
minimum imposé : nom, prénom, compétences et parcours.
- Vous devez afficher au moins un titre avec la balise title et un titre avec la balise
h1.
- Vous devez utiliser au moins un tableau avec les balises table, th, tr et td.
- Vous devez utiliser au moins une liste avec la balise ul et une liste avec la balise
ol. Les éléments doivent utiliser la balise li.
- Les bordures des tableaux doivent être visibles (solid). Les bordures des tableaux
doivent être fusionnées (collapse).
- Vous devrez utiliser une solution syntaxique différente pour chacun des deux points
de la consigne précédentes. Pour la première, utilisez la balise style dans le head
de votre page. Pour la seconde, utilisez un attribut style dans une balise qui vous
paraît adaptée.
- La cellule la plus en bas à droite de chaque tableau doit avoir #424242 comme
couleur de bordure.


> ℹ️ Pas de consigne particulière pour la véracité des informations. Vous
pouvez réaliser un CV farfelu si le coeur vous en dit.


<h2> Exercice 02</h2>

Réalisez un formulaire HTML qui représente les informations usuelles d’un contact quel-
conque. Ce formulaire doit proposer tous les champs suivants :

- Firstname : un champ texte.
- Name : un champ texte aussi.
- Age : vous devez utiliser le champ numérique spécifique au HTML5.
- Phone : vous devez utiliser le champ tel spécifique au HTML5.
- Email : vous devez utiliser le champ email spécifique au HTML5.
- Student at 42 ? : vous devez utiliser le champ checkbox.
- Gender : vous devez utiliser des boutons radio avec les valeurs Male, Female et
Other.
- Un bouton de soumission du formulaire. L’attribut onclick de votre bouton doit
être : ’displayFormContents();’.

La tarball d00.tar.gz en annexe de ce sujet contient un sous-dossier ex02/ qui lui-
même contient un fichier Javascript popup.js écrit par le fils de votre patron en stage
dans votre entreprise. Comme il serait inacceptable que vous fassiez passer le fils du pa-
tron pour un incompétent en programmation, vous ne pouvez pas du tout modifier son
fichier qui doit donc être utilisé tel quel

> 💡 Une lecture attentive et une compréhension superficielle du code
Javascript fourni sont requises pour réussir cet exercice.

Vous devez intégrer correctement ce fichier Javascript à votre page HTML. Si votre
code HTML est correct, l’appui sur le bouton du formulaire fera apparaître une popu-p
ultra-moderne contenant les champs et valeurs de votre formulaire. Dans tous les autres
cas, votre code HTML est faux.

<h2> Exercice 03</h2>

Une entreprise concurrente a mis en ligne une page web plus jolie que la votre. Grâce
à un espionnage industriel digne du cinéma Hollywoodien, votre patron se procure un
screenshot de la page et le fichier CSS qui va avec. Ces deux fichiers sont à votre disposi-
tion dans les annexes de ce sujet dans l’archive d00.tar.gz et son sous-dossier ex03/.
Vous devez reproduire cette page le plus fidèlement possible !

<div align = center>
  <img src=https://github.com/Skellax/42Post-Cursus/blob/main/Php_Symphony/Symfony-0-Initation/ex03/page.png width=400 />  
</div>



Vous devrez là encore séparer le fond et la forme, respecter la sémantique des balises
utilisées et maintenir une structure logique dans votre document.
Vous devez obligatoirement utiliser le fichier CSS fourni sans le modifier. Une version
“fraiche” de ce CSS sera utilisée en soutenance pour vérifier que vous avez bien respecté
cette consigne.

<h2> Exercice 04 </h2>

La tarball d00.tar.gz en annexe de ce sujet contient un sous-dossier ex04/ qui lui-
même contient quatre fichiers : file1.js, file2.js, file3.js et file4.js.
Vous devez créer et rendre un fichier snippets.html qui doit importer les quatre
scripts de telle manière que le pop-up s’affiche correctement (pas de caractère bizarre
donc).

> ⚠️  Vous ne pouvez qu’importer les scripts en question, vous ne pouvez
pas les modifier ou ajouter du Javascript dans votre code HTML.

<h2> Exercice 05 </h2>

u code c’est bien, du beau code c’est mieux, et pour faire du beau code, le mieux
est de suivre une belle norme.
La norme W3C est un incontournable du domaine, et il est impératif de la respecter
lorsque vous écrivez ou que vous générez du HTML.
Vous trouverez dans la tarball d00.tar.gz en annexe de ce sujet un sous-dossier
ex05/ qui contient les sources d’une page web complète. Malheureusement, cette page a
été écrite par un développeur bien moins bon que vous !
Modifiez le code HTML du fichier index.html pour qu’il passe  <a href=https://validator.w3.org/>la validation du W3C </a> !
Cela signifie donc aucune erreur et aucun warning.









