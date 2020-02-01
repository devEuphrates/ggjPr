using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSc : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        SwipeControls sc = col.transform.GetComponent<SwipeControls>();
        if (sc == null) return;
        if (col.transform.position.x < 0)
        {
            sc.target = new Vector3(-1f, 3f, 0f);
            sc.ismoving = true;
            sc.x = 0;
            sc.stopSL = true;
        }
        else if (col.transform.position.x > 0)
        {
            sc.target = new Vector3(1f, 3f, 0f);
            sc.ismoving = true;
            sc.x = 2;
            sc.stopSR = true;
        }
    }
}
