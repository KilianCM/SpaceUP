# SpaceUP

*Mis à jour le 23 juin 2020*

Notre projet se lie à une exposition de la Turbine sur le thème de la conquête spatiale. 
Elle permet d'apporter une expérience innovante et numérique en apport aux informations présentes sur l'exposition.

Pour cela, l'utilisateur utilise une application qui va lui permettre de suivre la conquête spatiale.
L'application va proposer différents ateliers qui correspondent chacun à un aspect du thème.

Le choix s'est porté sur Unity pour facilement utiliser la réalité augmentée ainsi que la gestion des modèles 3D.

## Progression du projet

- ✅ Mise en place du projet, navigation et menu
- ✅ Atelier Goddard, *le premier à avoir l'idée de créer une fusée*
- ✅ Atelier Combustion, *fonctionnement d'un moteur de fusée*
- ✅ Atelier Les Râtés, *histoire des erreurs qui ont menés aux loupés de décollage*
- 🔨 Mission Lune : mini jeux dans le but d'atteindre la Lune
- ✅ Prise de selfie avec filtre SpaceUP

## Comment ça marche ?

Pour lancer le projet : 
- S'assurer que la plateforme de build est réglé sur Android dans `File -> Build Settings`. 
- Chaque scène doit être ajouter au build, avec `MainMenu` en première position.

L'application est compatible avec un smartphone capable de lire un tag NFC et assez puissant pour de la réalité augmentée.

### Architecture

- **Animations** : tous les fichiers relatifs aux animations
- **Fonts** : fichiers de police personnalisée
- **Images**
- **Imports** : fichiers importés depuis l'Assets Store
- **Materials**
- **Plugins** : dossier utilisé pour ajouter des fonctionnalités Android comme la gestion de NFC
- **Prefabs**
- **Scenes** : détail ci-dessous
- **Scripts** : tous les scripts utilisés dans le projet (possible de rediviser en sous-dossiers pour éviter d'avoir un nombre important de scripts en vrac)
- **Shaders**
- **Sounds** 
- **Textures**
- **Videos** : fichiers des petites vidéos utilisées dans le projet. Les vidéos plus conséquentes en poids seront streamées via une URL


### Scènes

| Nom de scène   | Description                                                                                                                                           |
|----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| `MainMenu`     | Menu de l'application sur un fond vidéo                                                                                                               |
| `FailsNFCScan` | Ecran d'attente du dépôt du téléphone sur un dock NFC pour lancer la scène suivante                                                                           |
| `NFCPlayVideo` | Lecteur de la vidéo des râtés de la conquête spatiale avec QCM à certains moments de la vidéo. L'utilisateur a le choix entre 2 réponses et les questions portent sur des aspects évoqués dans la vidéo  |
| `Launch`       | Lancement de la fusée (version alpha avec uniquement un modèle 3D qui décolle avec sons NASA et particules)                                           |
| `Combustion`   | Mise en scène d(un modèle simplifié d'un moteur de fusée avec lequel on peut intéragir pour le faire démarrer (mélange de carburants, allumeur, etc.) |
| `MoonMission/Introduction`   | Explications à l'utilisateur de l'atelier |
| `MoonMission/CrawlerVideo`   | Lecture d'une vidéo avec informations sur un crawler transporter |
| `MoonMission/FillTank`   | *WIP* : l'utilisateur doit choisir les bons carburants pour remplir la fusée |
| `MoonMission/AR`   | Scène en réalité augmentée avec des modèles 3D NASA (hangar, pas de tir et Saturn V) avec compte à rebours et décollage de la fusée avec sons immersifs |
| `MoonMission/MissionControlInfo`   | Explications pour la scène suivante |
| `MoonMission/MissionControl`   | Tableau de bord et timer pour effectuer des actions pour avancer dans la mission |
| `GoddardWorkshop`   | Informations sur Goddard, le précurseur de la conquête spatiale. Utilisation de l'AR avec Vuforia. **[Cette affiche](https://i.imgur.com/KD9xl6e.jpg) est nécessaire pour expérimenter cet atelier.** |
| `Selfie`   | Utilisation de la caméra frontale pour faire un selfie avec logo SpaceUP et partage sur les réseaux sociaux de son choix |

Le script `ScenesControl` met à disposition des méthodes pour charger les scènes avec une animation FadeIn/FadeOut. Il est accessible en ajoutant le prefab `SceneController` dans une scène.

### Modèles 3D

Certains modèles 3D ont été réalisé à la main et d'autres ont été récupéré via [la bibliothèque de modèles 3D de la NASA](https://nasa3d.arc.nasa.gov/models).
