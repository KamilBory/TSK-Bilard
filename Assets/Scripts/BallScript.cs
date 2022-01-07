using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 gravity = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded)
        {
            gravity = new Vector3(0.0f, -15.0f, 0.0f);
        }
        else
        {
            gravity = new Vector3(0.0f, 0.0f, 0.0f);
        }

        transform.position += gravity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Table")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Table")
        {
            isGrounded = false;
        }
    }
}
