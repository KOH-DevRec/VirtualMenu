using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerT1 : MonoBehaviour
{
    public GameObject T1t;
    private Task1Top t1t = new Task1Top();

    private bool cflag;
    // Start is called before the first frame update
    void Start()
    {
        t1t = T1t.GetComponent<Task1Top>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (t1t.Bnum == null)
        {
            StartCoroutine(TriggerOn());
        }
    }

    IEnumerator TriggerOn()
    {
        t1t.f = true;

        t1t.Bnum = this.gameObject.name;
        Debug.Log("è’ìÀÅIÅF" + t1t.Bnum);

        for (float y = 0; y < 15; y++)
        {
            this.transform.position += new Vector3(0, -0.002f, 0);
            yield return new WaitForSeconds(0.01f);
        }

        for (float y = 0; y < 15; y++)
        {
            this.transform.position += new Vector3(0, 0.002f, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.0f);
        t1t.rotateN++;
        t1t.Bnum = null;
    }
}
