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
    private List<string> chooseItem;    //�I�����ڊi�[�z��

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
        //�K�v��bone���̎擾
        var isIndexStraight = IsStraight(0.8f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var ThumbTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
        var indexTipPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
        var Middle2Pos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Middle2].Transform.position;
        var ArmPos = skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ForearmStub].Transform.position;

        float angle = Vector3.Angle(ArmPos, indexTipPos);
        float tm_dis = Vector3.Distance(ThumbTipPos, Middle2Pos);

        if (isIndexStraight == true)
        {
            //Debug.Log("�܂������I");

            //������DirectionMenu�N��
            thisCanvasG.alpha = 1;
            fanRect.LookAt(Camera.main.transform);
            //fanRect.position = ArmPos + new Vector3(0.12f, 0.1f, 0.4f);
            fanRect.transform.Rotate(0.0f, 180.0f, 0.0f);

            //�������E�ߏ�ړ��ɑΉ�����K�v����


            ItemDirection(angle);
            //�e�w�őI���������ǂ���
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
            //Debug.Log("���Ȃ��ȁc");
            thisCanvasG.alpha = 0;
        }
    }

    //�x�N�g���p�x�ɉ������I��
    public int ItemDirection(float a)
    {
        if (cmm.taskN == 1)
        {
            switch (a)
            {
                //����1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //����2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //����3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //����4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        else if (cmm.taskN == 2)
        {
            switch (a)
            {
                //����1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //����2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //����3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //����4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        else
        {
            switch (a)
            {
                //����1
                case float f when (f < 1.5f):
                    inum = 1;
                    break;

                //����2
                case float f when (f < 2.2f && f >= 1.5f):
                    inum = 2;
                    break;

                //����3
                case float f when (f < 2.9f && f >= 2.2f):
                    inum = 3;
                    break;

                //����4
                case float f when (f >= 2.9f):
                    inum = 4;
                    break;
            }

        }
        return inum;
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

    //�I���f�B���C
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
