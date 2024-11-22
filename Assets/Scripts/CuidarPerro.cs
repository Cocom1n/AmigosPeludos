using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
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
        aRCamera = GameObject.Find("XR Origin").GetComponentInChildren<Camera>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = aRCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
                {
                    DogAction(hit.transform.gameObject);

                }
            }
        }
    }

    public void Alimentar()
    {
        if (perro.GetComponent<Necesidades>().alimentar == true && hacerCosas == true)
        {
            hacerCosas = false;
            StartCoroutine(animaciones(5));
            perro.GetComponent<Necesidades>().alimentar = false;
        }
    }

    public void Bañar()
    {
        if (perro.GetComponent<Necesidades>().baniar == true && hacerCosas == true)
        {
            perro.GetComponent<Necesidades>().baniar = false;
            hacerCosas = false;
            StartCoroutine(animaciones(6));
        }
    }

    public void Curar()
    {
        if (perro.GetComponent<Necesidades>().sanar == true && hacerCosas == true)
        {
            perro.GetComponent<Necesidades>().sanar = false;
            hacerCosas = false;
            StartCoroutine(animaciones(7));
        }
    }

    public void Acariciar()
    {
        if (perro.GetComponent<Necesidades>().acariciar == true && hacerCosas == true)
        {
            hacerCosas = false;
            StartCoroutine(animaciones(1));
            perro.GetComponent<Necesidades>().acariciar = false;
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
