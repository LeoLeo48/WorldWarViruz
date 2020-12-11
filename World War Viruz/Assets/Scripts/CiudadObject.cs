using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiudadObject : MonoBehaviour
{

    [SerializeField]
    public string Nombre = "Default";
    [SerializeField]
    public int Poblacion = 0;
    [SerializeField]
    public int Ingresos = 0;
    [SerializeField]
    public int Pais = 0; //0:USA; 1:China

    public Clases.Ciudad miCiudad = new Clases.Ciudad("Default", 0, 0, 0);

    public void Start()
    {
        //Ingresos = Poblacion * 3;  //ya se hace en el class
        miCiudad = new Clases.Ciudad(Nombre, Poblacion, Ingresos, Pais);
    }

    private void OnMouseUp()
    {
        Debug.Log(gameObject.name);
        GameObject gameManager = GameObject.FindGameObjectWithTag("gameManager");
        SeleccionarCiudad script = gameManager.GetComponent<SeleccionarCiudad>();
        script.Funcion_AbrirPanelConDatos(gameObject);
    }
}
