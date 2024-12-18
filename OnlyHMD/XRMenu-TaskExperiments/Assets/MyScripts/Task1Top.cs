using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Task1Top : MonoBehaviour
{
    public GameObject Camera;
    public GameObject T1bm;
    public GameObject T1om;
    private CameraMoveManager cmm = new CameraMoveManager();
    private Task1BoardManager board = new Task1BoardManager();
    private Task1ObjectsManager obj = new Task1ObjectsManager();

    public GameObject maru;
    public GameObject batu;
    public GameObject cons;

    public int Qnum = 0;    //1~3で問題を指示
    public int rotateN = 0; //回転回数(何問目かを計測)
    public int Ans = 0;
    public bool R = false;  //trueで3秒後回転

    public string Bnum;
    private string Anum;

    public int answerT1_M;  //正解数
    public int answerT1_B;  //不正解数

    public bool f;
    // Start is called before the first frame update
    void Start()
    {
        cmm = Camera.GetComponent<CameraMoveManager>();
        board = T1bm.GetComponent<Task1BoardManager>();
        obj = T1om.GetComponent<Task1ObjectsManager>();

        maru = GameObject.Find("maru1");
        batu = GameObject.Find("batu1");
        cons = GameObject.Find("consoleB");

        maru.gameObject.SetActive(false);
        batu.gameObject.SetActive(false);
        cons.gameObject.SetActive(false);

        Qnum = 1;

        answerT1_M = 0;
        answerT1_B = 0;
        Bnum = null;

        f = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cmm.taskN == 1 && rotateN < 3)
        {
            Qchange();
            ButtonJudge();
            cons.gameObject.SetActive(true);
        }
        else if (rotateN >= 3)
        {
            StartCoroutine(End());
        }


        /*
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Answer1();
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            Answer2();
        }
        */
    }
    //QnumとrotateNに応じてオブジェクト・質問・正解を用意
    void Qchange()
    {
        switch (Qnum)
        {
            //問題ケース1
            case 1:
                if (rotateN == 0)
                {

                    obj.Q = 1;
                    board.qn = 1;
                    board.x = true;
                    R = true;
                    Ans = 4;
                    Anum = "Button3";
                }
                else if (rotateN == 1)
                {

                    obj.Q = 2;
                    board.qn = 2;
                    board.x = true;
                    R = true;
                    Ans = 6;
                    Anum = "Button3";
                }
                else if (rotateN == 2)
                {
                    obj.Q = 3;
                    board.qn = 4;
                    board.x = true;
                    R = true;
                    Ans = 2;
                    Anum = "Button1";
                }
                break;
            //問題ケース2
            case 2:
                if (rotateN == 0)
                {
                    obj.Q = 4;
                    board.qn = 1;
                    board.x = true;
                    R = true;
                    Ans = 3;
                    Anum = "Button2";
                }
                else if (rotateN == 1)
                {
                    obj.Q = 5;
                    board.qn = 2;
                    board.x = true;
                    R = true;
                    Ans = 4;
                    Anum = "Button2";
                }
                else if (rotateN == 2)
                {
                    obj.Q = 6;
                    board.qn = 5;
                    board.x = true;
                    R = true;
                    Ans = 2;
                    Anum = "Button1";
                }
                break;
            //問題ケース3
            case 3:
                if (rotateN == 0)
                {
                    obj.Q = 7;
                    board.qn = 1;
                    board.x = true;
                    R = true;
                    Ans = 2;
                    Anum = "Button1";
                }
                else if (rotateN == 1)
                {
                    obj.Q = 8;
                    board.qn = 3;
                    board.x = true;
                    R = true;
                    Ans = 5;
                    Anum = "Button2";
                }
                else if (rotateN == 2)
                {
                    obj.Q = 9;
                    board.qn = 6;
                    board.x = true;
                    R = true;
                    Ans = 6;
                    Anum = "Button3";
                }
                break;
        }
    }

    void ButtonJudge()
    {
        if (Bnum != null)
        {
            if (Bnum == Anum)
            {
                Answer1();
            }
            else
            {
                Answer2();
            }
        }
    }

    //回答に応じて〇×を表示
    void Answer1()
    {
        if (f == true)
        {
            maru.gameObject.SetActive(true);
            batu.gameObject.SetActive(false);
            StartCoroutine(AnsF());
            answerT1_M++;
            Debug.Log("正解数：" + answerT1_M);
            f = false;
        }
    }
    void Answer2()
    {
        if (f == true)
        {
            maru.gameObject.SetActive(false);
            batu.gameObject.SetActive(true);
            StartCoroutine(AnsF());
            answerT1_B++;
            Debug.Log("不正解数：" + answerT1_B);
            f = false;
        }
    }

    IEnumerator AnsF()
    {
        yield return new WaitForSeconds(2.0f);
        maru.gameObject.SetActive(false);
        batu.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2.0f);
        board.qn = 10;
    }
}
