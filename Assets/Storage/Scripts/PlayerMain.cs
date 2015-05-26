using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

    public static PlayerMain reference;
    private new Rigidbody rigidbody;
    private CustomGravity customGravity;

    void Awake()
    {
        reference = this;
    }

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        customGravity = GetComponent<CustomGravity>();
	}
	
	void FixedUpdate () {
        //transform.Translate(.2f * new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")));
	}

    public void SetTarget(GameObject obj)
    {
        customGravity.Target = obj;
    }
}
