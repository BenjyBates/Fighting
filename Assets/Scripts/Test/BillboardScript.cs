using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Transform CamTransform;

    private void Update()
    {
        transform.rotation = CamTransform.rotation;
    }
}
