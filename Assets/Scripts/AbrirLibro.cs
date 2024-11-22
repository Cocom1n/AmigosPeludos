using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLibro : MonoBehaviour
{
    [SerializeField] private GameObject PanelLibro;
    [SerializeField] private GameObject PanelPrincipal;
    [SerializeField] private AudioSource hoja;

    public void AbirLibro()
    {
        PanelLibro.SetActive(true);
        hoja.Play();
        PanelPrincipal.SetActive(false);
    }

    public void CerrarLibro()
    {
        PanelLibro.SetActive(false);
    }
}
