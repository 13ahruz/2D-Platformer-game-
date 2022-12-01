using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float offset;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3((player.transform.position.x + offset), transform.position.y, transform.position.z);
        }
    }
}
