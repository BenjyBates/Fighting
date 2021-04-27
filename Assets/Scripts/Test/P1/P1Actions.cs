using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Actions : MonoBehaviour
{ 
    public GameObject Player1;
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("LP"))
        {
            Anim.SetTrigger("LP");
        }
    }
}
