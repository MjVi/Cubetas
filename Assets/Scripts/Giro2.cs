using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro2 : MonoBehaviour
{
    public GameObject pivote;
    Spawner spawner;
    public int n;

    void Start()
    {
    }

    void Update()
    {
        bool l = Input.GetKeyDown(KeyCode.LeftArrow);
        bool r = Input.GetKeyDown(KeyCode.RightArrow);

        if (l)
        {
            transform.RotateAround(pivote.transform.position, Vector3.up, 120.0f);
            n = n - 1;
            if (n == -1)
            {
                n = 2;
            }
            l = false;
        }
        else if (r)
        {
            transform.RotateAround(pivote.transform.position, Vector3.down, 120.0f);
            n = n + 1;
            if (n == 3)
            {
                n = 0;
            }
            r = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && PlayerControl.life > 0)
        {
            Destroy(other.gameObject);

            if (Spawner.ballsCopy[0] == Spawner.bucketsCopy[n])
            {
                PlayerControl.score = PlayerControl.score + 1;
            }
            else
            {
                PlayerControl.life = PlayerControl.life - 5;
            }
        }
    }
}

