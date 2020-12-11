using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    //Para el desplazamiento con el mouse

    int zoom = 20;
    int normal = 60; //se puede aumentar o disminuir 
    float smooth = 5;
    private bool isZoomed = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);

        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }

    //Para los botones
    Vector3 posUSA;
    Vector3 posChina;

    [SerializeField]
    GameObject estadosUnidos;

    [SerializeField]
    GameObject china;

    public void Start()
    {
        posUSA = new Vector3(estadosUnidos.transform.position.x, estadosUnidos.transform.position.y,-10);
        posChina = new Vector3(china.transform.position.x, china.transform.position.y,-10);
    }
    public void Funcion_VerChina()
    {
        gameObject.transform.position = posChina;
        //gameObject.transform.position = china.transform.position;
    }
    public void Funcion_VerUsa()
    {
        gameObject.transform.position = posUSA;
    }
}
