using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Animator))]
public class CreaturesController : MonoBehaviour
{

    public AIPath AiPath;

    private void Update()
    {
        if (AiPath.desiredVelocity.x >= 0.1f)
        {
            transform.localPosition = new Vector3(-1f,transform.localPosition.y,transform.localPosition.z);
        } else if (AiPath.desiredVelocity.x <= -0.1f)
        {
            transform.localPosition = new Vector3(1f,transform.localPosition.y,transform.localPosition.z);
        }
    }
}
