using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FallManager fm;
    float t = 0.10f, p = 0f;
    private BObstacle emp;
    private int level;
    public int points;

    private void Start()
    {
        level = 1;
        points = 0;
        char[,] ll = new char[5,1];
        for (int i = 1; i < 4; i++)
        {
            ll[i, 0] =  ' ';
        }
        ll[0, 0] = '#';
        ll[4, 0] = '#';

        emp = new BObstacle(1, ll, 1);
    }

    void Update()
    {
        t = 0.02f / fm.fall_speed;
        p += Time.deltaTime;
        if (p >= t)
        {
            p = 0f;
            Debug.Log("#1");
            InsertObstacle(emp);
        }
    }

    void InsertObstacle(BObstacle obstacle)
    {
        Debug.Log(obstacle.height);
        for (int i = 0; i < obstacle.height; i++)
        {
            char[] row = new char[5];

            for (int j = 0; j < 5; j++)
            {
                row[j] = obstacle.layout[j, i];
            }
            Debug.Log("#2");
            fm.MoveBoardUp(row);
        }
    }
}

class BObstacle
{
    public int level;
    public char[,] layout;
    public int height;

    public BObstacle(int lvl, char[,] lo, int _height)
    {
        level = lvl;
        layout = lo;
        height = _height;
    }
}
