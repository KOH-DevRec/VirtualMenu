using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCDirectionManager : MonoBehaviour
{
    List<GameObject> ItemList = new List<GameObject>();
    List<Image> ItemMaterialList = new List<Image>();
    List<GameObject> CircleList = new List<GameObject>();
    List<Image> CircleMaterialList = new List<Image>();

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public GameObject Circle1;
    public GameObject Circle2;
    public GameObject Circle3;
    public GameObject Circle4;

    public GameObject Dhand;
    private DirectionHand dh = new DirectionHand();

    public int answer;
    public List<string> chooseItem;    //選択項目格納配列

    private Color originC;
    private bool fix;                   //選択項目固定フラグ
    [SerializeField] float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        dh = Dhand.GetComponent<DirectionHand>();

        ItemList.Add(Item1.gameObject);
        ItemList.Add(Item2.gameObject);
        ItemList.Add(Item3.gameObject);
        ItemList.Add(Item4.gameObject);
        ItemMaterialList.Add(Item1.GetComponent<Image>());
        ItemMaterialList.Add(Item2.GetComponent<Image>());
        ItemMaterialList.Add(Item3.GetComponent<Image>());
        ItemMaterialList.Add(Item4.GetComponent<Image>());

        CircleList.Add(Circle1.gameObject);
        CircleList.Add(Circle2.gameObject);
        CircleList.Add(Circle3.gameObject);
        CircleList.Add(Circle4.gameObject);
        CircleMaterialList.Add(Circle1.GetComponent<Image>());
        CircleMaterialList.Add(Circle2.GetComponent<Image>());
        CircleMaterialList.Add(Circle3.GetComponent<Image>());
        CircleMaterialList.Add(Circle4.GetComponent<Image>());

        originC = ItemMaterialList[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        if (dh.chose == true)
        {
            CircleColorChange(dh.inum);
        }
        else if (dh.chose == false)
        {
            ColorChange(dh.inum);
        }
    }
    private void ColorChange(int Num)
    {

        switch (Num)
        {
            case 0:
                break;
            case 1:
                ColorClear();
                ItemMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                chooseItem.Add("1");
                break;
            case 2:
                ColorClear();
                ItemMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                chooseItem.Add("2");
                break;
            case 3:
                ColorClear();
                ItemMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                chooseItem.Add("3");
                break;
            case 4:
                ColorClear();
                ItemMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                break;
        }
    }

    private void CircleColorChange(int Num)
    {

        switch (Num)
        {
            case 0:
                break;
            case 1:
                CircleColorClear();
                CircleMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                answer = 1;
                chooseItem.Add("1");
                break;
            case 2:
                CircleColorClear();
                CircleMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                answer = 2;
                chooseItem.Add("2");
                break;
            case 3:
                CircleColorClear();
                CircleMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                answer = 3;
                chooseItem.Add("3");
                break;
            case 4:
                CircleColorClear();
                CircleMaterialList[Num - 1].color = new Color(originC.b, originC.g, originC.r, originC.a);
                answer = 4;
                chooseItem.Add("4");
                break;
        }
    }

    private void ColorClear()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            ItemMaterialList[i].color = originC;
        }

    }

    private void CircleColorClear()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            CircleMaterialList[i].color = originC;
        }

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
