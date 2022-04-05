using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public static PlayerController instance;
    private bool isMoving = false;
    private Rigidbody rb;
    public GameObject dashesParent;
    public GameObject prevDash;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving )
        {
            isMoving = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving)
        {
            isMoving = true;
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;

        }
        if (rb.velocity == Vector3.zero)
        {
            // Stop
            isMoving = false;
        }
    }


    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.070f;
        dash.transform.localPosition = pos;
        Vector3 chrPos = transform.localPosition;
        chrPos.y += 0.070f;
        transform.localPosition = chrPos;
        prevDash = dash;


        prevDash.GetComponent<BoxCollider>().isTrigger = false;




    }

}
