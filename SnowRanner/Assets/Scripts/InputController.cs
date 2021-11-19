using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector3 vec;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -vec.x)
        {
            transform.position -= vec;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += vec;
        }
    }
}
