using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 gravity = new Vector3(0.0f, 0.0f, 0.0f);
    private RigidBody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
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

        BallsCollision();
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

    private void BallsCollision(Collision collision) {
        if (collision.gameObject.tag == "Ball") 
        {
            Vector3 normal = new Vector3(gameObject.position - collision.position);

            Vector3 unitNormal = normal * (1 / normal.magnitude);

            Vector3 unitTangent = new Vector3(-normal.z, normal.y, normal.x);

            float velNormal1 = Vector3.Dot(unitNormal, rigidbody.velocity);
            float velTangent1 = Vector3.Dot(unitTangent, rigidbody.velocity);
            float velNormal2 = Vector3.Dot(unitNormal, collision.rigidbody.velocity);
            float velTangent2 = Vector3.Dot(unitTangent, collision.rigidbody.velocity);

            Vector3 velNormalTag1 = unitNormal * velNormal1;
            Vector3 velTangentTag1 = unitTangent * velTangent1;
            Vector3 velNormalTag2 = unitNormal * velNormal2;
            Vector3 velTangentTag2 = unitTangent * velTangent2;

            rigidbody.AddForce(velNormalTag1 + velTangentTag1);
            collision.rigidbody.AddForce(velNormalTag2 + velTangentTag2);
        }
    }
}
