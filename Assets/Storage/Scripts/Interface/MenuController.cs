using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController: MonoBehaviour {
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }
    public void Creditos()
    {
        Application.LoadLevel("Creditos");
    }
    public void Instrucoes()
    {
        Application.LoadLevel("Instrucoes");
    }
    public void Opcoes()
    {
        Application.LoadLevel("Opcoes");
    }
    public void Fase1()
    {
        Application.LoadLevel("Fase1");
    }
}
