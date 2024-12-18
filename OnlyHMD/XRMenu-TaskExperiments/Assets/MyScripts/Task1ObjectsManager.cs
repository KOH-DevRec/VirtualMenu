using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1ObjectsManager : MonoBehaviour
{
    private GameObject Q1;
    private GameObject Q2;
    private GameObject Q3;
    private GameObject Q4;
    private GameObject Q5;
    private GameObject Q6;
    private GameObject Q7;
    private GameObject Q8;
    private GameObject Q9;

    public int Q = 0;

    // Start is called before the first frame update
    void Start()
    {
        FindGO();

    }

    // Update is called once per frame
    void Update()
    {
        ActSwitch();
    }

    void FindGO()
    {
        Q1 = GameObject.Find("Q1Objects");
        Q2 = GameObject.Find("Q2Objects");
        Q3 = GameObject.Find("Q3Objects");
        Q4 = GameObject.Find("Q4Objects");
        Q5 = GameObject.Find("Q5Objects");
        Q6 = GameObject.Find("Q6Objects");
        Q7 = GameObject.Find("Q7Objects");
        Q8 = GameObject.Find("Q8Objects");
        Q9 = GameObject.Find("Q9Objects");
    }

    void ActF()
    {
        Q1.gameObject.SetActive(false);
        Q2.gameObject.SetActive(false);
        Q3.gameObject.SetActive(false);
        Q4.gameObject.SetActive(false);
        Q5.gameObject.SetActive(false);
        Q6.gameObject.SetActive(false);
        Q7.gameObject.SetActive(false);
        Q8.gameObject.SetActive(false);
        Q9.gameObject.SetActive(false);
    }

    //Q=1~9で指定オブジェクト表示、Q=0で全非表示
    void ActSwitch()
    {
        switch (Q)
        {
            case 1:
                Q1.gameObject.SetActive(true);
                break;
            case 2:
                Q2.gameObject.SetActive(true);
                break;
            case 3:
                Q3.gameObject.SetActive(true);
                break;
            case 4:
                Q4.gameObject.SetActive(true);
                break;
            case 5:
                Q5.gameObject.SetActive(true);
                break;
            case 6:
                Q6.gameObject.SetActive(true);
                break;
            case 7:
                Q7.gameObject.SetActive(true);
                break;
            case 8:
                Q8.gameObject.SetActive(true);
                break;
            case 9:
                Q9.gameObject.SetActive(true);
                break;
            case 0:
                ActF();
                break;
        }
    }
}
