using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    

    public void Funcion_CambiarScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void Funcion_Salir(int num)
    {
        Application.Quit();
    }

}
