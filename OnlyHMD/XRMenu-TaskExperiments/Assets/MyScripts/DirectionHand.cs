using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHand : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand HandType = OVRHand.Hand.HandLeft;
    [SerializeField]
    private OVRSkeleton skeleton;
    public RectTransform fanRect;
    private CanvasGroup thisCanvasG;
    private OVRHand hand = null;
    public int inum;
    public bool chose;
    private List<string> chooseItem;    //選択項目格納配列

    public Transform _camera = null;

    public GameObject Ca;
    private CameraMoveManager cmm = new CameraMoveManager();
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
        fanRect = GetComponent<RectTransform>();
        thisCanvasG = GetComponent<CanvasGroup>();
        chose = false;

        cmm = Ca.GetComponent<CameraMoveManager>();
    }

    private void Update()
    {
        DirectionCheck();
    }

    void DirectionCheck()
    {
        //必要なbone情報の取得
        var isIndexStraight = IsStraight(0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var ThumbTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
        var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
        var Middle2Pos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Middle2].Transform.position;
        var ArmPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ForearmStub].Transform.position;

        float angle = Vector3.Angle(ArmPos, indexTipPos);
        float tm_dis = Vector3.Distance(ThumbTipPos, Middle2Pos);

        if (isIndexStraight == true)
        {
            //Debug.Log("まっすぐ！");

            //ここでDirectionMenu起動
            thisCanvasG.alpha = 1;
            fanRect.LookAt(Camera.main.transform);
            //fanRect.position = ArmPos + new Vector3(0.12f, 0.1f, 0.4f);
            fanRect.transform.Rotate(0.0f, 180.0f, 0.0f);

            //平滑化・過剰移動に対応する必要あり


            ItemDirection(angle);
            //親指で選択したかどうか
            if (tm_dis < 0.03)
            {
                chooseItem.Add(inum.ToString());
                Debug.Log(string.Join(",", chooseItem));
                StartCoroutine(ChooseCount());
            }
            else if(tm_dis >= 0.03)
            {
                chose = false;
            }
        }
        else
        {
            //Debug.Log("しなしな…");
            thisCanvasG.alpha = 0;
        }
    }

    //ベクトル角度に応じた選択
    public int ItemDirection(float a)
    {
        if (cmm.taskN == 1)
        {
            switch (a)
            {
                //項目1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //項目2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //項目3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //項目4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        else if (cmm.taskN == 2)
        {
            switch (a)
            {
                //項目1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //項目2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //項目3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //項目4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        else
        {
            switch (a)
            {
                //項目1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //項目2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //項目3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //項目4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        return inum;
    }

    // 指定した全てのBoneIDが直線状にあるかどうか調べる
    private bool IsStraight(float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (boneids.Length < 3) return false;   //調べようがない
        Vector3? oldVec = null;
        var dot = 1.0f;
        for (var index = 0; index < boneids.Length - 1; index++)
        {
            var v = (skeleton.Bones[(int)boneids[index + 1]].Transform.position - skeleton.Bones[(int)boneids[index]].Transform.position).normalized;
            if (oldVec.HasValue)
            {
                dot *= Vector3.Dot(v, oldVec.Value); //内積の値を総乗していく
            }
            oldVec = v;//ひとつ前の指ベクトル
        }
        return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
    }

    //選択ディレイ
    IEnumerator ChooseCount()
    {
        chose = true;
        yield return new WaitForSeconds(0.5f);
        chose = false;
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
}
