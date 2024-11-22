using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPerro : MonoBehaviour
{
    [SerializeField] private GameObject perro;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float velocidad;
    [SerializeField] private float rotacionVelocidad = 2f;
    [SerializeField] private Camera aRCamera;
    private LayerMask dogLayer;
    private Animator animacionPerro;

    private bool isMoving = false;
    private int currentPointIndex = 0;
    private bool isWaiting = false;

    void Start()
    {
        if (puntos.Length > 0)
        {
            MoveToNextPoint();
        }
        dogLayer = LayerMask.GetMask("dog");
        aRCamera = GameObject.Find("XR Origin").GetComponentInChildren<Camera>();
        animacionPerro = perro.GetComponent<Animator>();
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
                    if (isMoving)
                    {
                        isMoving = false;
                        animacionPerro.SetInteger("AnimationID", 0);
                    }
                    else
                    {
                        isMoving = true;
                        animacionPerro.SetInteger("AnimationID", 2);
                        MoveTowardsPoint(puntos[currentPointIndex]);
                    }
                }
            }
        }

        if (isMoving && puntos.Length > 0 && !isWaiting)
        {
            MoveTowardsPoint(puntos[currentPointIndex]);
        }
    }

    void MoveToNextPoint()
    {
        if (puntos.Length == 0) return;

        currentPointIndex = 0;
        isMoving = true;
    }

    void MoveTowardsPoint(Transform target)
    {
        Vector3 direction = target.position - perro.transform.position;
        direction.y = 0;

        if (direction.magnitude > 0.1f)
        {
            perro.transform.position = Vector3.MoveTowards(perro.transform.position, target.position, velocidad * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            perro.transform.rotation = Quaternion.Slerp(perro.transform.rotation, targetRotation, rotacionVelocidad * Time.deltaTime);
        }
        else
        {
            StartCoroutine(EsperarAntesDeMover());
        }
    }

    private IEnumerator EsperarAntesDeMover()
    {
        isWaiting = true;
        animacionPerro.SetInteger("AnimationID", 0);
        yield return new WaitForSeconds(2f);

        if (isMoving)
        {
            isWaiting = false;
            currentPointIndex = (currentPointIndex + 1) % puntos.Length;
            animacionPerro.SetInteger("AnimationID", 2);
        }
        else
        {
            isWaiting = false;
        }

    }

    IEnumerator animaciones(int numeroID)
    {
        animacionPerro.SetInteger("AnimationID", numeroID);
        yield return null;
    }
}
