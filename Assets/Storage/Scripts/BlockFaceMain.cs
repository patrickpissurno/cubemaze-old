using UnityEngine;
using System.Collections;

public class BlockFaceMain : MonoBehaviour {

    private Vector3 rotation;
    private Vector3 scale;

    void Awake()
    {
        //Debug.LogError(this.transform.rotation.eulerAngles + "  |  " + this.transform.localScale);

        this.rotation = this.transform.rotation.eulerAngles;
        this.scale = this.transform.localScale;
    }

    public void ChangeFix(bool fix)
    {
        this.transform.rotation = Quaternion.Euler(this.rotation);
        this.transform.localScale = this.scale;
        if (fix)
        {
            switch (gameObject.name)
            {
                case "U":
                case "D":
                    this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.eulerAngles.x, 90, this.transform.rotation.eulerAngles.z));
                    break;
                case "R":
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
                    break;
            }
        }
    }
}
