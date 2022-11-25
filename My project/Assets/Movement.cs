using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontalInput, 0f, verticalInput);
    }
}
