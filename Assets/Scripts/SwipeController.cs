using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public Vector3 originalPos;
    public Vector3 touchPos;
    public Vector3 currentPos;
    public Vector3 nextPos;
    public float dragDistance;
    public float time;
    public Touch touch = new Touch();
    public Input input = new Input();

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(2, 10, 0);
        dragDistance = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        toSwipe();
        move();
    }
    public void toSwipe()
    {
        if(Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            touchPos = touch.position;
            if(touch.phase == TouchPhase.Moved)
            {
                currentPos = touch.position;
            }
        }
        nextPos.x = originalPos.x + touchPos.x - currentPos.x;
    }

    public void move()
    {
        transform.position = Vector3.Lerp(originalPos, nextPos, 0.2f);
    }
}
