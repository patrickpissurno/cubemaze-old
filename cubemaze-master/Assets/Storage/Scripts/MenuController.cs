
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController: MonoBehaviour {
	private GameObject Play;
	private GameObject opcoes;
	private GameObject creditos;
	private GameObject instrucoes;
	private GameObject Voltar;
	// Use this for initialization
	void Start () {
		if(Application.loadedLevel.Equals(0)){
				Play = GameObject.Find("Tplay");
				opcoes = GameObject.Find("Top");
				creditos = GameObject.Find("Tcred");
				instrucoes = GameObject.Find("Tinstr");
			}
		if(Application.loadedLevel != 0 && Application.loadedLevel != 1 )Voltar = GameObject.Find("voltar");
	}
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevel.Equals(0)){
			if (!Play.activeSelf)
				Application.LoadLevel("Game");
			else if(!opcoes.activeSelf)
				Application.LoadLevel("opcoes");
			else if(!creditos.activeSelf)
				Application.LoadLevel("creditos");
			else if(!instrucoes.activeSelf)
				Application.LoadLevel("instrucoes");
		}
		if(Application.loadedLevel != 0 && Application.loadedLevel != 1 && !Voltar.activeSelf)Application.LoadLevel("Menu");
	}
}
