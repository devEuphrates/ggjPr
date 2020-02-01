using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    private char[,] Board = new char[5, 13];
    private int player_x, player_y;
    public float fall_speed = 1f,t = 0f;
    public List<Block_SO> blocks;
    public List<GameObject> cubes = new List<GameObject>();
    public GameObject wall;

    private void InitBoard()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j == 0 || j == 4)
                {
                    Board[j, i] = '#';
                }
                else
                {
                    Board[j, i] = ' ';
                }
            }
        }
    }

    private void Start()
    {
        InitBoard();
        SpawnGame();
    }

    public void MoveBoardUp(char [] row)
    {
        for (int i = 1; i < 13; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Board[j, i - 1] = Board[j, i];
            }
        }

        for (int k = 0; k < 5; k++)
        {
            Board[k, 12] = row[k];
        }

        SpawnGame();
    }

    public (float pos_x, float pos_y) IndexToPosition(int x, int y)
    {
        float ret_x;
        float ret_y;
        ret_x = -2.4f + 1.2f * x;
        ret_y = 7 - y;
        return (ret_x, ret_y);
    }

    public void SpawnGame()
    {
        foreach (var item in cubes)
        {
            Destroy(item);
        }

        cubes.Clear();

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Block_SO sel_block = blocks.FindLast(p => p.indx == Board[j, i]);
                if (sel_block.spawnPrefab)
                {
                    var ipo = IndexToPosition(j, i);
                    GameObject go = Instantiate(sel_block.prefab, new Vector3(ipo.pos_x, ipo.pos_y, 0f), Quaternion.identity);
                    cubes.Add(go);
                }
            }
        }
    }
}
