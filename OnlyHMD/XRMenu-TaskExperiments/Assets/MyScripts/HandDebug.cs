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

            // �\���ʒu�����E�̎�ɂ���ĕς���
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
                hand.IsTracked,                 // �g���b�L���O�ł��Ă��邩
                hand.HandConfidence,            // ��̃|�[�Y�ɂ��Ă̐M����
                hand.IsPointerPoseValid,        // �|�C���^�[�|�[�Y�����Ă��邩
                hand.IsSystemGestureInProgress  // �V�X�e���W�F�X�`���[�����Ă��邩
            );
            */

            //PinchingCheck();
            //DirectionCheck();

            //�l�����w����

            
            var isIndexStraight = IsStraight(0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
            if (isIndexStraight == true)
            {
                //������DirectionMenu�N��

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("�܂������I");
                }

                var ThumbTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
                var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
                var Middle2Pos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Middle2].Transform.position;
                var ArmPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ForearmStub].Transform.position;
                float tm_dis = Vector3.Distance(ThumbTipPos, Middle2Pos);
                float angle = Vector3.Angle(ArmPos, indexTipPos);

                var a = "�H";
                switch (angle)
                {
                    //����1
                    case float f when (f < 1.5f):
                        a = "�@";
                        break;
                        
                    //����2
                    case float f when (f < 2.2f && f >=1.5f):
                        a = "�A"; 
                        break;

                    //����3
                    case float f when (f < 2.9f && f >= 2.2f):
                        a = "�B"; 
                        break;

                    //����4
                    case float f when (f >= 2.9f):
                        a = "�C"; 
                        break;
                }

                text.text = string.Format("Distance�F"+tm_dis+"\n"+"Angle�F"+angle + "\n" + "���ځF" + a + "\n" + "Arm�F" + ArmPos + "\n" + "�e�w�F" + ThumbTipPos + "\n" + "�l�����w�F" + indexTipPos + "\n" + "���w�F" + Middle2Pos);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("���Ȃ��ȁc");
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

    // �w�肵���S�Ă�BoneID��������ɂ��邩�ǂ������ׂ�
    private bool IsStraight(float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (boneids.Length < 3) return false;   //���ׂ悤���Ȃ�
        Vector3? oldVec = null;
        var dot = 1.0f;
        for (var index = 0; index < boneids.Length - 1; index++)
        {
            var v = (skeleton.Bones[(int)boneids[index + 1]].Transform.position - skeleton.Bones[(int)boneids[index]].Transform.position).normalized;
            if (oldVec.HasValue)
            {
                dot *= Vector3.Dot(v, oldVec.Value); //���ς̒l�𑍏悵�Ă���
            }
            oldVec = v;//�ЂƂO�̎w�x�N�g��
        }
        return dot >= threshold; //�w�肵��BoneID�̓��ς̑��悪臒l�𒴂��Ă����璼���Ƃ݂Ȃ�
    }

}
