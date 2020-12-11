using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SistemaTurnos : MonoBehaviour
{
    [SerializeField]
    public int dineroUSA = 3000000;
    [SerializeField]
    long dineroChina = 3000000; //3.000.000

    [SerializeField]
    public int montoONU = 50000; //50.000

    public int inventarioVirus1USA = 0;
    public int inventarioVirus2USA = 0;
    public int inventarioVirus3USA = 0;
    public int inventarioVirus1China = 0;
    public int inventarioVirus2China = 0;
    public int inventarioVirus3China = 0;

    public bool deboAnadirVirus1USA = false;
    public bool deboAnadirVirus2USA = false;
    public bool deboAnadirVirus3USA = false;

    [SerializeField]
    Text txtDinero;
    [SerializeField]
    Text txtGastando;
    [SerializeField]
    Text txtMensaje;
    [SerializeField]
    Text txtONU;
    [SerializeField]
    Text txtCantVirus1;
    [SerializeField]
    Text txtCantVirus2;
    [SerializeField]
    Text txtCantVirus3;
    [SerializeField]
    Text txtMes;
    int numMes = 1;

    [SerializeField]
    GameObject canvasResultados;
    [SerializeField]
    Text txtVictoria;

    long montoAGastarUSA;

    int montoCuentaUSA = 0;
    int montoCuentaChina = 0;

    public int USACiudadesPerdidas = 0;
    public int ChinaCiudadesPerdidas = 0;

    Clases.Virus virus1 = new Clases.Virus(1);
    Clases.Virus virus2 = new Clases.Virus(2);
    Clases.Virus virus3 = new Clases.Virus(3);
    //int montoUSATotal = 0;
    //int montoChinaTotal = 0;
    // Start is called before the first frame update
    void Start()
    {
        txtDinero.text = dineroUSA.ToString();
        canvasResultados.SetActive(false);
        // CONTAR PAISES
        /*
        GameObject[] objetosCiudades = GameObject.FindGameObjectsWithTag("ciudad");
        CiudadObject script;
        List<Clases.Ciudad> ciudades = new List<Clases.Ciudad>();
        foreach (GameObject obj in objetosCiudades)
        {
            Debug.Log(obj.name);
            script = obj.GetComponent<CiudadObject>();
            //ciudades.Add(script.miCiudad);
            if (script.miCiudad.Pais == 0) cantCiudadesUSA++;
            if (script.miCiudad.Pais == 1) cantCiudadesChina++;
        }
        Debug.Log(cantCiudadesUSA);
        Debug.Log(cantCiudadesChina);
        */
        
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Funcion_PasarTurno()
    {
        //Paso 1: Enlistar acciones a realizar
        GameObject[] objetosCiudades = GameObject.FindGameObjectsWithTag("ciudad");
        CiudadObject script;
        List<Clases.Ciudad> ciudades = new List<Clases.Ciudad>();

        foreach (GameObject obj in objetosCiudades)
        {
            script = obj.GetComponent<CiudadObject>();
            ciudades.Add(script.miCiudad);
        }
        //hasta aca tenemos los datos de cada ciudad existente
        montoCuentaChina = 0+montoONU;
        montoCuentaUSA = 0+montoONU;
        foreach (Clases.Ciudad ciud in ciudades)
        {

            if (ciud.IsMuerto == false)
            {
                //Aplicar ingresos
                if (ciud.Pais == 0 && ciud.IsCuarentena == false) dineroUSA += ciud.Ingresos;
                if (ciud.Pais == 1 && ciud.IsCuarentena == false) dineroChina += ciud.Ingresos;

                //Aplicar mortalidad virus
                if (ciud.IsInfectado1) {
                    if (ciud.Poblacion <= virus1.MuertesPorMes) { ciud.Poblacion = 0; }
                    else { ciud.Poblacion -= virus1.MuertesPorMes; }
                }
                if (ciud.IsInfectado2)
                {
                    if (ciud.Poblacion <= virus2.MuertesPorMes) { ciud.Poblacion = 0; }
                    else { ciud.Poblacion -= virus2.MuertesPorMes; }
                }
                if (ciud.IsInfectado3)
                {
                    if (ciud.Poblacion <= virus3.MuertesPorMes) { ciud.Poblacion = 0;ciud.IsMuerto = true;if (ciud.Pais == 0) USACiudadesPerdidas++; else ChinaCiudadesPerdidas++; }
                    else { ciud.Poblacion -= virus3.MuertesPorMes; }
                }
                //Aplicar actualizar ingresos segun poblacion
                ciud.Ingresos = ciud.Poblacion*3;
                //Aplicar expansion de virus
                if (ciud.IsInfectado1 && ciud.IsCuarentena == false)
                {
                    for(int i =0; i<virus1.ExpansionesPorMes;i++)
                    {
                        int limite = ciudades.Count;
                        int pos = Random.Range(0, limite - 1);
                        ciudades[pos].IsInfectado1 = true;
                    }
                }
                if (ciud.IsInfectado2 && ciud.IsCuarentena == false)
                {
                    for (int i = 0; i < virus2.ExpansionesPorMes; i++)
                    {
                        int limite = ciudades.Count;
                        int pos = Random.Range(0, limite - 1);
                        ciudades[pos].IsInfectado2 = true;
                    }
                }
                if (ciud.IsInfectado3 && ciud.IsCuarentena == false)
                {
                    for (int i = 0; i < virus3.ExpansionesPorMes; i++)
                    {
                        int limite = ciudades.Count;
                        int pos = Random.Range(0, limite - 1);
                        ciudades[pos].IsInfectado3 = true;
                    }
                }
                //Aplicar infectar virus
                if (ciud.DeboInfectar1)
                {
                    ciud.IsInfectado1 = true;
                    if (ciud.Pais == 0) inventarioVirus1USA--; else inventarioVirus1China--;
                }
                if (ciud.DeboInfectar2)
                {
                    ciud.IsInfectado2 = true;
                    if (ciud.Pais == 0) inventarioVirus2USA--; else inventarioVirus2China--;
                }
                if (ciud.DeboInfectar3)
                {
                    ciud.IsInfectado3 = true;
                    if (ciud.Pais == 0) inventarioVirus3USA--; else inventarioVirus3China--;
                }
                //Hacer revision
                if (ciud.DeboHacerRevision)
                {
                    if (ciud.Pais == 0) { montoCuentaUSA += 1000000; } else { montoCuentaChina += 1000000; }
                    if (ciud.IsInfectado1) { ciud.IsDescubierto1 = true; };
                    if (ciud.IsInfectado2) { ciud.IsDescubierto2 = true; };
                    if (ciud.IsInfectado3) { ciud.IsDescubierto3 = true; };
                }
                //Comprar Virus
                if (deboAnadirVirus1USA) { inventarioVirus1USA++;montoCuentaUSA += virus1.Coste; deboAnadirVirus1USA = false; }
                if (deboAnadirVirus2USA) { inventarioVirus2USA++;montoCuentaUSA += virus2.Coste; deboAnadirVirus2USA = false; }
                if (deboAnadirVirus3USA) { inventarioVirus3USA++;montoCuentaUSA += virus3.Coste; deboAnadirVirus3USA = false; }
                //Aplicar cuarentena
                if (ciud.DeboEstarCuarentena) { ciud.IsCuarentena = true; } else { ciud.IsCuarentena = false; }
            }
            

        }
        //Paso 2: Calcular gastos
        dineroUSA -= montoCuentaUSA;
        dineroChina -= montoCuentaChina;
        montoONU *= 2; //Final

        //Paso 3: Evaluar si GANAN o PIERDEN
        int IsVictoria = 0; //0:no pasa nada, 1:ganas, 2:pierdes
        if (dineroUSA <= 0 || USACiudadesPerdidas >=5) { IsVictoria = 1; }
        if (dineroChina <= 0 || ChinaCiudadesPerdidas >= 5) { IsVictoria = 2;}
        //Actualizar UI
        txtDinero.text = dineroUSA.ToString();
        txtCantVirus1.text = inventarioVirus1USA.ToString();
        txtCantVirus2.text = inventarioVirus2USA.ToString();
        txtCantVirus3.text = inventarioVirus3USA.ToString();

        btnSprComprarVirus1.sprite = sprVirusCoste1;
        btnSprComprarVirus2.sprite = sprVirusCoste2;
        btnSprComprarVirus3.sprite = sprVirusCoste3;

        numMes += 1;
        UIActualizarMes();
        //Paso 4: Generar reporte
        if (IsVictoria == 0) //Si continua la partida usar panelReportes
        {

        }
        else            //Si hay vencedor, usar panelResultados
        {
            canvasResultados.SetActive(true);
            if (IsVictoria == 1)
            {
                txtVictoria.text = "Victoria";
            }
            else
            {
                txtVictoria.text = "Derrota";
            }
        }
        Debug.Log("Dinero gastado: "+montoCuentaUSA);
        Debug.Log("Dinero gastado CHINA: "+montoCuentaChina);
    }
    //Para los sprites de los botones virus
    [SerializeField]
    Image btnSprComprarVirus1;
    [SerializeField]
    Image btnSprComprarVirus2;
    [SerializeField]
    Image btnSprComprarVirus3;
    //Sprites
    [SerializeField]
    Sprite sprVirusCoste1;
    [SerializeField]
    Sprite sprVirusCoste2;
    [SerializeField]
    Sprite sprVirusCoste3;
    [SerializeField]
    Sprite sprVirusComprado1;
    [SerializeField]
    Sprite sprVirusComprado2;
    [SerializeField]
    Sprite sprVirusComprado3;
    public void Funcion_ComprarVirus(int tipo) //Tipo de virus (1 o 2 o 3)
    {
        switch (tipo)
        {
            case 1:
                if (deboAnadirVirus1USA) //Si esta comprado, al clickear debe cancelar la accion
                {
                    deboAnadirVirus1USA = false;txtGastando.text = (long.Parse(txtGastando.text) - virus1.Coste).ToString();txtMensaje.text = "";
                    btnSprComprarVirus1.sprite = sprVirusCoste1;
                }
                else{
                    deboAnadirVirus1USA = true;txtGastando.text = (long.Parse(txtGastando.text) + virus1.Coste).ToString(); txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
                    btnSprComprarVirus1.sprite = sprVirusComprado1;
                }
                break;
            case 2:
                if (deboAnadirVirus2USA) //Si esta comprado, al clickear debe cancelar la accion
                {
                    deboAnadirVirus2USA = false; txtGastando.text = (long.Parse(txtGastando.text) - virus2.Coste).ToString(); txtMensaje.text = "";
                    btnSprComprarVirus2.sprite = sprVirusCoste2;
                }
                else
                {
                    deboAnadirVirus2USA = true; txtGastando.text = (long.Parse(txtGastando.text) + virus2.Coste).ToString(); txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
                    btnSprComprarVirus2.sprite = sprVirusComprado2;
                }
                break;
            case 3:
                if (deboAnadirVirus3USA) //Si esta comprado, al clickear debe cancelar la accion
                {
                    deboAnadirVirus3USA = false; txtGastando.text = (long.Parse(txtGastando.text) - virus3.Coste).ToString(); txtMensaje.text = "";
                    btnSprComprarVirus3.sprite = sprVirusCoste3;
                }
                else
                {
                    deboAnadirVirus3USA = true; txtGastando.text = (long.Parse(txtGastando.text) + virus3.Coste).ToString(); txtMensaje.text = "Se aplicarán los cambios al pasar al siguiente mes";
                    btnSprComprarVirus3.sprite = sprVirusComprado3;
                }
                break;
        }
    }
    void UIActualizarMes()
    {
        switch (numMes)
        { case 1: txtMes.text = "Enero"; break; case 2: txtMes.text = "Febrero"; break; case 3: txtMes.text = "Marzo"; break; case 4: txtMes.text = "Abril"; break;
            case 5: txtMes.text = "Mayo"; break; case 6: txtMes.text = "Junio"; break; case 7: txtMes.text = "Julio"; break; case 8: txtMes.text = "Agosto"; break;
            case 9: txtMes.text = "Septiembre"; break;  case 10: txtMes.text = "Octubre"; break; case 11: txtMes.text = "Noviembre"; break;
            case 12: txtMes.text = "Diciembre"; break;
            case 13: txtMes.text = "Enero";numMes = 1; break;
        }
    }
}
