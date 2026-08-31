|cas utilisation|envoyer un email|
|---|---|
|acteurs|support et fournisseur mail|
|precondition|le support est authentifier; l'email existe; le fournisseur email est online|
|objectif|envoyer l'email a le destinataire|
|postcondition|l'email sera envoyer|
|scenario nominal|le support choisir l'email qu'il veut envoyer; l'application contact le fournisseur mail pour l'envoi; le fournisseur envoie le mail; l'application sauvgarde le statue de mail et affiche un message de success|
|scenario alternatif|le support choisir l'email qu'il veut envoyer; l'application contact le fournisseur mail pour l'envoi; le fournisseur ne peut pas envoie le mail; l'application affiche un message d'echec|
|exception|le fournisseur mail est undisponible;le email de destinataire est faux|


|cas utilisation|le cloture d'une opportunite|
|---|---|
|acteur|directeur|
|precondition|le directeur est authentifier; l'opportunite existe|
|objectif|marquer l'opportunite comme cloture|
|postcondition|l'opportunite sera etre "lecture seul"|
|scenario nominal|le directeur chosie l'opportunite qu'il veut cloturer; le directeur clique sur "marquer comme gagnee"; l'application sauvgarde le changement et ajoute le montant de l'opportunite a le revenu total d'equipe|
|scenario alternatif|le directeur chosie l'opportunite qu'il veut cloturer; le directeur clique sur "marquer comme perdu"; l'application sauvgarde le changement|
|exception|---|


---
|cas utilisation|qualifier le prospect|
|---|---|
|acteur|marketeur|
|precondition|le marketeur est authentifier; le prospect existe|
|objectif|qualifier le prospect a etre converti a un contact|
|postcondition|le prospect sera qualifier a la convertion|
|scenario nominal|le marketeur chosie le prospect qu'il veut qualifier; le marketeur clique sur "qualifier"; l'application enregistre les changements et affiche un message du success|
|scenario alternatif|---|
|exception|---|

|cas utilisation|convertir le prospect|
|---|---|
|acteur|marketeur|
|precondition|le marketeur est authentifier; le prospect existe; le prospect est qualifier|
|objectif|qualifier le prospect a etre converti a un contact|
|postcondition|le prospect sera qualifier a la convertion|
|scenario nominal|le marketeur chosie le prospect qu'il veut convertir; le marketeur clique sur "convertir";l'application verifie la demande ;l'application enregistre les changements et affiche un message du success|
|scenario alternatif|le marketeur chosie le prospect qu'il veut convertir; le marketeur clique sur "convertir";l'application verifie la demande ;l'application n'accept pas la demande et affiche un message d'erreur|
|exception|le prospect n'est pas qualifier|
---
|cas utilisation|assigner permissions a un role|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier; le role exist; la permission exist|
|objectif|ajouter des authorization a les utilisateurs que ont ce role|
|postcondition|le role aura ces permissions|
|scenario nominal|l'admin navigue a la page; l'admin choisie le role et les permissions a ajouter; l'application verifie la demande;l'application sauvgarde les changement du role et affiche un message du success|
|scenario alternatif|l'admin navigue a la page; l'admin choisie le role et les permissions a ajouter; l'application verifie la demande;l'application n'accepte pas la demande et affiche un message d'erreur|
|exception|le role deja a ces permissions|

|cas utilisation|assigner permissions a un utilisateur|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier; l'utilisateur exist; la permission exist|
|objectif|ajouter des authorization a le utilisateur|
|postcondition|l'utilisateur aura ces permissions|
|scenario nominal|l'admin navigue a la page; l'admin choisie l'utilisateur et les permissions a ajouter; l'application verifie la demande;l'application sauvgarde les changement d'utilisateur et affiche un message du success|
|scenario alternatif|l'admin navigue a la page; l'admin choisie l'utilisateur et les permissions a ajouter; l'application verifie la demande;l'application n'accepte pas la demande et affiche un message d'erreur|
|exception|l'utilisateur deja a ces permissions|




|cas utilisation||
|---|---|
|acteur||
|precondition||
|objectif||
|postcondition||
|scenario nominal||
|scenario alternatif||
|exception|||cas utilisation|assigner a un utilisateur|


















