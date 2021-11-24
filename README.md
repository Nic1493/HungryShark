# HungryShark

Small game made in Unity for [LuvBugLearning](https://luvbuglearning.com), made in 4 hours.


## Approach
Knowing that this was a game designed for young children, I took a simplistic approach to the game's design. The aesthetic is designed around a light aquatic theme, and the touch controls aims to give the user smooth experience.

## Design and Gameplay
Use your mouse to drag the Shark around the screen to eat colourful fish. If the Shark touches a pufferfish, it will lose a life. The game is over when the Shark loses all 3 lives.  
Every 20 fish, the fish spawn rate, as well as the chances of a pufferfish spawning, will increase.

## Issues
The biggest issue was the time limit. Given 4 hours to:

- find and download all graphical assets
- create a new Unity project and properly set it up with a new GitHub repo
- code the game from scratch
- testplay the game
- ensure that the built application didn't have any bugs or inconsistencies

I ran very close to going over time. Fortunately, I was able to get a playable build done in time (albeit not as polished as I'd like).

Also, I'm usually not the one in charge of the creative aspects of the game, so I spent quite a bit time on making sure the game looks somewhat passable.

In terms of coding, I didn't run into any roadblocks. The game's scope was small and simple enough that I knew how to code everything.

## Improvements
Because of time constraints, the game lacks a lot of refinement. Given more time, I would do the following, in order of priority:

- Gameplay | Have the fish move in a non-linear path
    - currently, the fish move in the direction of its `moveDirection` vector, which is always set to `Vector3.left`. I can continuously rotate the vector and make the fish move in a sinusoidal path, giving more flavour to the gameplay
- Code | Refactor parts of the code to improve flexibility and scalability
    - to be honest, I treated this more like a hack-a-thon than anything. Given enough time, I would improve the codebase by de-coupling certain variables and improving its modularity
- Graphics | Add animations to the Shark and fish actors to improve gameplay feel and responsiveness
    - the Shark should open and close its jaws upon colliding with the fish
    - the Shark should have some sort of visual indicator upon colliding with a pufferfish
- Graphics | Improve game aesthetic
    - implement parallax scrolling background
    - utilize URP to add more dynamic lighting
- Graphics | Improve HUD and menu aesthetic
    - upon gaining score, have the current score value interpolate to the new score value, rather than just setting it to the new value
    - use non-default Unity sprites for the buttons and panels
    - improve text readability (despite the black outline, it's still blue text on blue background)
- Game design | Add highscores list
- Code | Add more comments to code
    - halfway through I lost discipline with my documentation, and had to shift my focus to completing the final product

## Other notes
- Gameplay implemented in Unity v2020.2.0f1
- Menu.cs and CoroutineHelper.cs were brought in from my previous projects. All other scripts were created within the time limit
- Fish and background assets made by kenney
- Fonts grabbed from dafont.com
