using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDebug : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand HandType = OVRHand.Hand.HandLeft;

    [SerializeField]
    private OVRSkeleton skeleton;

    private TextMesh text = null;
    private OVRHand hand = null;

    public bool pinchingT;
    public bool pinchingI;
    public bool pinchingM;
    public bool pinchingR;
    public bool pinchingP;
    public int pinchingNum = 0;

    [SerializeField] float _rayDistance = 100;
    [SerializeField] float _speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((text == null) && (hand != null))
        {
            text = new GameObject("HandDebug").AddComponent<TextMesh>();
            text.fontSize = 120;
            text.characterSize = 0.001f;
            text.transform.parent = transform;
            text.alignment = TextAlignment.Left;
            text.anchor = TextAnchor.UpperLeft;

            // 表示位置を左右の手によって変える
            if (HandType == OVRHand.Hand.HandLeft)
            {
                text.transform.localPosition = new Vector3(0.03f, -0.15f, 0.0f);
                text.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            }
            else if (HandType == OVRHand.Hand.HandRight)
            {
                text.transform.localPosition = new Vector3(-0.08f, 0.15f, 0.0f);
                text.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            }
        }
        else
        {
            /*
            text.text = string.Format(
                "Thumb:{0}:{5:f2}\n" +
                "Index:{1}:{6:f2}\n" +
                "Middle:{2}:{7:f2}\n" +
                "Ring:{3}:{8:f2}\n" +
                "Pinky:{4}:{9:f2}\n" +
                "IsTracked:{10}\n" +
                "HandConfidence:{11}\n" +
                "IsPointerPoseValid:{12}\n" +
                "IsSystemGestureInProgress:{13}",
                hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) ? "Pinching" : "-",
                hand.GetFingerIsPinching(OVRHand.HandFinger.Index) ? "Pinching" : "-",
                hand.GetFingerIsPinching(OVRHand.HandFinger.Middle) ? "Pinching" : "-",
                hand.GetFingerIsPinching(OVRHand.HandFinger.Ring) ? "Pinching" : "-",
                hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky) ? "Pinching" : "-",
                hand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb),
                hand.GetFingerPinchStrength(OVRHand.HandFinger.Index),
                hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle),
                hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring),
                hand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky),
                hand.IsTracked,                 // トラッキングできているか
                hand.HandConfidence,            // 手のポーズについての信頼性
                hand.IsPointerPoseValid,        // ポインターポーズをしているか
                hand.IsSystemGestureInProgress  // システムジェスチャーをしているか
            );
            */

            //PinchingCheck();
            //DirectionCheck();

            //人差し指判定

            
            var isIndexStraight = IsStraight(0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
            if (isIndexStraight == true)
            {
                //ここでDirectionMenu起動

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("まっすぐ！");
                }

                var ThumbTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
                var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
                var Middle2Pos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Middle2].Transform.position;
                var ArmPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ForearmStub].Transform.position;
                float tm_dis = Vector3.Distance(ThumbTipPos, Middle2Pos);
                float angle = Vector3.Angle(ArmPos, indexTipPos);

                var a = "？";
                switch (angle)
                {
                    //項目1
                    case float f when (f < 1.5f):
                        a = "①";
                        break;
                        
                    //項目2
                    case float f when (f < 2.2f && f >=1.5f):
                        a = "②"; 
                        break;

                    //項目3
                    case float f when (f < 2.9f && f >= 2.2f):
                        a = "③"; 
                        break;

                    //項目4
                    case float f when (f >= 2.9f):
                        a = "④"; 
                        break;
                }

                text.text = string.Format("Distance："+tm_dis+"\n"+"Angle："+angle + "\n" + "項目：" + a + "\n" + "Arm：" + ArmPos + "\n" + "親指：" + ThumbTipPos + "\n" + "人差し指：" + indexTipPos + "\n" + "中指：" + Middle2Pos);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("しなしな…");
                }
                
            }

            


        }
    }

    void PinchingCheck()
    {
        pinchingT = hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb);
        pinchingI = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        pinchingM = hand.GetFingerIsPinching(OVRHand.HandFinger.Middle);
        pinchingR = hand.GetFingerIsPinching(OVRHand.HandFinger.Ring);
        pinchingP = hand.GetFingerIsPinching(OVRHand.HandFinger.Pinky);

        if(pinchingI == true)
        {
            Debug.Log("IndexPinching");
            pinchingNum = 1;
        }
        else if(pinchingM == true)
        {
            Debug.Log("MiddlePinching");
            pinchingNum = 2;
        }else if(pinchingR == true)
        {
            Debug.Log("RingPinching");
            pinchingNum = 3;
        }else if(pinchingP == true)
        {
            Debug.Log("PinkyPinching");
            pinchingNum = 4;
        }
        else
        {
            pinchingNum = 0;
        }
    }

    void DirectionCheck()
    {

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

}