|---|---|
|acteur|admin|
|precondition|l'admin est authentifier; le role existe; l'utilisateur existe|
|objectif|donner l'utilisateur le role est ses permissions|
|postcondition|l'utilisateur aura le role|
|scenario nominal|l'admin navigue a la page; l'admin choisie l'utilisateur et le role a assigner; l'application verifier la demande; l'application sauvgarde les changement et afficher un message du success|
|scenario alternatif|l'admin navigue a la page; l'admin choisie l'utilisateur et le role a assigner; l'application verifier la demande; l'application n'accept pas la demande et affiche un message d'erreur|
|exception|l'utilisateur deja a ce role|

|exception||
|cas utilisation|creer un utilisateur|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier|
|objectif|creer un utilisateur|
|postcondition|un utilisateur est creer|
|scenario nominal|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application sauvgarde le nouveau utilisateur est affiche un message de success|
|scenario alternatif|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application n'accept pas les donnees est affiche un message d'error|
|exception|le nom d'utilisateur ou l'email sont dupliquees ou ne sont pas valids|

|cas utilisation|modifier un utilisateur|
|---|---|
|acteur|admin|
|precondition|l'utilisateur exist;l'admin est authentifier|
|objectif|changer quelque information d'utilisateur|
|postcondition|l'utilisateur est change|
|scenario nominal|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application sauvgarde les changements d'utilisateur est affiche un message de success|
|scenario alternatif|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application n'accept pas les donnees est affiche un message d'error|
|exception|le nom d'utilisateur ou l'email sont dupliquees ou ne sont pas valids|


|cas utilisation|supprimer un utilisateur|
|---|---|
|acteur|admin|
|precondition|l'utilisateur existe;l'admin est authentifier|
|objectif|effacer un utilisateur|
|postcondition|un utilisateur est supprimer|
|scenario nominal|l'admin navigue a la page; l'admin clique sur le button supprimer; l'application supprime l'utilisateur est affiche un message de success|
|scenario alternatif|---|
|exception|---|

|cas utilisation|consulter les utilisateur|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier|
|objectif|voir les utilisateur qui existent et leurs permissions|
|postcondition|les donnees sont affichees|
|scenario nominal|l'admin navigue a la page; l'application recupere les utilisateurs existant et l'affiche|
|scenario alternatif|---|
|exception|---|




|cas utilisation|creer un role|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier|
|objectif|creer un role pour l'organisation des utilisateurs|
|postcondition|un role est creer|
|scenario nominal|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application sauvgarde le nouveau role est affiche un message de success|
|scenario alternatif|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application n'accept pas les donnees est affiche un message d'error|
|exception|le nom du role est dupliquer ou n'est pas valid|

|cas utilisation|modifier un role|
|---|---|
|acteur|admin|
|precondition|le role exist;l'admin est authentifier|
|objectif|changer quelque information du role|
|postcondition|un role est change|
|scenario nominal|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application sauvgarde les changements du role est affiche un message de success|
|scenario alternatif|l'admin navigue a la page; l'admin repli la formulaire; l'application verifie les donnees; l'application n'accept pas les donnees est affiche un message d'error|
|exception|le nom du role est dupliquer ou n'est pas valid|


|cas utilisation|supprimer un role|
|---|---|
|acteur|admin|
|precondition|le role exist;l'admin est authentifier|
|objectif|effacer un role|
|postcondition|un role est supprimer|
|scenario nominal|l'admin navigue a la page; l'admin clique sur le button supprimer; l'application supprime le role est affiche un message de success|
|scenario alternatif|l'admin navigue a la page; l'admin repli la formulaire; l'application n'accept pas la demande du suppression est affiche un message d'error|
|exception|le role est utilise|

|cas utilisation|consulter les roles|
|---|---|
|acteur|admin|
|precondition|l'admin est authentifier|
|objectif|voir les roles qui exist et leurs permissions|
|postcondition|les donnees sont affichees|
|scenario nominal|l'admin navigue a la page; l'application recupere les roles existant et l'affiche|
|scenario alternatif|---|
|exception|---|




---
|cas utilisation|creer profile|
|---|---|
|acteur|utilisateur|
|precondition| -- |
|objectif|la creation d'une profile dans l'application|
|postcondition|un profile est cree|
|scenario nominal| l'utilisateur navigue a la page; il remplir la formulaire et la soumettre; l'application enregistre les information dans un nouveau profile|
|scenario alternatif|l'utilisateur navigue a la page; il remplir la formulaire et la soumettre; l'application n'accept pas les informations envoyees|
|exception|l'email ou le nom d'utilisateur deja existe|


