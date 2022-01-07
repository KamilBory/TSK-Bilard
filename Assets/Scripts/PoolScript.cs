using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PoolScript : MonoBehaviour
{
    public Vector3 moveVec;
    public Slider slider;
    public Slider heightSlider;
    public Slider powerSlider;

    public GameObject whiteBall;

    private float checker = 0.0f;
    private float heightChecker = 0.0f;
    private Vector3 enrtyPosition = new Vector3(63.12f, 4.85f, -0.2f);

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
        //transform.LookAt(new Vector3(facing.position.x, facing.position.y, facing.position.z));
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void GoAround()
    {
        float tmp = slider.value - checker;
        transform.RotateAround(whiteBall.transform.position, new Vector3 (0, 1, 0), tmp);
        checker = slider.value;

        if(slider.value < 90.0f)
        {
            enrtyPosition = new Vector3(transform.position.x + powerSlider.value, transform.position.y, transform.position.z - powerSlider.value);
        }
        else if (slider.value >= 90.0f && slider.value < 180.0f)
        {
            enrtyPosition = new Vector3(transform.position.x - powerSlider.value, transform.position.y, transform.position.z - powerSlider.value);
        }
        else if (slider.value >= 180.0f && slider.value < 270.0f)
        {
            enrtyPosition = new Vector3(transform.position.x - powerSlider.value, transform.position.y, transform.position.z + powerSlider.value);
        }
        else if (slider.value >= 270.0f)
        {
            enrtyPosition = new Vector3(transform.position.x + powerSlider.value, transform.position.y, transform.position.z + powerSlider.value);
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
}