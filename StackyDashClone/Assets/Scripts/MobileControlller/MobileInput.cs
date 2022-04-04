using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get; }

    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    public Vector2 swipeDelta, startTouch;
    private const float deadZone = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Reset  all bools.
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;

        //Input

        #region Pc Controller
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        #endregion

        #region Mobile Controller
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }

        }

        #endregion
        //  We calculate distance

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // For Mobile
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // For Pc
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }
        }

        //  Deadzone Control
        if (swipeDelta.magnitude > deadZone)
        {
            // IsDeadZone
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left ? or Right ?
                if (x < 0)
                {
                    // left
                    swipeLeft = true;
                }
                else
                {
                    // right
                    swipeRight = true;
                }
            }
            else
            {
                //Down ? or Up ?
                if (y < 0)
                {
                    // down
                    swipeDown = true;
                }
                else
                {
                    // up
                    swipeUp = true;
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
