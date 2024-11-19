using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDog : MonoBehaviour
{
    [SerializeField] private GameObject actions;
    [SerializeField] private bool actionsVisible;
    [SerializeField] private Camera aRCamera;
    private LayerMask dogLayer;

    void Start()
    {
        dogLayer = LayerMask.GetMask("dog");
        actionsVisible = false;
        aRCamera = GameObject.Find("XR Origin").GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
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
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, dogLayer))
                {
                    // Si el raycast golpea el perro (el objeto con el collider)
                    DogAction(hit.transform.gameObject);  // Llamar a la acción en el perro
                    Debug.Log("ME TOCASTE :O");
                }
            }
        }
    }

    // Acción que se ejecuta cuando se toca el perro
    private void DogAction(GameObject dog)
    {
        if (actionsVisible == false)
        {
            //Debug.Log("¡El perro ha sido tocado!");
            actions.SetActive(true);
            actionsVisible = true;
        }
        else if (actionsVisible == true) 
        {
            //Debug.Log("¡El perro ha sido tocado!");
            actions.SetActive(false);
            actionsVisible = false;
        }

        //// Ejemplo: activar una animación o sonido
        //Animator dogAnimator = dog.GetComponent<Animator>();
        //if (dogAnimator != null)
        //{
        //    dogAnimator.SetTrigger("Bark");  // Activar animación de ladrido (supone que tienes una animación configurada)
        //}

        //// Ejemplo: reproducir un sonido
        //AudioSource audioSource = dog.GetComponent<AudioSource>();
        //if (audioSource != null)
        //{
        //    audioSource.Play();  // Reproducir sonido
        //}
    }
}
