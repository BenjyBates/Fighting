using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundRules : MonoBehaviour
{
    public float MatchTime;

    [Header("Time")]
    public Text MatchTimeText;

    [Header ("Message")]
    public Text MatchTimeMessage;

    private void Update()
    {
        TimeLogic();
    }


    public void TimeLogic()
    {
        MatchTimeText.text = MatchTime.ToString("00");

        MatchTime -= Time.deltaTime;

        if (MatchTime <= 0)
        {
            MatchTime = 0;
            MatchTimeMessage.gameObject.SetActive(true);
        }
        else
            MatchTimeMessage.gameObject.SetActive(false);
    }
}
