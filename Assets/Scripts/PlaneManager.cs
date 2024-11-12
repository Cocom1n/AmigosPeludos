using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{

    [SerializeField] private ARPlaneManager aRPlaneManager;
    [SerializeField] private GameObject modelPrefab;

    private List<ARPlane> planes = new List<ARPlane>();
    private GameObject modelPlaced;
    // Start is called before the first frame update

    private void OnEnable()
    {
        aRPlaneManager.planesChanged += Planesfound;
    }

    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= Planesfound;

    }

    private void Planesfound(ARPlanesChangedEventArgs planeData)
    {
        if (planeData.added != null && planeData.added.Count > 0) {
            planes.AddRange(planeData.added);
        }

        foreach (var plane in planes) {
            modelPlaced = Instantiate(modelPrefab);
            float offset = modelPlaced.transform.localScale.y / 2;
            modelPlaced.transform.position = new Vector3(plane.center.x,plane.center.y + offset, plane.center.z);
            plane.transform.forward = plane.normal;
            stopPlaneDetection();
        }
    }


    public void stopPlaneDetection()
    {
        aRPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        foreach (var plane in planes) {
            plane.gameObject.SetActive(false);
        }
    }
}
