# Create
```
@startuml
|Utilisateur|
start
:Authentifier;
:Navigue vers la page de XYZXYZ;
:Saisir les informations de XYZXYZ;

|Système|
:Valider les données;

if (Données valides ?) then (Oui)
    :Créer XYZXYZ;
    :Confirmer la création;
else (Non)
    :Afficher une erreur;
endif

stop
@enduml
```
---
# read
```
@startuml
|Utilisateur|
start
:Authentifier;
:Demander la liste des XYZXYZs;

|Système|
:Récupérer les XYZXYZs;
:Afficher les XYZXYZs;

stop
@enduml
```
---
# update
```
@startuml
|Utilisateur|
start
:Authentifier;
:Sélectionner un XYZXYZ;
:Clique sur modifier;
|Systeme|
:afficher le formulaire;
|Utilisateur|
:Modifier les informations;

|Système|
:Valider les données;

if (Données valides ?) then (Oui)
    :Mettre à jour XYZXYZ;
    :Confirmer la modification;
else (Non)
    :Afficher une erreur;
endif

stop
@enduml
```
---
# delete
```
@startuml
|Utilisateur|
start
:Authentifier;
:Navigue ver la page de XYZXYZ;
:Clique sur supprimer;

|Système|
:Supprimer XYZXYZ;
:Confirmer la suppression;

stop
@enduml
```
