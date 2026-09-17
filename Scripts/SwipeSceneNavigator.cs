using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace SceneSwipe
{
    /// <summary>
    /// Detects a horizontal swipe (touch or mouse drag) anywhere on screen and loads the
    /// previous/next scene in Build Settings order. Reads input devices directly, so it
    /// never consumes UI raycasts and cannot block other interactions.
    /// </summary>
    public class SwipeSceneNavigator : MonoBehaviour
    {
        [SerializeField] private float minSwipeDistancePixels = 75f;
        [SerializeField] private float maxSwipeDurationSeconds = 0.75f;
        [SerializeField] private float maxVerticalRatio = 0.5f;

        private bool isTracking;
        private Vector2 startPosition;
        private double startTime;

        private void Update()
        {
            var touch = Touchscreen.current?.primaryTouch;
            if (touch != null)
            {
                if (touch.press.wasPressedThisFrame) BeginTracking(touch.position.ReadValue());
                else if (touch.press.wasReleasedThisFrame) EndTracking(touch.position.ReadValue());
                return;
            }

            var mouse = Mouse.current;
            if (mouse == null) return;

            if (mouse.leftButton.wasPressedThisFrame) BeginTracking(mouse.position.ReadValue());
            else if (mouse.leftButton.wasReleasedThisFrame) EndTracking(mouse.position.ReadValue());
        }

        private void BeginTracking(Vector2 position)
        {
            isTracking = true;
            startPosition = position;
            startTime = Time.unscaledTimeAsDouble;
        }

        private void EndTracking(Vector2 endPosition)
        {
            if (!isTracking) return;
            isTracking = false;

            // Ignore slow drags so this doesn't fire on deliberate UI interactions.
            if (Time.unscaledTimeAsDouble - startTime > maxSwipeDurationSeconds) return;

            var delta = endPosition - startPosition;
            if (Mathf.Abs(delta.x) < minSwipeDistancePixels) return;
            if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x) * maxVerticalRatio) return;

            LoadRelativeScene(delta.x < 0 ? 1 : -1);
        }

        private static void LoadRelativeScene(int direction)
        {
            var sceneCount = SceneManager.sceneCountInBuildSettings;
            if (sceneCount <= 1) return;

            var nextIndex = (SceneManager.GetActiveScene().buildIndex + direction + sceneCount) % sceneCount;
            SceneManager.LoadScene(nextIndex);
        }
    }
}
