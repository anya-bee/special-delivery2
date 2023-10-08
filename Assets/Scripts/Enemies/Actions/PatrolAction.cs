using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : AIAction
{
    public Transform targetA;
    public Transform targetB;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetAPosition = Vector3.zero;
    private Vector3 targetBPosition = Vector3.zero;
    private bool hasReachedA = false;
    private bool hasReachedB = true;

    protected override void Start()
    {
        base.Start();
        targetAPosition = targetA.position;
        targetBPosition = targetB.position;
    }

    public override void PerformAction()
    {
        if (!hasReachedA && Vector3.Distance(this.transform.position, targetAPosition) < 0.05f)
        {
            hasReachedA = true;
            hasReachedB = false;
        }

        if (!hasReachedB && Vector3.Distance(this.transform.position, targetBPosition) < 0.05f)
        {
            hasReachedA = false;
            hasReachedB = true;
        }

        if (!hasReachedA && hasReachedB)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetAPosition, ref velocity, smoothTime);
            return;
        }

        if (!hasReachedB && hasReachedA)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetBPosition, ref velocity, smoothTime);
            return;
        }
    }
}
