using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateManager : MonoBehaviour
{
    public GameObject T1Top;
    private Task1Top t1t = new Task1Top();
    public float rotateSpeed = 3.0f;

    private int Rc;
    // Start is called before the first frame update
    void Start()
    {
        t1t = T1Top.GetComponent<Task1Top>();
        Rc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rc < 3)
        {
            if (t1t.R == true)
            {
                if (Input.GetKeyDown(KeyCode.F4))
                {
                    StartCoroutine(Rotate1());
                }
            }
            else
            {

            }
        }
        else
        {

        }
    }

    IEnumerator Rotate1()
    {
        //yield return new WaitForSeconds(3f);
        /*
        Vector3 pos = this.transform.position;
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;
        float l = 0;
        Debug.Log(l+" , "+angle);
        while (l > 360)
        {
            Debug.Log(l);
            transform.RotateAround(pos, Vector3.up, angle);
            l += angle;
        }
        */

        for (int turn = 0; turn < 1440; turn++)
        {
            transform.Rotate(0, 0.25f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        t1t.R = false;
        Rc++;
        Debug.Log("‚©‚¢‚Ä‚ñI");
        yield return null;
    }
}
