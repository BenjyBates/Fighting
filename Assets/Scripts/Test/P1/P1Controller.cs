using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{

    public GameObject Player1;

    public float p1Speed;

    public void Update()
    {
        Player1.transform.Translate(Input.GetAxisRaw("Horizontal") * p1Speed * Time.deltaTime, 0, 0);
    }

}