|cas utilisation|s'authentifier|
|---|---|
|acteur|utilisateur|
|precondition|le profile existe|
|objectif|s'authentifier pour utiliser l'application|
|postcondition|l'utilisateur sera authentifier|
|scenario nominal|l'utilisateur navigue a la page; il entre le nom d'utilisateur et le mot de passe; l'application verifie les credentials; l'application return un cookie d'authentification; l'application redirecte l'utilisateur vers la page d'acceuil|
|scenario alternatif|l'utilisateur navigue a la page; il entre le nom d'utilisateur et le mot de passe; l'application verifie les credentials; l'application n'accept pas les credentials;l'application affiche l'erreur|
|exception|le profile n'existe pas; le mot de passe est incorrect; le profile est disactive|


|cas utilisation|consulter profile|
|---|---|
|acteur|utilisateur|
|precondition|le profile existe; l'utilisateur est authentifier|
|objectif|voir les information du profile|
|postcondition|l'utilisateur a vue les donnees de se profile|
|scenario nominal|l'utilisateur navigue a la page; l'application recuper ses information et les affiche;|
|scenario alternatif|---|
|exception|---|


|cas utilisation|modifier profile|
|---|---|
|acteur|utilisateur|
|precondition|le profile existe; l'utilisateur est authentifier|
|objectif|changer les information du profile|
|postcondition|le profile est modifier|
|scenario nominal|l'utilisateur navigue a la page; il rempli la formulaire; l'application verifie les donnees; l'application les sauvgarder; l'application affiche un message du success|
|scenario alternatif|l'utilisateur navigue a la page; il rempli la formulaire; l'application verifie les donnees; l'application n'accept pas ces derniers; l'application affiche un message d'erreur|
|exception|l'email ou le nom d'utilisateur deja existe|


|cas utilisation||
|---|---|
|acteur||
|precondition||
|objectif||
|postcondition||
|scenario nominal||
|scenario alternatif||
|exception||




 ---

|cas utilisation||
|---|---|
|acteur||
|precondition||
|objectif||
|postcondition||
|scenario nominal||
|scenario alternatif||
|exception||












# user hierachy (from lowest to highest)
- simple user
- support
- marketer
- manager 
- admin




# Administration
## Gestion des utilisateurs
  * create (by the admin user) 
  * read  (by the admin user)
  * update (by the admin user) 
  * delete (by the admin user) 

## Gestion des rôles
  * create (by the admin user)
  * read (by the admin user)
  * update (by the admin user)
  * delete (by the admin user)
  * assign to users (by the admin user)

## Gestion des permissions
  * assign to roles (By the admin user)
  * assign to users (By the admin user)

  ---

# Authentification
* Register (Simple user)
* Login (Simple user)
* View Profile (Simple user)
* Edit Profile (Simple user)

---

# CRM Stuff
  ## Gestion des Leads:
  * create (By Markerter)
  * read (By Markerter)
  * update (By Markerter)
  * delete (By Markerter)
  * Qualification des Leads (By Manager)
  * Conversion Lead → Contact (By Manager)
  ## Gestion des Contacts
  * create (by markerter)
  * read (by markerter)
  * update (by markerter)
  * delete (by markerter)
  ## Gestion des Organisations
  * create(by markerter)
  * read(by markerter)
  * update(by markerter)
  * delete(by markerter)
  ## Gestion des Opportunités
  * create(by markerter)
  * read(by markerter)
  * update(by markerter)
  * delete(by markerter)
  * Close
  ## Gestion des Campagnes
  * create(by markerter)
  * read(by markerter)
  * update(by markerter)
  * delete(by markerter)
  * Activate
  * Deactivate

---

# Les Activites
## Gestion des Activités CRM Generique
  * create(by Support)
  * read(by Support)
  * update(by Support)
  * delete(by Support)
  ## Gestion des Appels  (inherits Generic Activity)
  ## Gestion des Réunions(inherits Generic Activity)
  ## Gestion des Tâches  (inherits Generic Activity)
  ## Gestion des Notes
  * create(by simple user)
  * read(by simple user)
  * update(by simple user)
  * delete(by simple user)
  ## Gestion des Emails
  * create(by support)
  * read(by support)
  * update(by support)
  * delete(by support)
  * Send(by support)

---
# Analytics
* View Accounts Analytics (By Manager)
* View Contacts Analytics (By Manager)
* View Prospects Analytics (By Manager)
* View Opportunities Analytics (By Manager)
* View Campagne Analytics (By Manager)
