using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public Vector3 boxPos;
    public Vector3 fp;
    public float dragDistance;
    public int x = 1;
    public bool ismoving = false, stopSR = false, stopSL = false;
    public Vector3 target;
    public GameObject cube;
    void Start()
    {
        dragDistance = Screen.width / 5;
        boxPos = new Vector3(2, 10, 0);
    }

    void Update()
    {
        if (ismoving)
        {
            MoveToPos();
            return;
        }

        toSwipe();
    }

    void MoveToPos()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.2f);
        if (Vector3.Distance(transform.position, target) <= 0.2f)
        {
            transform.position = target;
            ismoving = false;
        }
    }

    public void toSwipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                stopSL = false;
                stopSR = false;
            }
            else
            {
                if (touch.position.x - fp.x < 0 && Mathf.Abs(touch.position.x - fp.x) >= dragDistance && !stopSL)
                {
                    float mx = transform.position.x - 1f;
                    mx = Mathf.Clamp(mx, -1.5f, 1.5f);
                    target = new Vector3(mx, transform.position.y, transform.position.z);
                    ismoving = true;
                    x--;
                }
                else if (touch.position.x - fp.x > 0 && Mathf.Abs(touch.position.x - fp.x) >= dragDistance && !stopSR)
                {
                    float mx = transform.position.x + 1f;
                    mx = Mathf.Clamp(mx, -1.5f, 1.5f);
                    target = new Vector3(mx, transform.position.y, transform.position.z);
                    ismoving = true;
                    x++;
                }
            }
        }
    }
}
