using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolScript : MonoBehaviour
{
    public Slider slider;
    public Slider heightSlider;
    public Slider powerSlider;

    public GameObject whiteBall;

    private float checker = 0.0f;
    private float heightChecker = 0.0f;
    private Vector3 enrtyPosition = new Vector3(63.12f, 4.85f, -0.2f);
    private Vector3 moveVec = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        //moveVec = new Vector3(-100.0f, 0.0f, 0.0f);
        slider.onValueChanged.AddListener(delegate
        {
            GoAround();
        });

        heightSlider.onValueChanged.AddListener(delegate
        {
            ChangeHeight();
        });

        powerSlider.onValueChanged.AddListener(delegate
        {
            ChangeDistance();
        });
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += moveVec * Time.deltaTime;
    }

    private void GoAround()
    {
        float tmp = slider.value - checker;
        transform.RotateAround(whiteBall.transform.position, new Vector3 (0, 1, 0), tmp);
        checker = slider.value;

        float degree = slider.value;
        float x = 0.0f;
        float z = 0.0f;
        if (slider.value < 90.0f)
        {
            float tmp1 = degree / 90.0f;
            x = (1.0f - tmp1) * powerSlider.value;
            z = tmp1 * powerSlider.value;
            enrtyPosition = new Vector3(transform.position.x - x, transform.position.y, transform.position.z + z);
        }
        else if (slider.value >= 90.0f && slider.value < 180.0f)
        {
            float tmp1 = (degree - 90.0f) / 90.0f;
            x = tmp1 * powerSlider.value;
            z = (1.0f - tmp1) * powerSlider.value;
            enrtyPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        }
        else if (slider.value >= 180.0f && slider.value < 270.0f)
        {
            float tmp1 = (degree - 180.0f) / 90.0f;
            x = (1.0f - tmp1) * powerSlider.value;
            z = tmp1 * powerSlider.value;
            enrtyPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z);
        }
        else if (slider.value >= 270.0f)
        {
            float tmp1 = (degree - 270.0f) / 90.0f;
            x = tmp1 * powerSlider.value;
            z = (1.0f - tmp1) * powerSlider.value;
            enrtyPosition = new Vector3(transform.position.x - x, transform.position.y, transform.position.z - z);
        }

    }

    private void ChangeHeight()
    {
        transform.position = new Vector3(transform.position.x, heightSlider.value, transform.position.z);
    }

    private void ChangeDistance()
    {
        float degree = slider.value;
        float x = 0.0f;
        float z = 0.0f;

        if(degree < 90.0f)
        {
            // dodaj x, odejmij z
            float tmp = degree / 90.0f;
            x = enrtyPosition.x + (1.0f - tmp) * powerSlider.value;
            z = enrtyPosition.z - tmp * powerSlider.value;
        }
        else if(degree >= 90.0f && degree < 180.0f)
        {
            // odejmij x, odejmij z
            float tmp = (degree - 90.0f) / 90.0f;
            x = enrtyPosition.x - tmp * powerSlider.value;
            z = enrtyPosition.z - (1.0f - tmp) * powerSlider.value;
        }
        else if(degree >= 180.0f && degree < 270.0f)
        {
            // odejmij x, dodaj z
            float tmp = (degree - 180.0f) / 90.0f;
            x = enrtyPosition.x - (1.0f - tmp) * powerSlider.value;
            z = enrtyPosition.z + tmp * powerSlider.value;
        }
        else if(degree >= 270.0f)
        {
            // dodaj x, dodaj z
            float tmp = (degree - 270.0f) / 90.0f;
            x = enrtyPosition.x + tmp * powerSlider.value;
            z = enrtyPosition.z + (1.0f - tmp) * powerSlider.value;
        }

        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void HitBall()
    {
        moveVec = new Vector3(whiteBall.gameObject.transform.position.x - transform.position.x, 0.0f, whiteBall.gameObject.transform.position.z - transform.position.z);
        moveVec *= powerSlider.value / 5.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "WhiteBall")
        {
            collision.rigidbody.AddForce(moveVec * powerSlider.value);
            moveVec = new Vector3(0.0f, 0.0f, 0.0f);
            Destroy(gameObject);
        }
    }
}