using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {

    private new Rigidbody rigidbody;
    public float gravityAmount = 25f;

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
            boost = Vector3.left;
        }
    }
    private bool landed = false;
    private Vector3 boost = Vector3.zero;

	void Start () {
        this.rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
            target = hit.collider.gameObject;*/
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            //if (!landed)
            {
                //Vector3 vec = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;
                //transform.rotation = Quaternion.Euler(fixR(vec.x - 90), transform.rotation.eulerAngles.y, vec.z);
                //this.rigidbody.AddForce((target.transform.position - transform.position).normalized * gravityAmount);
            }
            Vector3 target_face = target.transform.position + target.transform.TransformDirection(Vector3.back * transform.localScale.z)/2;
            transform.position = Vector3.Lerp(transform.position, target_face, 0.2f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        landed = true;
        boost = Vector3.zero;
    }

    void OnCollisionExit(Collision col)
    {
        landed = false;
    }

    float fixR(float f)
    {
        return f % 360;
    }

    float GetVelocitySum()
    {
        float a = rigidbody.velocity.x;
        a += rigidbody.velocity.y;
        a += rigidbody.velocity.z;
        a /= 3;
        return a;
    }
}
