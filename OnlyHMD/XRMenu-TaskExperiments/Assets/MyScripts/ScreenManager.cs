using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject T2t;
    private Task2Top t2t = new Task2Top();

    List<GameObject> childList = new List<GameObject>();
    List<Renderer> childMaterialList = new List<Renderer>();

    [SerializeField]
    public Material Material1;      //Blue
    [SerializeField]
    public Material Material2;      //Red

    private int c = 0;
    private int s = 0;
    private int randomN;
    private int randomM;

    //public int[,] screenQ = new int[30,2];

    private string massageM;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクト格納、非表示
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
            childMaterialList.Add(child.GetComponent<Renderer>());
            childMaterialList[c].enabled = false;

            c++;
        }

        t2t = T2t.GetComponent<Task2Top>();

        //問題格納
        /*
         for(int i = 0; i > 2; i++)
         {
             for(int j = 0; j > 30; j++)
             {
                 if (i == 0)
                 {
                     randomN = Random.Range(0, 6);
                     screenQ[j, i] = randomN;
                 }
                 else
                 {
                     randomM = Random.Range(1, 3);
                     screenQ[j, i] = randomM;
                 }
             }
         }
         Debug.Log("スクリーン："+screenQ);
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (t2t.End == false)
        {
            if (t2t.Q == true)
            {
                randomN = Random.Range(0, 6);
                randomM = Random.Range(1, 3);
                ScreenLighting(randomN, randomM);

                t2t.SnumN = randomN;
                t2t.SnumM = randomM;

                //ScreenLighting(screenQ[s,0], screenQ[s, 1]);

                if (randomM == 1)
                {
                    massageM = "B";
                    Debug.Log(randomN + ", " + massageM);
                }
                else
                {
                    massageM = "R";
                    Debug.Log(randomN + ", " + massageM);
                }
            }

            if (t2t.A == true)
            {
                ScreenOff(randomN);
            }
        }
        else if (t2t.End == true)
        {

        }
    }

    //スクリーン色指定・表示
    void ScreenLighting(int n, int m)
    {
        if (m == 1)
        {
            childMaterialList[n].material = Material1;
        }else if (m == 2)
        {
            childMaterialList[n].material = Material2;
        }

        childMaterialList[n].enabled = true;
        t2t.Q = false;
    }

    void ScreenOff(int n)
    {
        childMaterialList[n].enabled = false;
        t2t.A = false;
    }

}
