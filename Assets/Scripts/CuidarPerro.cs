using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuidarPerro : MonoBehaviour
{
    [SerializeField] private GameObject perro;
    private LayerMask layer;
    [SerializeField] private Camera aRCamera;
    private Animator animacionPerro;
    private bool hacerCosas;

    void Start()
    {
        layer = LayerMask.GetMask("dog");
        hacerCosas = true;
    }
    void Update()
    {
        // Detectar el toque en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // Obtener el primer toque
            if (touch.phase == TouchPhase.Began)  // Cuando el toque comienza
            {
                // Convertir la posición del toque a un punto en el mundo 3D
                Ray ray = aRCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Hacer el raycast
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
                {
                    // Si el raycast golpea el perro (el objeto con el collider)
                    Debug.Log("ME TOCASTE :O");
                    DogAction(hit.transform.gameObject);  // Llamar a la acción en el perro

                }
            }
        }
    }

    public void Alimentar()
    {
        if (perro.GetComponent<Necesidades>().alimentar == true && hacerCosas == true)
        {
            hacerCosas = false;
            Debug.Log("Perro come jaja");
            StartCoroutine(animaciones(5));
            perro.GetComponent<Necesidades>().alimentar = false;
        }
        else
        {
            Debug.Log("Perro sin hambre, perro feliz");
        }
    }

    public void Bañar()
    {
        if (perro.GetComponent<Necesidades>().baniar == true && hacerCosas == true)
        {
            Debug.Log("Limpioo");
            perro.GetComponent<Necesidades>().baniar = false;
            hacerCosas = false;
            StartCoroutine(animaciones(6));
        }
        else
        {
            Debug.Log("Perro limpio, perro feliz");
        }
    }

    public void Curar()
    {
        if (perro.GetComponent<Necesidades>().sanar == true && hacerCosas == true)
        {
            Debug.Log("sano");
            perro.GetComponent<Necesidades>().sanar = false;
            hacerCosas = false;
            StartCoroutine(animaciones(7));
        }
        else
        {
            Debug.Log("Perro sano, perro feliz");
        }
    }

    public void Acariciar()
    {
        if (perro.GetComponent<Necesidades>().acariciar == true && hacerCosas == true)
        {
            Debug.Log("Buen perrito");
            hacerCosas = false;
            StartCoroutine(animaciones(1));
            perro.GetComponent<Necesidades>().acariciar = false;
        }
        else
        {
            Debug.Log("Perro acariciado, perro feliz");
        }
    }

    private void DogAction(GameObject dog)
    {
        perro = dog;
        animacionPerro = perro.GetComponent<Animator>();
    }

    IEnumerator animaciones(int numeroID)
    {
        animacionPerro.SetInteger("AnimationID", numeroID);
        yield return new WaitForSeconds(2f);
        animacionPerro.SetInteger("AnimationID", 0);
        hacerCosas = true;
    }
}
