using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {

    public GameObject target;
    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 target_face = target.transform.position + target.transform.TransformDirection(Vector3.back * transform.localScale.z)/2;
            Vector3 newRot;
            newRot = target.transform.rotation.eulerAngles + new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(fixR(newRot.x * Mathf.Sign(target.transform.localScale.x)), fixR(newRot.y * Mathf.Sign(target.transform.localScale.y)), fixR(newRot.z * Mathf.Sign(target.transform.localScale.z))), 0.2f);
            transform.position = Vector3.Lerp(transform.position, target_face, 0.2f);
        }
    }

    float fixR(float f)
    {
        return f % 360;
    }
}
