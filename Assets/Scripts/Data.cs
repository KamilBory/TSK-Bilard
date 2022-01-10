using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public Slider angle;
    public Slider power;
    public Slider height;
    public GameObject [] bills;

    private string toFile = "";
    private StreamWriter writer;

    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter("C:/Studia/6sem/TSK/dane.txt", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            UpData();
            writer.Close();
            writer = new StreamWriter("C:/Studia/6sem/TSK/dane.txt", true);
        }
    }

    private void UpData()
    {
        for (int i = 0; i <16; i++)
        {
            toFile += bills[i].name.ToString();
            toFile += " ";
            toFile += bills[i].GetComponent<BallScript>().getVel().ToString();
            toFile += " ";
            toFile += bills[i].GetComponent<BallScript>().getDis().ToString();
            if (bills[i].name == "WhiteBall")
            {
                toFile += " ";
                toFile += angle.value.ToString();
                toFile += " ";
                toFile += power.value.ToString();
                toFile += " ";
                toFile += height.value.ToString();
                toFile += " ";
                toFile += bills[i].GetComponent<BallScript>().getSX().ToString();
                toFile += " ";
                toFile += bills[i].GetComponent<BallScript>().getSZ().ToString();
            }
            writer.WriteLine(toFile);
            toFile = "";
        }
    }
}
