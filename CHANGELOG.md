# Changelog

## [1.0.0] - 2026-09-17

- Initial release: `SceneSwipe` prefab with `SwipeSceneNavigator` component.
- Detects left/right swipe (touch or mouse) via direct Input System polling,
  with no Canvas/Graphic/Raycaster so it never blocks other interactions.
- Loads next/previous scene using Build Settings order, wrapping at the ends.
