using UnityEngine;
using System.Collections;
public class BlockFaceMain : MonoBehaviour {

    private Vector3 rotation;
    private Vector3 scale;
	public bool changer = true;
    public string changeDirection = "none";
    public bool targeted = false;

    #region Get/Set
    public string ChangeDirection
    {
        get
        {
            return changeDirection;
        }
        set
        {
            changeDirection = value;
            if (meshRenderer != null)
            {
                switch (changeDirection.ToLower())
                {
                    case "forward":
                        meshRenderer.material.SetTexture("_MainTex", textures[1]);
                        break;
                    case "right":
                        meshRenderer.material.SetTexture("_MainTex", textures[2]);
                        break;
                    case "backwards":
                    case "back":
                        meshRenderer.material.SetTexture("_MainTex", textures[3]);
                        break;
                    case "left":
                        meshRenderer.material.SetTexture("_MainTex", textures[4]);
                        break;
                    case "none":
                        meshRenderer.material.SetTexture("_MainTex", textures[0]);
                        break;
                }
            }
        }
    }
    #endregion

    private MeshRenderer meshRenderer;
    private static Texture2D[] textures;

    void Awake()
    {
        if (textures == null)
            textures = Resources.LoadAll<Texture2D>("Graphics/Textures");
        this.rotation = this.transform.rotation.eulerAngles;
        this.scale = this.transform.localScale;
    }

    void Start()
    {
        if(this.meshRenderer == null)
        	this.meshRenderer = this.GetComponent<MeshRenderer>();
    }

    public void ChangeFix(bool fix)
    {
		if(this.meshRenderer == null)
			this.meshRenderer = this.GetComponent<MeshRenderer>();
			
        this.transform.rotation = Quaternion.Euler(this.rotation);
        this.transform.localScale = this.scale;
        if (fix)
        {
            ChangeDirection = changeDirection;
            Texture currentTexture = meshRenderer.material.GetTexture("_MainTex");
            switch (gameObject.name)
            {
                case "U":
                case "D":
                    this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.eulerAngles.x, 90, this.transform.rotation.eulerAngles.z));
                    if (currentTexture == textures[4])
                        currentTexture = textures[3];
                    else if (currentTexture == textures[3])
                        currentTexture = textures[2];
                    else if (currentTexture == textures[2])
                        currentTexture = textures[1];
                    else if (currentTexture == textures[1])
                        currentTexture = textures[4];
                    meshRenderer.material.SetTexture("_MainTex", currentTexture);
                    break;
                case "R":
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 180));
                    this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
                    break;
            }
        }
        else
        {
            ChangeDirection = changeDirection;
        }
    }

    void OnMouseDown()
    {
        if (!targeted)
        {
            if (gameObject.name == "U" && changer || gameObject.name == "D" && changer)
            {
                RaycastHit hit;
                bool anything = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, .5f);
                if (anything && (hit.transform.tag.ToLowerInvariant() != "player" && hit.transform.tag.ToLowerInvariant() != "enemy") || !anything)
                {
                    this.transform.rotation = Quaternion.Euler(this.rotation);
                    this.transform.localScale = this.scale;
                    switch (ChangeDirection.ToLower())
                    {
                        case "forward":
                            ChangeDirection = "Right";
                            break;
                        case "right":
                            ChangeDirection = "Backwards";
                            break;
                        case "backwards":
                        case "back":
                            ChangeDirection = "Left";
                            break;
                        case "left":
                            ChangeDirection = "None";
                            break;
                        case "none":
                            ChangeDirection = "Forward";
                            break;
                    }
                }
            }
        }
    }
	
	public void ChangeCustom(string direction)
	{
		if (gameObject.name == "U" && changer || gameObject.name == "D" && changer)
		{
			if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), .5f))
			{
				this.transform.rotation = Quaternion.Euler(this.rotation);
				this.transform.localScale = this.scale;
				ChangeDirection = direction;
			}
		}
	}
}
