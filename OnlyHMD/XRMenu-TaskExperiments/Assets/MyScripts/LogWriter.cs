using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LogWriter : MonoBehaviour
{
    public GameObject Pm;
    //public GameObject Mhand;
    //public GameObject Dhand;
    //public GameObject MCLm;
    //public GameObject MCDm;
    public GameObject T1top;
    public GameObject T2top;

    private PanelManager pm         = new PanelManager();
    //private MenuHand mh             = new MenuHand();
    //private DirectionHand dh        = new DirectionHand();
    //private MCLineManager mclm      = new MCLineManager();
    //private MCDirectionManager mcdm = new MCDirectionManager();
    private Task1Top t1t            = new Task1Top();
    private Task2Top t2t            = new Task2Top();

    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();    //�v�����ԑ���
    private TimeSpan t11;
    private TimeSpan t12;
    private TimeSpan t13;
    private TimeSpan t21;

    private long l_t11;
    private long l_t12;
    private long l_t13;
    private long l_t21;

    private int t1c;

    private int Mcorrect;
    private int Mincorrect;

    private long reactAve = 0;
    private long reactT1Ave = 0;
    private long reactT2Ave = 0;
    // Start is called before the first frame update
    void Start()
    {
        pm = Pm.GetComponent<PanelManager>();
        //mh = Mhand.GetComponent<MenuHand>();
        //dh = Dhand.GetComponent<DirectionHand>();
        //mclm = MCLm.GetComponent<MCLineManager>();
        //mcdm = MCDm.GetComponent<MCDirectionManager>();
        t1t = T1top.GetComponent<Task1Top>();
        t2t = T2top.GetComponent<Task2Top>();

        t1c = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            sw.Restart();
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            switch (t1t.rotateN)
            {
                case 1:
                    t11 = sw.Elapsed;
                    l_t11 = sw.ElapsedMilliseconds;
                    Debug.Log(($"{t11.Minutes}�� {t11.Seconds}�b {t11.Milliseconds}�~���b"));
                    break;
                case 2:
                    t12 = sw.Elapsed;
                    l_t12 = sw.ElapsedMilliseconds;
                    Debug.Log(($" {t12.Minutes}�� {t12.Seconds}�b {t12.Milliseconds}�~���b"));
                    break;
                case 3:
                    t13 = sw.Elapsed;
                    l_t13 = sw.ElapsedMilliseconds;
                    Debug.Log(($"{t13.Minutes}�� {t13.Seconds}�b {t13.Milliseconds}�~���b"));

                    WriteFileT1();
                    break;
                default:
                    break;
            }
            sw.Restart();
        }

        if (t2t.Write==true)
        {
            WriteFileT2();
        }
    }

    private void WriteFileT1()
    {
        ItemCheck();
        ReactCheck();
        Task1ReactCheck();
        string dt = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        //�t�@�C����������
        StreamWriter writer = new StreamWriter(@"C:\Users\KH\Desktop\�{����\T1\" + dt + ".txt", false);
        //StreamWriter writer = new StreamWriter(@"C:\Users\KOH.desk\Desktop\" + "[T1]" + dt + ".txt", false);


        writer.WriteLine("�񓚁F" + string.Join(",", pm.ChooseItem));
        writer.WriteLine("���{�F" + string.Join(",", pm.AnswerItem));
        writer.WriteLine("Menu-�����F" + Mcorrect);
        writer.WriteLine("Menu-�s�����F" + Mincorrect);
        writer.WriteLine("Menu-�������ԁF" + string.Join(",", pm.reactAll));
        writer.WriteLine("Menu-�������ώ��ԁF" + reactAve);

        writer.WriteLine("T1-1Time�F" + l_t11);
        writer.WriteLine("T1-2Time�F" + l_t12);
        writer.WriteLine("T1-3Time�F" + l_t13);
        writer.WriteLine("T1-AveTime�F" + reactT1Ave);

        writer.WriteLine("T1-�����F" + t1t.answerT1_M);
        writer.WriteLine("T1-�s�����F" + t1t.answerT1_B);

        writer.WriteLine("HUD�F" + pm.HUDname);


        //writer.WriteLine($"�@{sw.ElapsedMilliseconds}");
        //writer.WriteLine($"�@{ts.Hours}���� {ts.Minutes}�� {ts.Seconds}�b {ts.Milliseconds}�~���b");

        writer.Close();
        Debug.Log("T1�������݊���");
    }

    private void WriteFileT2()
    {
        ItemCheck();
        ReactCheck();
        Task2ReactCheck();
        string dt = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        //�t�@�C����������
        StreamWriter writer = new StreamWriter(@"C:\Users\KH\Desktop\�{����\T2\"  + dt + ".txt", false);
        //StreamWriter writer = new StreamWriter(@"C:\Users\KOH.desk\Desktop\" + "[T2]" + dt + ".txt", false);


        writer.WriteLine("�񓚁F" + string.Join(",", pm.ChooseItem));
        writer.WriteLine("���{�F" + string.Join(",", pm.AnswerItem));
        writer.WriteLine("Menu-�����F" + Mcorrect);
        writer.WriteLine("Menu-�s�����F" + Mincorrect);
        writer.WriteLine("Menu-�������ԁF" + string.Join(",", pm.reactAll));
        writer.WriteLine("Menu-�������ώ��ԁF" + reactAve);

        writer.WriteLine("�������ԁF" + string.Join(",", t2t.reactAll));
        writer.WriteLine("�������ώ��ԁF" + reactT2Ave);

        writer.WriteLine("T2-�����F" + t2t.answerT2_M);
        writer.WriteLine("T2-�s�����F" + t2t.answerT2_B);

        writer.WriteLine("HUD�F" + pm.HUDname);

        //writer.WriteLine($"�@{sw.ElapsedMilliseconds}");
        //writer.WriteLine($"�@{ts.Hours}���� {ts.Minutes}�� {ts.Seconds}�b {ts.Milliseconds}�~���b");

        writer.Close();
        Debug.Log("T2�������݊���");

        t2t.Write = false;
    }

    private void ItemCheck()
    {

        int x = pm.AnswerItem.Count;
        Mcorrect = 0;
        Mincorrect = 0;
        for(int i = 1; i < x; i++)
        {
            if (pm.AnswerItem[i-1] == pm.ChooseItem[i])
            {
                Mcorrect++;
            }
            else
            {
                Mincorrect++;
            }
        }
        Debug.Log("�����F" + Mcorrect + ", �s�����F" + Mincorrect);
    }

    private void ReactCheck()
    {
        int x = pm.reactAll.Count;
        for (int i = 1; i < x; i++)
        {
            reactAve += pm.reactAll[i];
        }

        x -= 1;
        reactAve = reactAve / x;
    }

    private void Task1ReactCheck()
    {
        reactT1Ave = l_t11 + l_t12 + l_t13;
        reactT1Ave = reactT1Ave / 3;
    }

    private void Task2ReactCheck()
    {
        int x = t2t.reactAll.Count;
        for (int i = 0; i < x; i++)
        {
            reactT2Ave += t2t.reactAll[i];
        }
        reactT2Ave = reactT2Ave / x;
    }
}
