using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeController : MonoBehaviour
{
    public char[,] Board = new char[5, 13];
    public Vector3 boxPos;
    public Vector3 fp;
    public Vector3 lp;
    public float dragDistance;

    // Start is called before the first frame update
    void Start()
    {
        boxPos = new Vector3(2,10,0);
        dragDistance = 30f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void toSwipe()
    {

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance)
                {//It's a drag
                    if ((lp.x > fp.x))  //If the movement was to the right)
                    {   //Right swipe
                        Debug.Log("Right Swipe");
                        move(transform.position.x + 1.2f, 1.2f);
                    }
                    else
                    {   //Left swipe
                        Debug.Log("Left Swipe");
                        move(transform.position.x - 1.2f, -1.2f);
                    }
                }
            }
        }
    }
    public (float x, float y) positionToIndex(Vector3 vector)
    {
        float pos_x = vector.x;
        float pos_y = vector.y;

        float ret_x = (pos_x + 2.4f / 1.2f);
        float ret_y = pos_x - 7;

        return (x: ret_x, y: ret_y);
    }

    public void move(float x, float value)
    {
        switch (Board[(int)positionToIndex(boxPos).x, (int)positionToIndex(boxPos).y])
        {
            case ' ':
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + value, 0);
                break;

            default:
                break;
        }
    }
}
