using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanDeployer : MonoBehaviour
{
    //���a
    [SerializeField]
    public float _radius;

    //�q�f�[�^�擾�p
    List<GameObject> childList = new List<GameObject>();
    //private GameObject CircleCenter;

    //=================================================================================
    //������
    //=================================================================================

    private void Awake()
    {
        Deploy();
    }

    //Inspector�̓��e(���a)���ύX���ꂽ���Ɏ��s
    private void OnValidate()
    {
        //CircleCenter = this.gameObject.GetComponent<GameObject>();
        Deploy();
    }

    //�q���~��ɔz�u����(ContextMenu�Ō��}�[�N�̏��Ƀ��j���[�ǉ�)
    [ContextMenu("Deploy")]
    public void Deploy()
    {

        //�q���擾
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }

        //���l�A�A���t�@�x�b�g���Ƀ\�[�g
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        //�I�u�W�F�N�g�Ԃ̊p�x��
        float angleDiff = 80f / (float)childList.Count;

        //�e�I�u�W�F�N�g���~��ɔz�u
        for (int i = 0; i < childList.Count; i++)
        {
            Vector3 childPostion = transform.position;

            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.y += _radius * Mathf.Sin(angle);

            childList[i].transform.position = childPostion;
        }

        //this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        //CircleCenter.transform.Rotate(0.0f, 0.0f, -10);
    }
}
