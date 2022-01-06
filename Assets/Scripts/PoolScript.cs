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

    public GameObject whiteBall;

    private float checker = 0.0f;
    private float heightChecker = 0.0f;

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
    }

    private void ChangeHeight()
    {
        transform.position = new Vector3(transform.position.x, heightSlider.value, transform.position.z);
    }
}
