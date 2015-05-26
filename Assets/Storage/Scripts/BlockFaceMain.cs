using UnityEngine;
using System.Collections;

public class BlockFaceMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        PlayerMain.reference.SetTarget(gameObject);
    }
}
