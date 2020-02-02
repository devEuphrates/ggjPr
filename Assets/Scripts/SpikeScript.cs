using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Kill();
    }
}
