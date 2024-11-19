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
    [SerializeField] private GameObject globitoAlimentar;
    [SerializeField] private GameObject globitoAcariciar;
    [SerializeField] private GameObject globitoBaniar;
    [SerializeField] private GameObject globitoSanar;

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

            case "corgi":
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
        if (alimentar == true)
        {
            globitoAlimentar.SetActive(true);
        }
        else
        {
            globitoAlimentar.SetActive(false);
        }

        if (acariciar == true)
        {
            globitoAcariciar.SetActive(true);
        }
        else
        {
            globitoAcariciar.SetActive(false);
        }

        if (baniar == true)
        {
            globitoBaniar.SetActive(true);
        }
        else
        {
            globitoBaniar.SetActive(false);
        }

        if (sanar == true)
        {
            globitoSanar.SetActive(true);
        }
        else
        {
            globitoSanar.SetActive(false);
        }
    }

}
