# 🐸 Frogger | Made with Unity

One of the small games in Unity I'm making to relearn and master Unity's fundamentals.

This project is based on [Zigurous's Youtube Video on How to make Frogger in Unity](https://www.youtube.com/watch?v=GxlxZ5q__Tc)

## 📝 My Improvements

- **More consistent Grid Movement.** I didn't use Coroutines for the movement as the destination could end up on inconsistent float values for the transform. I restricted the destination at y but not x since the home-zones don't exist on a rounded grid cell at x. Queuing the movement from one coroutine to the next also leads to inconsistent float values for the transform. I used a movePoint for moving at a rounded value and the transform of the frogger, just follows it.
- **Animator.** Used Unity's animation system instead of just changing the sprites via code.

![demo.gif](demo.gif)
