using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Timers;

public class MCSimpleManager : MonoBehaviour
{
    public Text PanelItemText;

    List<GameObject> childList = new List<GameObject>();
    List<Renderer> childMaterialList = new List<Renderer>();
    public Material Material1;
    public Material Material2;
    public GameObject HandGM;
    private HandDebug HD = new HandDebug();
    private bool fix;                   //選択項目固定フラグ

    [SerializeField] float delay = 0.5f;

    private int i = 0;
    private int rNumI;
    public int answer;
    private List<string> chooseItem;    //選択項目格納配列
    private System.Random rNum = new System.Random();

    /*
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip start;
    public AudioClip end;
    AudioSource audioSource;
    */

    // Start is called before the first frame update
    void Start()
    {
        fix = false;    //項目非固定状態
        HD = HandGM.GetComponent<HandDebug>();
        chooseItem = new List<string>();
        answer = 0;
        //audioSource = GetComponent<AudioSource>();

        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
            childMaterialList.Add(child.GetComponent<Renderer>());
        }
        //ColorClear();
    }

    // Update is called once per frame
    void Update()
    {
        if (fix == false)
        {
            TextChange(HD.pinchingNum);
        }
        else if (fix == true)
        {

        }
    }

    private void TextChange(int pinchNum)
    {

        switch (pinchNum)
        {
            case 0:
                break;
            case 1:
                PanelItemText.text = "1";
                answer = 1;
                chooseItem.Add("1");
                //audioSource.PlayOneShot(sound1);
                StartCoroutine(ChooseTimer());
                break;
            case 2:
                PanelItemText.text = "2";
                answer = 2;
                chooseItem.Add("2");
                //audioSource.PlayOneShot(sound2);
                StartCoroutine(ChooseTimer());
                break;
            case 3:
                PanelItemText.text = "3";
                answer = 3;
                chooseItem.Add("3");
                //audioSource.PlayOneShot(sound3);
                StartCoroutine(ChooseTimer());
                break;
            case 4:
                PanelItemText.text = "4";
                answer = 4;
                chooseItem.Add("4");
                //audioSource.PlayOneShot(sound4);
                StartCoroutine(ChooseTimer());
                break;
        }
    }

    private void ColorClear()
    {
        for (int i = 0; i < childList.Count - 1; i++)
        {
            childMaterialList[i].material = Material1;
        }
        Debug.Log("clear!");
    }

    IEnumerator ChooseTimer()
    {
        fix = true;
        yield return new WaitForSeconds(delay);
        fix = false;
        i++;
        Debug.Log(string.Join(",", chooseItem));
        Debug.Log("選択ディレイ");
        answer = 0;
    }
    public string GetChooseItem()
    {
        if (chooseItem == null)
        {
            return "Nothing";
        }
        else
        {
            return string.Join(",", chooseItem);
        }
    }

    public int GetAnswer()
    {
        return answer;
    }
}
