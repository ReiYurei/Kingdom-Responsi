using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float Speed;

    private void LateUpdate()
    {
        if (transform.position != Target.position)
        {
            var targetPos = new Vector3(Target.position.x, Target.position.y + Offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position,targetPos, Speed);
        }
    }
}
