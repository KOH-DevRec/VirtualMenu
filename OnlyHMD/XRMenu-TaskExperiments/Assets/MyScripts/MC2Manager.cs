using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class MC2Manager : MonoBehaviour
{
    List<GameObject> childList = new List<GameObject>();
    List<Renderer> childMaterialList = new List<Renderer>();
    public Material Material1;
    public Material Material2;
    public GameObject HandGM;
    private HandDebug HD = new HandDebug();
    private bool fix;                   //選択項目固定フラグ

    private int i = 0;
    private int rNumI;
    private int[] preExperimentNum1;
    private int[] preExperimentNum2;
    private int[] preExperimentNum3;
    private System.Random rNum = new System.Random();

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip start;
    public AudioClip end;
    AudioSource audioSource;

    public Text PanelText;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();    //計測時間測定

    // Start is called before the first frame update
    void Start()
    {
        fix = false;    //項目非固定状態

        HD = HandGM.GetComponent<HandDebug>();
        audioSource = GetComponent<AudioSource>();
        PanelText = GetComponent<Text>();
        rNumI = rNum.Next(1, 4);

        preExperimentNum1 = new int[30] { 1, 3, 2, 4, 3, 4, 2, 1, 2, 3, 1, 3, 2, 4, 3, 4, 2, 1, 2, 3, 1, 3, 2, 4, 3, 4, 2, 1, 2, 3 };
        preExperimentNum2 = new int[30] { 1, 4, 2, 3, 4, 3, 1, 2, 4, 3, 1, 4, 2, 3, 4, 3, 1, 2, 4, 3, 1, 4, 2, 3, 4, 3, 1, 2, 4, 3 };
        preExperimentNum3 = new int[30] { 3, 2, 4, 1, 3, 4, 2, 3, 1, 4, 3, 2, 4, 1, 3, 4, 2, 3, 1, 4, 3, 2, 4, 1, 3, 4, 2, 3, 1, 4 };

        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
            childMaterialList.Add(child.GetComponent<Renderer>());
        }
        ColorClear();
    }  

    // Update is called once per frame
    void Update()
    {
        if(fix == false)
        {
            ColorChange(HD.pinchingNum);
        }else if(fix == true)
        {

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Count());
        }
    }

    private void ColorChange(int pinchNum)
    {

        switch (pinchNum)
        {
            case 0:
                break;
            case 1:
                ColorClear();
                childMaterialList[pinchNum - 1].material = Material2;
                audioSource.PlayOneShot(sound1);
                StartCoroutine(ChooseTimer());
                break;
            case 2:
                ColorClear();
                childMaterialList[pinchNum - 1].material = Material2;
                audioSource.PlayOneShot(sound2);
                StartCoroutine(ChooseTimer());
                break;
            case 3:
                ColorClear();
                childMaterialList[pinchNum - 1].material = Material2;
                audioSource.PlayOneShot(sound3);
                StartCoroutine(ChooseTimer());
                break;
            case 4:
                ColorClear();
                childMaterialList[pinchNum - 1].material = Material2;
                audioSource.PlayOneShot(sound4);
                StartCoroutine(ChooseTimer());
                break;
        }
    }

    private void ColorClear()
    {
        for(int i=0; i<childList.Count-1; i++)
        {
            childMaterialList[i].material = Material1;
        }
        Debug.Log("clear!");
    }

    private void TextSwitch(int num)
    {
        switch (num)
        {
            case 1:
                PanelText.text = "1";
                break;
            case 2:
                PanelText.text = "2";
                break;
            case 3:
                PanelText.text = "3";
                break;
            case 4:
                PanelText.text = "4";
                break;
        }
    }

    private void preExperimentNumSwitch(int num)
    {
        switch (num)
        {
            case 1:
                TextSwitch(preExperimentNum1[i]);
                break;
            case 2:
                TextSwitch(preExperimentNum2[i]);
                break;
            case 3:
                TextSwitch(preExperimentNum3[i]);
                break;
        }
    }

    IEnumerator ChooseTimer()
    {
        fix = true;
        yield return new WaitForSeconds(1.0f);
        fix = false;
        Debug.Log("選択ディレイ");
    }

    IEnumerator Count()
    {
        Debug.Log("3秒間待ってやる");
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
        preExperimentNumSwitch(rNumI);

    }

    private void WriteFile()
    {
        sw.Stop();
        TimeSpan ts = sw.Elapsed;

        PanelText.text = "End";
        string dt = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        //ファイル書き込み
        StreamWriter writer = new StreamWriter(@"C:\Users\KH\Desktop\本実験\Visual\" + dt + ".txt", false);
        writer.WriteLine($"　{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
        writer.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");
        writer.Close();
        Debug.Log("書き込み完了");
    }
}
