Voici les étapes détaillées pour exécuter votre projet console sur un Mac sans utiliser Visual Studio :

1. Installer le SDK .NET

	1.	Télécharger et installer .NET SDK :
	•	Accédez à dotnet.microsoft.com/download.
	•	Téléchargez la version SDK compatible avec votre macOS.
	2.	Vérifiez l’installation :
	•	Ouvrez votre terminal et tapez :
    ```
    dotnet --version
    ```
•	Vous verrez la version installée du SDK .NET (par exemple : 7.0.x).

2. Préparer le projet

	1.	Créer un dossier pour le projet :

    ```
    mkdir RecetteManager
    cd RecetteManager
    ```

	2.	Créer un projet console .NET :

    ```
    dotnet new console
    ```

	3.	Installer les packages nécessaires :
	•	Ajoutez Entity Framework Core et SQLite :

    ```
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    ```

	•	Ajoutez les outils pour Entity Framework :

    ```
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet tool install --global dotnet-ef
    ```
3. Configurer la base de données

	1.	Créer une migration pour la base de données :

    ```
    dotnet ef migrations add InitialCreate
    ```

	2.	Appliquer la migration (ce qui génère le fichier recettes.db) :

    ```
    dotnet ef database update
    ```

4. Exécuter l’application

	1.	Lancer le programme :

    ```
    dotnet run
    ```

	2.	Naviguer dans le menu :
	•	Une fois le programme lancé, vous verrez le menu principal. Par exemple :

    ```
    === Gestion des Recettes ===
    1. Lister les recettes
    2. Ajouter une recette
    3. Modifier une recette
    4. Supprimer une recette
    5. Quitter
    Choisissez une option :
    ```

	•	Saisissez le numéro correspondant à l’action souhaitée.

5. Résolution des problèmes

	•	Si vous obtenez une erreur indiquant que dotnet ef n’est pas trouvé :
	•	Ajoutez .NET tools à votre PATH :

    ```
    export PATH="$PATH:$HOME/.dotnet/tools"
    ```

	•	Si vous rencontrez des problèmes spécifiques, décrivez-les et je pourrai vous aider à les résoudre.

Avec ces étapes, votre projet fonctionnera parfaitement sur votre Mac à partir du terminal.