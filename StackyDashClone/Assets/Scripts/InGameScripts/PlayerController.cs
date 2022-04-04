using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private bool isMoving = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            rb.velocity = Vector3.left * speed * Time.deltaTime;

        }
       else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            rb.velocity = Vector3.right * speed * Time.deltaTime;

        }
       else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp)
        {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;

        }
       else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown)
        {
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;

        }
    }
}
