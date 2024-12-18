using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveManager : MonoBehaviour
{
    Vector3 StartPos;
    public float rotateSpeed = 3.0f;

    public int taskN = 0;   //どのタスクをやっているか

    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //戻る用？
        if (Input.GetKeyDown(KeyCode.F10))
        {
            StartCoroutine(Move0());
        }

        //Task1移動用
        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartCoroutine(Move1());
        }

        //Task2移動用
        if (Input.GetKeyDown(KeyCode.F2))
        {
            StartCoroutine(Move2());
        }
    }

    IEnumerator Move0()
    {
        Vector3 pos = this.transform.position;

        Debug.Log(pos);
        Debug.Log("task1 move");

        if (pos.z < 0)
        {
            while (pos.z < 0)
            {
                pos.z += 0.03f;
                this.transform.position = pos;
                yield return null;
            }
        }

        if (pos.x > 0)
        {
            while (pos.z < 3)
            {
                pos.z += 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.x > 9)
            {
                pos.x -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.z > 0)
            {
                pos.z -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.x > 0)
            {
                pos.x -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }
        }

        taskN = 1;
        Debug.Log("task1 moved");
    }

    IEnumerator Move1()
    {
        Vector3 pos = this.transform.position;

        Debug.Log(pos);
        Debug.Log("task1 move");

        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        if (pos.z < 0)
        {
            while (pos.z < 0)
            {
                pos.z += 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);
        }



        if (pos.x < 15)
        {
            /*
            while (pos.x < 9)
            {
                pos.x += 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.z < 3)
            {
                pos.z += 0.03f;
                this.transform.position = pos;
                yield return null;
            }
            yield return new WaitForSeconds(1f);
            */

            while (pos.x < 15)
            {
                pos.x += 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.z > 0)
            {
                pos.z -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }
        }

        taskN = 1;
        Debug.Log("task1 moved");
    }

    IEnumerator Move2()
    {
        Vector3 pos = this.transform.position;

        Debug.Log(pos);
        Debug.Log("task2 move");

        if (pos.x > 0)
        {
            for (int turn = 0; turn < 90; turn++)
            {
                transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(1f);

            while (pos.z < 3)
            {
                pos.z += 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.x > 9)
            {
                pos.x -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.z > 0)
            {
                pos.z -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (pos.x > 0)
            {
                pos.x -= 0.03f;
                this.transform.position = pos;
                yield return null;
            }

            yield return new WaitForSeconds(1f);
        }

        while (pos.z > -1.2f)
        {
            pos.z -= 0.03f;
            this.transform.position = pos;
            yield return null;
        }

        taskN = 2;
        Debug.Log("task2 moved");
    }
}
