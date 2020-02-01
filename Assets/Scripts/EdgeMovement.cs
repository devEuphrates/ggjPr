using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMovement : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = GameManager.Instance.speed;
    }

    void Update()
    {
        speed = GameManager.Instance.speed;

        transform.Translate(0f, speed * Time.deltaTime * 2f, 0f);

        if (transform.position.y >= 20) Destroy(this.gameObject);
    }
}
