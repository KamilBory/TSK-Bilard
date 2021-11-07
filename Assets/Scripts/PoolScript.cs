using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    public Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        moveVec = new Vector3(-50.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += moveVec * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.05f);
    }
}
