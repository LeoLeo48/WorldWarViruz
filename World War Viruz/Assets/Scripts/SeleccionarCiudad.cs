using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarCiudad : MonoBehaviour
{
    Clases.Ciudad ciudad;
    GameObject ciudadRef;
    /// <summary>
    /// ////////
    /// </summary>
    [SerializeField]
    GameObject imageDatos;

    [SerializeField]
    Text txtNombre;

    [SerializeField]
    Text txtPoblacion;

    [SerializeField]
    Text txtIngresos;


    [SerializeField]
    Sprite sprBotonRojo;
    [SerializeField]
    Sprite sprBotonVerde;
    /*
    private void OnMouseDrag()
    {
        Debug.Log("click OnMousedrag");
        siArrastrandoMouse = true;
    }
    */
    private void Start()
    {
        
        imageDatos.SetActive(false);
        
    }
    public void Funcion_CerrarPanel()
    {
        imageDatos.SetActive(false);
    }
    public void Funcion_AbrirPanelConDatos(GameObject ciudadd)
    {
        ciudadRef = ciudadd;
        CiudadObject ciudadObject = ciudadd.GetComponent<CiudadObject>();
        ciudad = ciudadObject.miCiudad;
        txtNombre.text = ciudad.Nombre;
        txtPoblacion.text = ciudad.Poblacion+ " habitantes.";
        txtIngresos.text = "+"+ciudad.Ingresos+ "/mes $";

        imageDatos.SetActive(true);
        //Debug.Log("funcion abrir panel con datos");
    }

    public void Funcion_HacerRevision()
    {
        if (ciudadRef != null)
        {
            CiudadObject ciudadScript = ciudadRef.GetComponent<CiudadObject>();
            if (ciudadScript.miCiudad.DeboHacerRevision) //Si esta activado, al hacer click debe desactivarlo
            {
                ciudadScript.miCiudad.DeboHacerRevision = false;
                txtGastando.text = (long.Parse(txtGastando.text) - 1000000).ToString();
                txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
            }
            else
            {
                ciudadScript.miCiudad.DeboHacerRevision = true;
                txtGastando.text = (long.Parse(txtGastando.text) + 1000000).ToString();
                txtMensaje.text = "";
            }
        }
        else
        {
            Debug.Log("Error: la ciudad guardada en el panel es nulo (Hacer revision)");
        }
    }
    [SerializeField]
    Text txtBotonCuarentena;
    [SerializeField]
    Text txtGastando;
    [SerializeField]
    Text txtMensaje;
    public void Funcion_PonerQuitarCuarentena(Image btnSprite)
    {
        if (ciudadRef != null)
        {
            CiudadObject ciudadScript = ciudadRef.GetComponent<CiudadObject>();
            ciudadScript.miCiudad.DeboEstarCuarentena = !ciudadScript.miCiudad.DeboEstarCuarentena;
            if (ciudadScript.miCiudad.DeboEstarCuarentena == false) //empieza siendo falso, al ponerCuarentena, se vuelve true, y debe al mimsmo tiempo cambiar a verde
            {
                btnSprite.sprite = sprBotonRojo;
                txtBotonCuarentena.text = "Poner en Cuarentena";
                txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
            }
            else
            {
                btnSprite.sprite = sprBotonVerde;
                txtBotonCuarentena.text = "Quitar Cuarentena";
                txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
            }
        }
        else
        {
            Debug.Log("Error: la ciudad guardada en el panel es nulo (Hacer revision)");
        }
    }
}
