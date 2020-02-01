using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class dene : MonoBehaviour
{
    public int flatSpeed;
    public int cnt;
    private char[,] Board = new char[5, 13];
    Timer timer = new System.Timers.Timer();
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        flatSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        swipe();
    }

    public (float pos_x, float pos_y) IndexToPosition(float x, float y)
    {
        float ret_x;
        float ret_y;
        ret_x = 2.4f - 1.2f * x;
        ret_y = 7 - y;
        return (ret_x, ret_y);
    }

    public void Adim(object source, ElapsedEventArgs e)
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 nextPos = new Vector3(transform.position.x, transform.position.y + (IndexToPosition(x:0,y:transform.position.y+1).pos_y)/flatSpeed, 0);
        if (cnt == 10)
        {
            timer.Stop();
        }
    }

    public void swipe()
    {
        cnt = 0;
        timer.Elapsed += new ElapsedEventHandler(Adim);
        timer.Interval = 100;
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                timer.Start();
            }
        }
    }
}
