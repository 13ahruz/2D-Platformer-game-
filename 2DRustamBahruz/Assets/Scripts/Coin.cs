using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    Transform cameraPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraPos.transform.position.x >= transform.position.x + 31.5)
        {
            transform.position = new Vector3(transform.position.x + 63, transform.position.y, transform.position.z);

        }
    }
}
