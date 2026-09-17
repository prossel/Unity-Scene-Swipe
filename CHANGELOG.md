# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-09-17

- Initial release: `SceneSwipe` prefab with `SwipeSceneNavigator` component.
- Detects left/right swipe (touch or mouse) via direct Input System polling,
  with no Canvas/Graphic/Raycaster so it never blocks other interactions.
- Loads next/previous scene using Build Settings order, wrapping at the ends.
