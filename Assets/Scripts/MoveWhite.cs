using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhite : MonoBehaviour
{
    public GameObject pool;
    public float offset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            offset -= 0.1f;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
            pool.transform.position = new Vector3(pool.transform.position.x, pool.transform.position.y, pool.transform.position.z - 0.1f);
        }

        if (Input.GetKey("x"))
        {
            offset += 0.1f;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            pool.transform.position = new Vector3(pool.transform.position.x, pool.transform.position.y, pool.transform.position.z + 0.1f);
        }
    }

    public float getOffset()
    {
        return offset;
    }
}
