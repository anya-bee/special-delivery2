using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTutorial_MoveCamera : Script_ActionsTutorial
{
    [SerializeField] CameraMovement CameraScript;
    [SerializeField] Transform CameraTransform;
    [SerializeField] Transform DestinationTransform;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] AnimationCurve animationCurveRotation;
    [SerializeField] float duration;
    public override void Action()
    {
        CameraScript.isInside = true;
        StartCoroutine(Animationtransform(duration, CameraTransform.position, DestinationTransform.position));
        StartCoroutine(Animationrotation(duration, CameraTransform.rotation, DestinationTransform.rotation));

    }

    public override void Action(float time)
    {
        //throw new System.NotImplementedException();
    }

    IEnumerator Animationtransform(float duration, Vector3 firsPos, Vector3 lastPos)
    {

        Vector3 StartPosition = new Vector3(0,0, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            //StartPosition= transform.position;
            elapsedTime += Time.deltaTime;
            float Strenght = animationCurve.Evaluate(elapsedTime / duration);


            CameraTransform.position = firsPos + ((lastPos - firsPos) * Strenght);
            //transform.position = transform.position + Random.insideUnitSphere * Strenght;
            yield return null;
        }

        CameraScript.isInside = false;
    }
    IEnumerator Animationrotation(float duration, Quaternion firsPos, Quaternion lastPos)
    {

        Quaternion StartPosition = Quaternion.identity;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            //StartPosition= transform.position;
            elapsedTime += Time.deltaTime;
            float Strenght = animationCurve.Evaluate(elapsedTime / duration);
            if(elapsedTime< duration)
            {
                CameraTransform.rotation = Quaternion.Euler((lastPos.eulerAngles.x - 360) * Strenght, 0, 0);
            }
            else
            {
                CameraTransform.rotation = Quaternion.Euler((lastPos.eulerAngles.x - 360) - ((lastPos.eulerAngles.x - 360) * Strenght), 0, 0);

            }
            
            
            //transform.position = transform.position + Random.insideUnitSphere * Strenght;
            yield return null;
        }
        

    }
}
