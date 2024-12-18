using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Timers;


public class PanelManager : MonoBehaviour
{
    public Text PanelText;
    public GameObject MCGameObject;

    private MCLineManager mcl = new MCLineManager();

    private int i = 1;
    private int rNumI;
    private int[] preExperimentNum1;
    private int[] preExperimentNum2;
    private int[] preExperimentNum3;
    private int[] preExperimentNum4;
    private int[] preExperimentNum5;
    private int[] preExperimentNum6;
    private int[] preExperimentNum7;
    private int[] preExperimentNum8;

    public int[] answer;
    public List<string> ChooseItem;
    public List<string> AnswerItem;

    private System.Random rNum = new System.Random();


    private bool fix;                   //選択項目固定フラグ

    private int t = 0;
    private bool time;                  //計測中
    private Timer timer;

    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();    //計測時間測定
    private long reactT;
    public List<long> reactAll;

    public string HUDname;
    // Start is called before the first frame update
    void Start()
    {
        mcl = MCGameObject.GetComponent<MCLineManager>();

        HUDname = MCGameObject.gameObject.name;

        AnswerItem = new List<string>();
        ChooseItem = new List<string>();
        fix = false;    //項目非固定状態

        preExperimentNum1 = new int[80] { 1, 4, 3, 2, 3, 4, 1, 2, 1, 3, 4, 2, 3, 1, 4, 2, 3, 1, 2, 4, 1, 2, 3, 4, 1, 3, 2, 4, 2, 1, 3, 4, 3, 2, 4, 1, 2, 4, 3, 1, 2, 1, 4, 3, 2, 4, 1, 3, 2, 4, 1, 3, 4, 2, 1, 3, 4, 2, 1, 3, 4, 3, 1, 2, 3, 4, 2, 1, 2, 4, 3, 1, 2, 3, 1, 4, 2, 3, 4, 1 };
        preExperimentNum2 = new int[80] { 2, 1, 3, 4, 3, 1, 4, 2, 3, 1, 2, 4, 1, 2, 4, 3, 1, 4, 3, 2, 3, 4, 1, 2, 4, 1, 3, 2, 4, 1, 3, 2, 1, 3, 2, 4, 1, 3, 2, 4, 1, 4, 3, 2, 4, 1, 3, 2, 4, 2, 3, 1, 2, 4, 1, 3, 4, 2, 1, 3, 4, 1, 2, 3, 4, 1, 3, 2, 4, 1, 4, 3, 2, 3, 4, 1, 2, 1, 3, 4 };
        preExperimentNum3 = new int[80] { 2, 3, 4, 1, 2, 3, 1, 4, 2, 4, 1, 3, 4, 3, 2, 1, 4, 1, 2, 3, 1, 4, 3, 2, 4, 1, 2, 3, 1, 3, 4, 2, 1, 3, 2, 4, 1, 4, 3, 2, 4, 3, 1, 2, 4, 3, 2, 1, 3, 2, 4, 1, 2, 1, 4, 3, 2, 3, 4, 1, 4, 1, 3, 2, 3, 1, 2, 4, 3, 4, 2, 1, 3, 2, 4, 1, 2, 3, 4, 1 };
        preExperimentNum4 = new int[80] { 4, 3, 1, 2, 3, 4, 2, 1, 2, 4, 3, 1, 2, 3, 1, 4, 2, 3, 4, 1, 4, 1, 3, 2, 3, 4, 1, 2, 1, 3, 4, 2, 3, 1, 4, 2, 3, 1, 2, 4, 1, 2, 3, 4, 1, 3, 2, 4, 2, 1, 3, 4, 3, 2, 4, 1, 2, 4, 3, 1, 2, 1, 4, 3, 2, 4, 1, 3, 2, 4, 1, 3, 4, 2, 1, 3, 4, 2, 1, 3 };
        preExperimentNum5 = new int[80] { 3, 1, 2, 4, 1, 3, 4, 2, 1, 3, 4, 1, 2, 3, 4, 1, 3, 2, 4, 1, 4, 3, 2, 1, 4, 1, 3, 2, 4, 1, 3, 2, 1, 3, 2, 4, 1, 3, 2, 4, 1, 4, 3, 2, 4, 1, 3, 2, 4, 2, 3, 1, 2, 4, 1, 3, 4, 2, 1, 3, 4, 1, 2, 3, 4, 1, 3, 2, 4, 1, 4, 3, 2, 3, 4, 1, 2, 1, 3, 4 };
        preExperimentNum6 = new int[80] { 1, 3, 2, 4, 1, 4, 3, 2, 4, 3, 1, 2, 4, 3, 2, 1, 3, 2, 4, 1, 2, 1, 4, 3, 2, 3, 4, 1, 4, 1, 3, 2, 3, 1, 2, 4, 3, 4, 2, 1, 3, 2, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 1, 4, 2, 4, 1, 3, 4, 3, 2, 1, 4, 1, 2, 3, 1, 4, 3, 2, 4, 1, 2, 3, 1, 3, 4, 2 };
        preExperimentNum7 = new int[80] { 1, 4, 3, 2, 3, 4, 1, 2, 3, 1, 2, 4, 1, 2, 4, 3, 1, 4, 3, 2, 3, 4, 1, 2, 4, 1, 3, 3, 1, 3, 4, 2, 1, 3, 2, 4, 1, 4, 3, 2, 4, 3, 1, 2, 4, 3, 2, 1, 3, 4, 1, 3, 4, 2, 1, 3, 4, 2, 1, 3, 4, 3, 1, 2, 3, 4, 2, 1, 2, 4, 1, 3, 4, 2, 1, 3, 4, 2, 1, 3 };
        preExperimentNum8 = new int[80] { 3, 2, 4, 1, 2, 3, 1, 4, 2, 4, 1, 3, 4, 3, 2, 1, 2, 3, 4, 1, 4, 1, 3, 2, 3, 4, 1, 2, 1, 3, 4, 2, 3, 1, 4, 2, 3, 1, 2, 2, 4, 3, 1, 2, 4, 3, 2, 1, 3, 2, 4, 1, 2, 1, 4, 1, 2, 4, 3, 1, 2, 1, 4, 3, 2, 4, 1, 3, 2, 4, 1, 3, 4, 2, 1, 3, 4, 2, 1, 3 };
        answer = new int[80];
        rNumI = rNum.Next(1, 9);

        timer = new Timer(200);
        timer.Elapsed += (sender, e) =>
        {
            if (t < 1)
            {
                t++;
            }
            else
            {
                time = false;
                timer.Stop();
                t = 0;
            }
        };

        //StartCoroutine(Count());
        Debug.Log("rNUM="+rNumI);

    }

