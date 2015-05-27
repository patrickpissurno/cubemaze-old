using UnityEngine;
using System.Collections;

public class BlockFaceMain : MonoBehaviour {

    private Quaternion rotation;
    private Vector3 scale;

    void Start()
    {
        this.rotation = this.transform.rotation;
        this.scale = this.transform.localScale;
    }

    public void ChangeFix(bool fix)
    {
        this.transform.rotation = this.rotation;
        this.transform.localScale = this.scale;
        if (fix)
        {
            switch (gameObject.name)
            {
                case "U":
                case "D":
                    this.transform.Rotate(new Vector3(0, 90, 0));
                    break;
                case "R":
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
                    break;
            }
        }
    }
}
