using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.FillHole(this.transform);
    }
}
