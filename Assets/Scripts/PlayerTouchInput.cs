using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerTouchInput : MonoBehaviour
{
    private InputManager _inputManager;
    private Camera _camera;

    private void Awake()
    {
        _inputManager = gameObject.AddComponent<InputManager>();
        _camera = Camera.main;

        Debug.Log("PlayerTouchINPUTAWAKE?");
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Debug.Log("Move called!");
        Vector3 screenCoords = new Vector3(screenPosition.x, screenPosition.y, GetComponent<Camera>().nearClipPlane);
        Vector3 worldCoords = Camera.main.ScreenToWorldPoint(screenCoords);
        worldCoords.z = 0;
        gameObject.transform.position = worldCoords;
    }
}
