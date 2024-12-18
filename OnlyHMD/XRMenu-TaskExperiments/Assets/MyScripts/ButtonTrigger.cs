using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject T2t;
    private Task2Top t2t = new Task2Top();
    // Start is called before the first frame update
    void Start()
    {
        t2t = T2t.GetComponent<Task2Top>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (t2t.Bnum == null)
        {
            StartCoroutine(TriggerOn());
        }

        /*
        t2t.Bnum = this.gameObject.name;
        Debug.Log("衝突！："+this.gameObject.name);
        for(float y = 0; y > 30; y++)
        {
            this.transform.position += new Vector3(0, -0.001f, 0);
        }
        for (float y = 0; y > 30; y++)
        {
            this.transform.position += new Vector3(0, 0.001f, 0);
        }
        t2t.Bnum = null;
        */
    }

    IEnumerator TriggerOn()
    {
        t2t.f = true;

        t2t.Bnum = this.gameObject.name;
        Debug.Log("衝突！：" + t2t.Bnum);
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
        t2t.Bnum = null;
    }
}
