using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adopcion : MonoBehaviour
{
    [SerializeField] private GameObject perro;
    [SerializeField] private GameObject adoptado;
    [SerializeField] private Button adopcion;

    void Start()
    {
        adopcion.interactable = false;
    }

    void Update()
    {
        if (perro.GetComponent<Necesidades>().alimentar == false &&
            perro.GetComponent<Necesidades>().acariciar == false &&
            perro.GetComponent<Necesidades>().baniar == false &&
            perro.GetComponent<Necesidades>().sanar == false)
        {
            adopcion.interactable = true;
        }
    }

    public void Adoptar()
    {
        adoptado.SetActive(true);
    }
}
