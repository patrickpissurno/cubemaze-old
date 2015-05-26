using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {

    private new Rigidbody rigidbody;
    public float gravityAmount = 25f;

    private GameObject target;
    private bool landed = false;

	void Start () {
        this.rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
        {
            target = hit.collider.gameObject;
        }
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            this.rigidbody.AddForce((target.transform.position - transform.position).normalized * gravityAmount);
            if (!landed)
            {
                Vector3 vec = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;
                transform.rotation = Quaternion.Euler(vec.x, transform.rotation.eulerAngles.y, vec.z);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        landed = true;
    }

    void OnCollisionExit(Collision col)
    {
        landed = false;
    }
}
