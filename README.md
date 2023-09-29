# RobotWantedLeague

## Dépendances

Installer les dépendances :

- dotnet restore

Installer Entity Framework CLI (si ce n'est pas déjà fait) :

- dotnet tool install --global dotnet-ef


## Configuration de la Base de Données

Mettre à jour la base de données avec les migrations :

- dotnet ef database update


## Pour lancer l'application en mode de développement :


- dotnet watch --project WantedRobots


