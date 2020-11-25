using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPreview : MonoBehaviour
{
    [SerializeField] private GameObject _arts = null;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;

        MoveToCursor();

        _arts.SetActive(true);
    }

    private void Update() => MoveToCursor();

    private void MoveToCursor()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (!plane.Raycast(ray, out float distance)) { return; }

        transform.position = ray.GetPoint(distance);
    }
}
