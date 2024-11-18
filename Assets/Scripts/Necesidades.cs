using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Necesidades : MonoBehaviour
{
    public bool alimentar;
    public bool acariciar;
    public bool baniar;
    public bool sanar;
    public string nombre;

    void Start()
    {
        switch (nombre)
        {
            case "frank":
                alimentar = true;
                acariciar = true;
                baniar = true;
                sanar = true;
                break;

            case "mike":
                alimentar = false;
                acariciar = true;
                baniar = false;
                sanar = false;
                break;

            case "papu":
                alimentar = true;
                acariciar = true;
                baniar = true;
                sanar = true;
                break;

            case "mimitchi":
                alimentar = false;
                acariciar = false;
                baniar = true;
                sanar = false;
                break;

            case "perro":
                alimentar = true;
                acariciar = false;
                baniar = true;
                sanar = true;
                break;
        }
    }
    void Update()
    {
        
    }

}
