using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Top : MonoBehaviour
{
    public GameObject Camera;
    private CameraMoveManager cmm = new CameraMoveManager();
    private GameObject maru2;
    private GameObject batu2;
    private GameObject EndText;

    public string Bnum;
    public int SnumN;
    public int SnumM;
    public bool Q;
    private int Qc;
    public bool A;

    public int answerT2_M;  //正解数
    public int answerT2_B;  //不正解数
    public bool f;

    public bool End;
    public bool Write;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();    //計測時間測定
    private long reactT;
    public List<long> reactAll;
    // Start is called before the first frame update
    void Start()
    {
        cmm = Camera.GetComponent<CameraMoveManager>();
        maru2 = GameObject.Find("maru2");
        batu2 = GameObject.Find("batu2");
        EndText = GameObject.Find("ButtonText1");

        maru2.gameObject.SetActive(false);
        batu2.gameObject.SetActive(false);
        EndText.gameObject.SetActive(false);

        Bnum = null;
        Q = false;
        Qc = 0;
        A = false;

        answerT2_M = 0;
        answerT2_B = 0;

        End = false;
        Write = false;

        f = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cmm.taskN == 2)
        {
            ButtonJudge();

            if (Input.GetKeyDown(KeyCode.F3))
            {
                StartCoroutine(QScreen());
            }
        }
    }

    void ButtonJudge()
    {
        switch (Bnum)
        {
            case "Button1":
                if (SnumM == 2 && SnumN < 3)
                {
                    Answer1();
                }
                else
                {
                    Answer2();
                }
                break;

            case "Button2":
                if (SnumM == 1 && SnumN < 3)
                {
                    Answer1();
                }
                else
                {
                    Answer2();
                }
                break;

            case "Button3":
                if (SnumM == 1 && SnumN >= 3)
                {
                    Answer1();
                }
                else
                {
                    Answer2();
                }
                break;

            case "Button4":
                if (SnumM == 2 && SnumN >= 3)
                {
                    Answer1();
                }
                else
                {
                    Answer2();
                }
                break;

            default:
                break;
        }
    }

    void Answer1()
    {
        if (f == true)
        {
            maru2.gameObject.SetActive(true);
            batu2.gameObject.SetActive(false);
            StartCoroutine(AnsF());
            answerT2_M++;
            Debug.Log("正解数：" + answerT2_M);
            f = false;
        }
    }
    void Answer2()
    {
        if (f == true)
        {
            maru2.gameObject.SetActive(false);
            batu2.gameObject.SetActive(true);
            StartCoroutine(AnsF());
            answerT2_B++;
            Debug.Log("不正解数：" + answerT2_B);
            f = false;
        }
    }

    IEnumerator AnsF()
    {
        reactT = sw.ElapsedMilliseconds;
        reactAll.Add(reactT);
        yield return new WaitForSeconds(2.0f);
        maru2.gameObject.SetActive(false);
        batu2.gameObject.SetActive(false);

        A = true;

        yield return null;
    }

    IEnumerator QScreen()
    {
        yield return new WaitForSeconds(2.0f);
        //Q = true;
        //Qc++;

        for (Qc=0; Qc < 10; Qc++)
        {
            yield return new WaitForSeconds(9.0f);
            Q = true;
            sw.Restart();
        }

        yield return new WaitForSeconds(9.0f);
        End = true;
        Write = true;
        EndText.gameObject.SetActive(true);
        yield return null;
    }
}
