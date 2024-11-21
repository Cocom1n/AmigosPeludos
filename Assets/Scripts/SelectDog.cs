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

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = aRCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, dogLayer))
                {
                    DogAction(hit.transform.gameObject);
                    Debug.Log("ME TOCASTE :O");
                }
            }
        }
    }

    private void DogAction(GameObject dog)
    {
        if (actionsVisible == false)
        {
            actions.SetActive(true);
            actionsVisible = true;
        }
        else if (actionsVisible == true) 
        {
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
