using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clases : MonoBehaviour
{
    public class Ciudad
    {
        public string Nombre { get; set; }
        public int Poblacion { get; set; }
        public int Ingresos { get; set; }
        public int Pais { get; set; } //0:USA,1:China

        public bool IsCuarentena { get; set; }
        public bool IsInfectado1 { get; set; }
        public bool IsDescubierto1 { get; set; }
        public bool IsInfectado2 { get; set; }
        public bool IsDescubierto2 { get; set; }
        public bool IsInfectado3 { get; set; }
        public bool IsDescubierto3 { get; set; }
        public bool IsMuerto { get; set; }

        public bool DeboHacerRevision { get; set; }
        public bool DeboEstarCuarentena { get; set; }
        public bool DeboInfectar1 { get; set; }
        public bool DeboInfectar2 { get; set; }
        public bool DeboInfectar3 { get; set; }
        public Virus NuevoVirus { get; set; }

        public Ciudad()
        { }
        public Ciudad(string nombre, int poblacion, int ingresos, bool isCuarentena, bool isInfectado1, bool isInfectado2, bool isInfectado3, bool isMuerto)
        {
            this.Nombre = nombre;
            this.Poblacion = poblacion;
            this.Ingresos = ingresos;
            this.IsCuarentena = isCuarentena;
            this.IsInfectado1 = isInfectado1;
            this.IsInfectado2 = isInfectado2;
            this.IsInfectado3 = isInfectado3;
            this.IsMuerto = isMuerto;
        }
        public Ciudad(string nombre, int poblacion, int ingresos,int pais)
        {
            this.Nombre = nombre;
            this.Poblacion = poblacion;
            this.Ingresos = poblacion * 3;
            this.Pais = pais;
            this.IsCuarentena = false;
            this.IsInfectado1 = false;
            this.IsDescubierto1 = false;
            this.IsInfectado2 = false;
            this.IsDescubierto2 = false;
            this.IsInfectado3 = false;
            this.IsDescubierto3 = false;
            this.IsMuerto = false;
        }
    }
    

    public class Virus
    {
        public Virus(string nombre,int coste, int muertesPorMes, int expansionesPorMes)
        {
            Nombre = nombre;
            Coste = coste;
            MuertesPorMes = muertesPorMes;
            ExpansionesPorMes = expansionesPorMes;
        }
        public Virus(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    Nombre = "Ebola";
                    Coste = 10000000;
                    MuertesPorMes = 20000;
                    ExpansionesPorMes = 1;
                    break;
                case 2:
                    Nombre = "Covid-19";
                    Coste = 30000000;
                    MuertesPorMes = 40000;
                    ExpansionesPorMes = 2;
                    break;
                case 3:
                    Nombre = "Peste";
                    Coste = 50000000;
                    MuertesPorMes = 120000;
                    ExpansionesPorMes = 3;
                    break;
            }
                
        }

        public string Nombre { get; set; }
        public int Coste { get; set; }
        public int MuertesPorMes { get; set; }
        public int ExpansionesPorMes { get; set; }
    }
    static void Function(int i)
    { }
    static Virus virus1 = new Virus("Ebola",10000,20000,1);
    static Virus virus2 = new Virus("Coronavirus",30000,40000,2);
    static Virus virus3 = new Virus("SARS",50000,120000,3);
}
