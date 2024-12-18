using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Timers;

public class PanelSimpleManager : MonoBehaviour
{
    public Text PanelText;
    public GameObject HandGM;
    public GameObject MCSGameObject;

    private HandDebug HD = new HandDebug();
    private MCSimpleManager mcs = new MCSimpleManager();

    private int i = 0;
    private int rNumI;
    private int[] preExperimentNum1;
    private int[] preExperimentNum2;
    private int[] preExperimentNum3;
    private int[] answer;
    private List<string> AnswerItem;
    private System.Random rNum = new System.Random();


    private bool fix;                   //選択項目固定フラグ

    private int t = 0;
    private bool time;                  //計測中
    private Timer timer;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();    //計測時間測定
    // Start is called before the first frame update
    void Start()
    {
        mcs = MCSGameObject.GetComponent<MCSimpleManager>();
        AnswerItem = new List<string>();
        fix = false;    //項目非固定状態

        preExperimentNum1 = new int[30] { 1, 3, 2, 4, 3, 4, 2, 1, 2, 3, 1, 3, 2, 4, 3, 4, 2, 1, 2, 3, 1, 3, 2, 4, 3, 4, 2, 1, 2, 3 };
        preExperimentNum2 = new int[30] { 1, 4, 2, 3, 4, 3, 1, 2, 4, 3, 1, 4, 2, 3, 4, 3, 1, 2, 4, 3, 1, 4, 2, 3, 4, 3, 1, 2, 4, 3 };
        preExperimentNum3 = new int[30] { 3, 2, 4, 1, 3, 4, 2, 3, 1, 4, 3, 2, 4, 1, 3, 4, 2, 3, 1, 4, 3, 2, 4, 1, 3, 4, 2, 3, 1, 4 };
        answer = new int[30];
        rNumI = rNum.Next(1, 4);

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
        Debug.Log("rNUM=" + rNumI);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Count());
        }
        

        if (i > 29)
        {
            PanelText.text = "終了";
            WriteFile();
        }else if (i > 30)
        {

        }

        else
        {

            TextChange(mcs.GetAnswer());
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
                Debug.Log("!!!");
                mcs.answer = 0;
                break;
            case 2:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                Debug.Log("!!!");
                mcs.answer = 0;
                break;
            case 3:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                Debug.Log("!!!");
                mcs.answer = 0;
                break;
            case 4:
                preExperimentNumSwitch(rNumI);
                StartCoroutine(ChooseTimer());
                Debug.Log("!!!");
                mcs.answer = 0;
                break;
        }
    }

    private void TextSwitch(int num)
    {
        switch (num)
        {
            case 1:
                PanelText.text = "1";
                AnswerItem.Add("1");
                break;
            case 2:
                PanelText.text = "2";
                AnswerItem.Add("2");
                break;
            case 3:
                PanelText.text = "3";
                AnswerItem.Add("3");
                break;
            case 4:
                PanelText.text = "4";
                AnswerItem.Add("4");
                break;
        }
    }

    private void preExperimentNumSwitch(int num)
    {
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
        }
    }

    IEnumerator Count()
    {
        Debug.Log("5秒間待ってやる");
        Debug.Log("5");
        PanelText.text = "5";

        yield return new WaitForSeconds(1f);
        Debug.Log("4");
        PanelText.text = "4";

        yield return new WaitForSeconds(1f);
        Debug.Log("3");
        PanelText.text = "3";

        yield return new WaitForSeconds(1f);
        Debug.Log("2");
        PanelText.text = "2";

        yield return new WaitForSeconds(1f);
        Debug.Log("1");
        PanelText.text = "1";

        yield return new WaitForSeconds(1f);
        Debug.Log("時間だ。答えを聞こう。");
        PanelText.text = "Start";

        yield return new WaitForSeconds(1f);
        TextSwitch(preExperimentNum1[i]);
        sw.Start();
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

    private void WriteFile()
    {
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        PanelText.text = "End";

        string dt = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        //ファイル書き込み
        StreamWriter writer = new StreamWriter(@"C:\Users\KH\Desktop\本実験\UI\pre\simple\" + dt + ".txt", false);
        //StreamWriter writer = new StreamWriter(@"C:\Users\KOH.desk\Desktop\" + dt + ".txt", false);

        writer.WriteLine("回答：" + mcs.GetChooseItem());
        writer.WriteLine("見本：" + string.Join(",", AnswerItem));
        writer.WriteLine($"　{sw.ElapsedMilliseconds}");
        writer.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
        /*
        writer.WriteLine("接触：" + obm.GetCollisionObjects());
        writer.WriteLine("ターゲット：" + ColorText.text);
        writer.WriteLine("全オブジェクト数：" + obm.GetEn());
        writer.WriteLine("色別オブジェクト数：" + obm.Getthrow());
        writer.WriteLine("オブジェクト順：" + obm.GetthrowOrder());
        */
        writer.Close();
        Debug.Log("書き込み完了");
    }
}

