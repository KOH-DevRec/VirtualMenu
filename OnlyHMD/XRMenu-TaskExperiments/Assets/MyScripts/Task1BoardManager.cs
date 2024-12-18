using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1BoardManager : MonoBehaviour
{
    private GameObject Board;
    private GameObject QText;
    private GameObject ChoseN;
    private GameObject A1;
    private GameObject A2;
    private GameObject A3;
    private GameObject Light;
    private GameObject PlantL;
    private GameObject PlantS;
    private GameObject Art2;
    private GameObject Art4;
    private GameObject Art6;
    private GameObject PStars;

    public Text qt;
    public Text ct;
    public Text a1;
    public Text a2;
    public Text a3;
    public int qn;

    private int s;      //表示する必要選択数
    private int ss;     //既に選択した数(取得用)
    private int n;      //この問題に必要な選択数

    public bool x = false;
    // Start is called before the first frame update
    void Start()
    {
        FindGO();
        ActF();
    }

    // Update is called once per frame
    void Update()
    {
        //Task1の位置についた場合
        if (x == true)
        {
            QTextChange();
        }
    }

    void FindGO()
    {
        Board = this.gameObject;

        QText =     GameObject.Find("QuestionText");
        ChoseN =    GameObject.Find("choseText");
        A1 =        GameObject.Find("AnswerText1");
        A2 =        GameObject.Find("AnswerText2");
        A3 =        GameObject.Find("AnswerText3");

        Light =     GameObject.Find("Light");
        PlantL =    GameObject.Find("PlantL");
        PlantS =    GameObject.Find("PlantS");
        Art2 =      GameObject.Find("art2");
        Art4 =      GameObject.Find("art4");
        Art6 =      GameObject.Find("art6");

        PStars =    GameObject.Find("PStars");
    }

    void ActF()
    {
        QText.gameObject.SetActive(false);
        ChoseN.gameObject.SetActive(false);
        A1.gameObject.SetActive(false);
        A2.gameObject.SetActive(false);
        A3.gameObject.SetActive(false);

        Light.gameObject.SetActive(false);
        PlantL.gameObject.SetActive(false);
        PlantS.gameObject.SetActive(false);
        Art2.gameObject.SetActive(false);
        Art4.gameObject.SetActive(false);
        Art6.gameObject.SetActive(false);
        PStars.gameObject.SetActive(false);
    }

    void ActItemF()
    {
        Light.gameObject.SetActive(false);
        PlantL.gameObject.SetActive(false);
        PlantS.gameObject.SetActive(false);
        Art2.gameObject.SetActive(false);
        Art4.gameObject.SetActive(false);
        Art6.gameObject.SetActive(false);

        PStars.gameObject.SetActive(true);
    }

    void QTextChange()
    {
        QText.gameObject.SetActive(true);
        ChoseN.gameObject.SetActive(true);
        A1.gameObject.SetActive(true);
        A2.gameObject.SetActive(true);
        A3.gameObject.SetActive(true);

        switch (qn)
        {
            case 1:
                QText.GetComponent<TextMesh>().text = "間接照明の数";
                A1.GetComponent<TextMesh>().text = "2";
                A2.GetComponent<TextMesh>().text = "3";
                A3.GetComponent<TextMesh>().text = "4";

                //n = 10;
                //s = n - ss;
                //ChoseN.GetComponent<TextMesh>().text = ""+s;

                ActItemF();
                Light.gameObject.SetActive(true);
                break;
            case 2:
                QText.GetComponent<TextMesh>().text = "観葉植物の数";
                A1.GetComponent<TextMesh>().text = "3";
                A2.GetComponent<TextMesh>().text = "4";
                A3.GetComponent<TextMesh>().text = "6";


                ActItemF();
                PlantL.gameObject.SetActive(true);
                break;
            case 3:
                QText.GetComponent<TextMesh>().text = "観葉植物(小)の数";
                A1.GetComponent<TextMesh>().text = "3";
                A2.GetComponent<TextMesh>().text = "5";
                A3.GetComponent<TextMesh>().text = "6";



                ActItemF();
                PlantS.gameObject.SetActive(true);
                break;
            case 4:
                QText.GetComponent<TextMesh>().text = "この置物の数";
                A1.GetComponent<TextMesh>().text = "2";
                A2.GetComponent<TextMesh>().text = "4";
                A3.GetComponent<TextMesh>().text = "6";

                ActItemF();
                Art4.gameObject.SetActive(true);
                break;
            case 5:
                QText.GetComponent<TextMesh>().text = "この置物の数";
                A1.GetComponent<TextMesh>().text = "2";
                A2.GetComponent<TextMesh>().text = "4";
                A3.GetComponent<TextMesh>().text = "6";


                ActItemF();
                Art6.gameObject.SetActive(true);
                break;
            case 6:
                QText.GetComponent<TextMesh>().text = "この置物の数";
                A1.GetComponent<TextMesh>().text = "2";
                A2.GetComponent<TextMesh>().text = "4";
                A3.GetComponent<TextMesh>().text = "6";

                ActItemF();
                Art2.gameObject.SetActive(true);
                break;
            case 10:
                QText.GetComponent<TextMesh>().text = "Task1終了．";
                A1.GetComponent<TextMesh>().text = "";
                A2.GetComponent<TextMesh>().text = "";
                A3.GetComponent<TextMesh>().text = "";
                ChoseN.GetComponent<TextMesh>().text = "" ;

                ActItemF();
                break;

            default:
                QText.GetComponent<TextMesh>().text = "";
                A1.GetComponent<TextMesh>().text = "";
                A2.GetComponent<TextMesh>().text = "";
                A3.GetComponent<TextMesh>().text = "";
                ChoseN.GetComponent<TextMesh>().text = "";
                break;
        }
    }
}
