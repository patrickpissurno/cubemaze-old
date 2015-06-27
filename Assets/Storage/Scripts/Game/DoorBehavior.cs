using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision col){

		if(col.gameObject.tag.Equals("Player") && Item.item.Equals(true))Application.LoadLevel("Menu");
	}
}
