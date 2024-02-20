using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeToOrigin : AIDecision
{
    Vector3 originalPosition;
    protected override void Start()
    {
        originalPosition = transform.position;
    }
    public override bool Decide()
    {
        if (Vector3.Distance(transform.position, originalPosition) <= 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
