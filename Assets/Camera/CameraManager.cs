using cakeslice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static Action<CameraTypes, Transform> cameraSwitchEvent;

    private InputHandler controller;
    private Outline highLighted;

    private void Awake() {
        controller = new InputHandler();
        controller.CameraControls.Enable();

        controller.CameraControls.SelectSpectate.performed += ctx => OnClickHighlight();
        controller.CameraControls.ExitSpectate.performed += ctx => OnExitSpectate();
    }

    /// <summary>
    /// Switches the camera back to the first person camera.
    /// </summary>
    private void OnExitSpectate() {
        if (this.transform.parent == null)
            return;

        Transform parent = this.transform.parent;
        this.transform.parent = null;
        Destroy(parent.gameObject);

        cameraSwitchEvent(CameraTypes.FIRST_PERSON, null);
    }

    /// <summary>
    /// Puts the user into spectator mode.
    /// </summary>
    private void OnClickHighlight() {
        if (highLighted == null)
            return;

        cameraSwitchEvent(CameraTypes.SPECTATOR, highLighted.transform);
    }

    /// <summary>
    /// We use the fixed update to check if the user's cursor is currently on a spectateable object.
    /// </summary>
    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(controller.CameraControls.ScreenPosition.ReadValue<Vector2>());

        if(Physics.Raycast(ray, out RaycastHit hit)) {
            if (highLighted != null && highLighted.transform == hit.transform)
                return;

            if(highLighted != null)
                Destroy(highLighted);

            highLighted = hit.transform.gameObject.AddComponent<Outline>();
        } else {
            if (highLighted != null)
                Destroy(highLighted);

            highLighted = null;
        }
    }

    private void OnDisable() {
        controller.CameraControls.Disable();
    }

}
