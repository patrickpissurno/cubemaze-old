﻿using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

    public static PlayerMain reference;
    private CustomGravity customGravity;
    private GameObject playerClone;

    private Vector3 direction = Vector3.right;
    private GameObject AI_LastTarget;

    #region Get/Set
    public Vector3 Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
            if (direction == Vector3.left || direction == Vector3.right)
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z));
            else
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
        }
    }
    #endregion

    void Awake()
    {
        reference = this;
    }


	void Start () {
		playerClone = GameObject.Find("Player_Rotation");
        Direction = Vector3.forward;
        customGravity = GetComponent<CustomGravity>();
        StartCoroutine(AI());
	}

    public void SetTarget(GameObject obj)
    {
        if (obj != AI_LastTarget && obj.GetComponent<BlockFaceMain> () != null) {
			BlockFaceMain bf = obj.GetComponent<BlockFaceMain> ();
			if (bf != null) {
				switch (bf.ChangeDirection.ToLower ()) {
				case "left":
					Direction = Vector3.left;
					
					break;
				case "right":
					Direction = Vector3.right;
					
					break;
				case "forward":
					Direction = Vector3.forward;
					
					break;
				case "back":
				case "backwards":
					Direction = Vector3.back;
					
					break;
				}
			}

			if (Direction == Vector3.right || Direction == Vector3.left)
				obj.GetComponent<BlockFaceMain> ().ChangeFix (true);
			else
				obj.GetComponent<BlockFaceMain> ().ChangeFix (false);

			customGravity.Target = obj;
			AI_LastTarget = obj;
		} else
		{
			/*Item item = obj.GetComponent<Item>();
			if(item != null)
			{
				item.Collected();
				print("oi");
			}*/
		}
    }

    #region AI Code
    IEnumerator AI()
    {
        bool validTarget = false;
        RaycastHit hit;

        Vector3 dir = Vector3.forward;
        if (Direction == Vector3.back || Direction == Vector3.left)
            dir = Vector3.back;
        Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.green, .5f);
        Debug.DrawRay(transform.position + transform.TransformDirection(dir), transform.TransformDirection(Vector3.down), Color.red, .5f);
        if (!validTarget && Physics.Raycast(transform.position, transform.TransformDirection(Direction), out hit, 1f))
        {
            if (hit.collider.gameObject != AI_LastTarget)
            {
                validTarget = true;
                SetTarget(hit.collider.gameObject);
            }
        }
        if (!validTarget && Physics.Raycast(transform.position + transform.TransformDirection(dir), transform.TransformDirection(Vector3.down), out hit, 1f))
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
            if (Direction == Vector3.forward)
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
            else if (Direction == Vector3.back)
            {
				Debug.Log("AMOR");
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
            else if (Direction == Vector3.right)
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
            else if (Direction == Vector3.left)
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
    #endregion
}
