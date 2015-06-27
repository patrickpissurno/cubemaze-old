using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	private GameObject Handitem;
	public static bool item;
	// Use this for initialization
	void Start () {
		item = false;
		Handitem = GameObject.Find("Handitem");
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag.Equals("Player")){transform.SetParent(Handitem.transform);item = true;}
	
	}
	
	
	
}
