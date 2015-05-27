using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

    public static PlayerMain reference;
    private new Rigidbody rigidbody;
    private CustomGravity customGravity;

    private Vector3 direction = Vector3.forward;
    private GameObject AI_LastTarget;

    void Awake()
    {
        reference = this;
    }

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        customGravity = GetComponent<CustomGravity>();
        StartCoroutine(AI());
	}

    void Update()
    {
    }

    public void SetTarget(GameObject obj)
    {
        if (obj != AI_LastTarget)
        {
            customGravity.Target = obj;
            AI_LastTarget = obj;
        }
    }

    IEnumerator AI()
    {
        bool validTarget = false;
        RaycastHit hit;

        if (!validTarget && Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 1f))
        {
            if (hit.collider.gameObject != AI_LastTarget)
            {
                validTarget = true;
                SetTarget(hit.collider.gameObject);
            }
        }
        if (!validTarget && Physics.Raycast(transform.position + transform.TransformDirection(direction), transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            if (hit.collider.gameObject != AI_LastTarget)
            {
                validTarget = true;
                SetTarget(hit.collider.gameObject);
            }
        }
        
        if(!validTarget)
        {
            string next = "";
            #region NextCalc
            if (direction == Vector3.forward)
            {
                switch (customGravity.target.name)
                {
                    case "U":
                        next = "F";
                        break;
                    case "F":
                        next = "D";
                        break;
                    case "D":
                        next = "B";
                        break;
                    case "B":
                        next = "U";
                        break;
                }
            }
            else if (direction == Vector3.back)
            {
                switch (customGravity.target.name)
                {
                    case "U":
                        next = "B";
                        break;
                    case "F":
                        next = "U";
                        break;
                    case "D":
                        next = "F";
                        break;
                    case "B":
                        next = "D";
                        break;
                }
            }
            else if (direction == Vector3.right)
            {
                switch (customGravity.target.name)
                {
                    case "U":
                        next = "R";
                        break;
                    case "R":
                        next = "D";
                        break;
                    case "D":
                        next = "L";
                        break;
                    case "L":
                        next = "U";
                        break;
                }
            }
            else if (direction == Vector3.left)
            {
                switch (customGravity.target.name)
                {
                    case "U":
                        next = "L";
                        break;
                    case "L":
                        next = "D";
                        break;
                    case "D":
                        next = "R";
                        break;
                    case "R":
                        next = "U";
                        break;
                }
            }
            #endregion
            if (next != "")
            {
                Debug.Log(next);
                SetTarget(customGravity.target.transform.parent.Find(next).gameObject);
            }
        }

        yield return new WaitForSeconds(.5f);
        StartCoroutine(AI());
    }
}
