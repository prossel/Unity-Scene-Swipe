# SceneSwipe

A drop-in prefab that lets the player swipe left/right anywhere on screen to move
to the next/previous scene in Build Settings order.

## Usage

1. Drag `Assets/SceneSwipe/Prefabs/SceneSwipe.prefab` into any scene.
2. Make sure the scenes you want to navigate between are added (and ordered) in
   **File > Build Settings**. Navigation wraps around at the first/last scene.

No Canvas, Graphic, or `EventSystem` is required: the prefab reads
`Touchscreen`/`Mouse` directly via the Input System package, so it never
consumes UI raycasts and cannot block clicks/taps on other objects in the scene.

## Inspector fields (`SwipeSceneNavigator`)

| Field | Default | Description |
|---|---|---|
| `minSwipeDistancePixels` | 75 | Minimum horizontal drag distance (in pixels) to count as a swipe. |
| `maxSwipeDurationSeconds` | 0.75 | Maximum press-to-release time for the gesture to still count as a swipe (rejects slow drags). |
| `maxVerticalRatio` | 0.5 | Maximum allowed vertical movement relative to horizontal movement, to reject diagonal/vertical drags. |

## Requirements

- Input System package (`com.unity.inputsystem`), with **Active Input Handling**
  set to "Input System Package (New)" or "Both" in Player Settings.
- The relevant scenes present in Build Settings.

## Known limitations

- Swipe navigation is active at all times, including while a YarnSpinner
  dialogue is running.
