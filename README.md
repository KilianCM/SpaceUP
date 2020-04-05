# SpaceUP

*Mis à jour le 2 avril 2020*

Notre projet se lie à une exposition de la Turbine sur le thème de la conquête spatiale. 
Elle permet d'apporter une expérience innovante et numérique en apport aux informations présentes sur l'exposition.

Pour cela, l'utilisateur utilise une application qui va lui permettre de suivre la conquête spatiale.
L'application va proposer différents ateliers qui correspondent chacun à un aspect du thème.

## Progression du projet

- ✅ Mise en place du projet, navigation et menu
- Atelier Goddard, *le premier à avoir l'idée de créer une fusée*
- 🔨 Atelier Combustion, *fonctionnement d'un moteur de fusée*
- ✅ Atelier Les Râtés, *histoire des erreurs qui ont menés aux loupés de décollage* - À améliorer
- 🔨 Lancement d'une fusée en réalité augmentée avec poste de pilotage fictif

## Comment ça marche ?

Pour lancer le projet, il faut s'assurer que la plateforme de build est réglé sur Android dans `File -> Build Settings`. Chaque scène doit être ajouter au build, avec `MainMenu` en première position.
L'application est compatible avec un smartphone capable de lire un tag NFC et assez puissant pour de la réalité augmentée.

### Scènes

- `MainMenu` boutons des menus sur un fond vidéo
- `FailsNFCScan` écran d'attente du dépôt du téléphone sur un dock NFC pour lancer une vidéo 
- `NFCPlayVideo` lecteur de la vidéo des râtés de la conquête spatiale (amélioration possible : QCM à certains moments de la vidéo)
- `Launch` lancement de la fusée (version alpha avec uniquement un modèle 3D qui décolle avec sons NASA et particules)
- `Combustion` mettant en scène un modèle simplifié d'un moteur de fusée avec lequel on peut intéragir pour le faire démarrer (mélange de carburants, allumeur, etc.)

Le script `ScenesControl` met à disposition des méthodes pour charger les scènes avec une animation FadeIn/FadeOut. Il est accessible en ajoutant le prefab `SceneController` dans une scène.
