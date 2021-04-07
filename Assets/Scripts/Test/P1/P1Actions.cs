using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Actions : MonoBehaviour
{
    public float P1JumpSpeed;
    public GameObject Player1;

    public void JumpUp()
    {
        Player1.transform.Translate(0, P1JumpSpeed, 0);
    }
}