    // Update is called once per frame
    void Update()
    {

        if (i > 79)
        {
            i = 1;
            //WriteFile();
        }
        else
        {

            TextChange(mcl.GetAnswer());
        }
    }

    private void TextChange(int pinchNum)
    {

        switch (pinchNum)
        {
            case 0:
                break;
            case 1:    
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                //Debug.Log("!!!");
                mcl.answer = 0;
                break;
            case 2:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                //Debug.Log("!!!");
                mcl.answer = 0;
                break;
            case 3:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                //Debug.Log("!!!");
                mcl.answer = 0;
                break;
            case 4:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                //Debug.Log("!!!");
                mcl.answer = 0;
                break;
        }
    }

    private void TextSwitch(int num)
    {
        switch (num)
        {
            case 1:
                PanelText.text = "A";
                AnswerItem.Add("1");
                break;
            case 2:
                PanelText.text = "B";
                AnswerItem.Add("2");
                break;
            case 3:
                PanelText.text = "C";
                AnswerItem.Add("3");
                break;
            case 4:
                PanelText.text = "D";
                AnswerItem.Add("4");
                break;
        }
    }

    private void preExperimentNumSwitch(int num)
    {
        reactT = sw.ElapsedMilliseconds;
        reactAll.Add(reactT);
        sw.Restart();

        switch (num)
        {
            case 1:
                answer[i] = preExperimentNum1[i];
                TextSwitch(preExperimentNum1[i]);
                break;
            case 2:
                answer[i] = preExperimentNum2[i];
                TextSwitch(preExperimentNum2[i]);
                break;
            case 3:
                answer[i] = preExperimentNum3[i];
                TextSwitch(preExperimentNum3[i]);
                break;
            case 4:
                answer[i] = preExperimentNum4[i];
                TextSwitch(preExperimentNum4[i]);
                break;
            case 5:
                answer[i] = preExperimentNum5[i];
                TextSwitch(preExperimentNum5[i]);
                break;
            case 6:
                answer[i] = preExperimentNum6[i];
                TextSwitch(preExperimentNum6[i]);
                break;
            case 7:
                answer[i] = preExperimentNum7[i];
                TextSwitch(preExperimentNum7[i]);
                break;
            case 8:
                answer[i] = preExperimentNum8[i];
                TextSwitch(preExperimentNum8[i]);
                break;
        }

        ChooseItem = mcl.chooseItem;
    }

    IEnumerator ChooseTimer()
    {
        fix = true;
        yield return new WaitForSeconds(0.1f);
        fix = false;
        i++;
        Debug.Log(string.Join(",", AnswerItem));
        Debug.Log("選択ディレイ");
    }

}
