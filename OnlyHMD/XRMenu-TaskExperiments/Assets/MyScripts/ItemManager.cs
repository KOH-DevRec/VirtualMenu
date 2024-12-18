using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    List<GameObject> childList = new List<GameObject>();
    List<Image> childImageList = new List<Image>();
    List<List<Text>> UITexts = new List<List<Text>>();
    public List<Text> originText = new List<Text>();
    public GameObject handGameObject;
    private DirectionHand dh = new DirectionHand();
    private Color originC;

    // Start is called before the first frame update
    void Start()
    {
        dh = handGameObject.GetComponent<DirectionHand>();

        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
            childImageList.Add(child.Find("Image").GetComponent<Image>());
            originText.Add(child.Find("Image/Text").GetComponent<Text>());
        }
        //UITexts.Add(originText);
        originC = childImageList[0].color;
        Debug.Log(originText);
    }

    // Update is called once per frame
    void Update()
    {

        switch (dh.inum)
        {
            case 1:
                ColorChange(0);
                break;
            case 2:
                ColorChange(1);
                break;
            case 3:
                ColorChange(2);
                break;
            case 4:
                ColorChange(3);
                break;
        }

    }

    private void ColorChange(int itemNum)
    {
        int i = 0;
        //色初期化
        foreach (Image image in childImageList)
        {
            childImageList[i].color = originC;
            i++;
        }
        //指定項目色変更
        childImageList[itemNum].color = new Color(originC.b, originC.g, originC.r, originC.a);
    }
}
