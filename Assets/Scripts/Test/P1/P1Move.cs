using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    //Private
    private Animator Anim;
    private AnimatorStateInfo P1Layer0;
    private bool IsJumping = false;
    private bool CanWalkLeft = true;
    private bool CanWalkRight = true;
    private bool FacingLeft = true;
    private bool FacingRight = false;
    private Vector3 OppPosition;

    //Public
    public float P1WalkSpeed;
    public int ScreenBoundValue;
    public GameObject Player1;
    public GameObject Opponent;


    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //ANIMATOR LOGIC
        P1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //SCREEN BOUNDRY
        Vector3 ScreenBounds = Camera.main.WorldToScreenPoint(this.transform.position);
        if(ScreenBounds.x > Screen.width - ScreenBoundValue)
        {
            CanWalkRight = false;
        }
        if (ScreenBounds.x < ScreenBoundValue)
        {
            CanWalkLeft = false;
        }
        else if (ScreenBounds.x > ScreenBoundValue && ScreenBounds.x < Screen.width - ScreenBoundValue)
        {
            CanWalkLeft = true;
            CanWalkRight = true;
        }

        //OPPONENT POSITION
        OppPosition = Opponent.transform.position;
        //face opponent
        if(OppPosition.x > Player1.transform.position.x)
        {
            StartCoroutine(FaceRight());
        }
        if (OppPosition.x < Player1.transform.position.x)
        {
            StartCoroutine(FaceLeft());
        }

        //HORIZONTAL MOVEMENT
        if(P1Layer0.IsTag("Motion"))
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                if(CanWalkRight == true)
                {
                    Anim.SetBool("FORWARD", true);
                    transform.Translate(P1WalkSpeed, 0, 0);
                }

            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if(CanWalkLeft == true)
                {
                    Anim.SetBool("BACKWARD", true);
                    transform.Translate(-P1WalkSpeed, 0, 0);
                }

            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Anim.SetBool("FORWARD", false);
            Anim.SetBool("BACKWARD", false);
        }

        //VERTICAL MOVEMENT
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (IsJumping == false)
            {
                IsJumping = true;
                Anim.SetTrigger("JUMP");
                StartCoroutine(JumpPause());
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            Anim.SetBool("CROUCH", true);
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            Anim.SetBool("CROUCH", false);
        }
    }

    //COROUTINE LOGIC
    IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(1.0f);
        IsJumping = false;
    }

    IEnumerator FaceLeft()
    {
        if(FacingLeft == true)
        {
            FacingLeft = false;
            FacingRight = true;
            yield return new WaitForSeconds(.15f);
            Player1.transform.Rotate(0, 180, 0);
        }

    }

    IEnumerator FaceRight()
    {
        if (FacingRight == true)
        {
            FacingRight = false;
            FacingLeft = true;
            yield return new WaitForSeconds(.15f);
            Player1.transform.Rotate(0, -180, 0);
        }
    }

}
