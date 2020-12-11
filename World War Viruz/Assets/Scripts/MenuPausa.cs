using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField]
    Canvas canvasMenuPausa;

    bool isShowing = true;
    //Canvas canvasMenuPausa;
    // Start is called before the first frame update
    void Start()
    {
        Funcion_SwitchMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Funcion_SwitchMenu();
        }
    }

    public void Funcion_SwitchMenu()
    {
        isShowing = !isShowing;
        canvasMenuPausa.enabled = !canvasMenuPausa.enabled;
    }
    public void Funcion_CambiarScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
