using UnityEngine;
using UnityEngine.EventSystems;

namespace _Main.Scripts.MobileInput
{
    public class MobileInputHandler : MonoBehaviour
    {
        public float VerticalInput { get; private set; }
        public float HorizontalInput { get; private set; }
        public float PinchDelta { get; private set; }

        private float _previousPinchDistance;

        public void Update()
        {
            HandleTouchRotation();
            HandlePinchZoom();
        }

        void HandleTouchRotation()
        {
            VerticalInput = 0f;
            HorizontalInput = 0f;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    return;

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = touch.deltaPosition;

                    VerticalInput = -delta.y;
                    HorizontalInput = delta.x;
                }
            }
        }


        private void HandlePinchZoom()
        {
            PinchDelta = 0f;

            if (Input.touchCount == 2)
            {
                Touch t0 = Input.GetTouch(0);
                Touch t1 = Input.GetTouch(1);

                float currentDistance = Vector2.Distance(t0.position, t1.position);
                float prevDistance = Vector2.Distance(t0.position - t0.deltaPosition, t1.position - t1.deltaPosition);

                PinchDelta = prevDistance - currentDistance;
            }
        }
    }
}