using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.position += new Vector3(-1 * speed * Time.deltaTime, 0f, 0f);

        if (cam.position.x >= transform.GetChild(0).transform.position.x)
        {
            transform.position = new Vector2(cam.position.x, transform.position.y);
        }
    }
}
