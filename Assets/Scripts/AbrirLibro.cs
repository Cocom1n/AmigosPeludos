using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLibro : MonoBehaviour
{
    [SerializeField] private GameObject PanelLibro;
    [SerializeField] private GameObject PanelPrincipal;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AbirLibro()
    {
        PanelLibro.SetActive(true);
        PanelPrincipal.SetActive(false);
    }

    public void CerrarLibro()
    {
        PanelLibro.SetActive(false);
        PanelPrincipal.SetActive(true);
    }
}
