# TowerDefense3D

This repository contains the complete source code for a Tower Defense game developed in Unity. The game features various functionalities including turret building, enemy spawning, wave management, and more. Below is an overview of the project structure and key components:

# Project Structure:
Assets: Contains all the game assets including scripts, prefabs, scenes, and other resources.
Scripts: Includes all the C# scripts responsible for game logic and functionalities.
Prefabs: Contains prefabricated game objects such as turrets, enemies, effects, etc.
Scenes: Contains different game scenes including main gameplay scene, menu scene, etc.

# Key Components:
BuildManager.cs: Manages turret building functionality, turret selection, node selection, etc.
BulletScript.cs: Controls the behavior of bullets fired from turrets, including seeking targets and causing damage.
Enemy.cs: Defines enemy behavior such as movement, taking damage, and death.
GameManager.cs: Manages game states, including game over and level completion.
WaveSpawner.cs: Handles enemy wave spawning, countdown, and wave management.
NodeScript.cs: Manages individual nodes where turrets can be built, including building, upgrading, and selling turrets.
TurretScript.cs: Controls the behavior of turrets, including targeting, shooting, and dealing damage.

# How to Use:
Clone the repository to your local machine.
Open the project in Unity Editor.
Explore the scripts and scenes to understand the game logic and functionalities.
Modify and extend the game as per your requirements.
Build and run the game to play and test your modifications.

# Additional Notes:
Make sure to set up appropriate scenes for menu, gameplay, etc., as per your project requirements.
Customize assets, scripts, and game mechanics to suit your game design and vision.
Feel free to contribute to the project by fixing bugs, adding new features, or optimizing existing code.
