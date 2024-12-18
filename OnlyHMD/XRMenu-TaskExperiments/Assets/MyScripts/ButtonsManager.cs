using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    private GameObject B1;
    private GameObject B2;
    private GameObject B3;
    private GameObject B4;

    private GameObject maru2;
    private GameObject batu2;

    public string Bnum;
    // Start is called before the first frame update
    void Start()
    {
        B1 = GameObject.Find("Button1");
        B2 = GameObject.Find("Button2");
        B3 = GameObject.Find("Button3");
        B4 = GameObject.Find("Button4");

        maru2 = GameObject.Find("maru2");
        batu2 = GameObject.Find("batu2");

        maru2.gameObject.SetActive(false);
        batu2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonJudge()
    {
        switch (Bnum)
        {
            case "Button1":

                break;

            default:
                break;
        }
    }

    IEnumerator AnsF()
    {
        yield return new WaitForSeconds(2.0f);
        maru2.gameObject.SetActive(false);
        batu2.gameObject.SetActive(false);

        yield return null;
    }
}
