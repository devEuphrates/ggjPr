using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public List<GameObject> obs;

    float tm = 0f;
    void Update()
    {
        if (GameManager.Instance.gameEnded) return;
        System.Random rnd = new System.Random((int)Time.time);
        if (tm == 0)
        {
            tm = (float)rnd.Next(1, 2);
        }

        tm -= Time.deltaTime;

        if (tm <= 0f)
        {
            tm = 0;
            int ch = rnd.Next(1, 10);
            if (ch <= 4)
            {
                GameObject go = obs[rnd.Next(0, obs.Count)];
                Instantiate(go, new Vector3(0f, -10f, 0f), Quaternion.identity, transform);
            }
        }
    }
}
