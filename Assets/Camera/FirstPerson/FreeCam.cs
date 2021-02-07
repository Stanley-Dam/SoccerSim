using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : PlayerCamera {

    [SerializeField] private bool isActive = true;

    private InputHandler controls;
    private bool mouseLookActive = false;

    private void Awake() {
        CameraManager.cameraSwitchEvent += OnCameraSwitch;
        controls = new InputHandler();

        if(isActive)
            EnableInput();
    }

    private void OnCameraSwitch(CameraTypes cameraType, Transform transform) {
        if (cameraType == CameraTypes.FIRST_PERSON & !controls.CameraControls.enabled)
            EnableInput();
        else if(isActive)
            controls.CameraControls.Disable();
    }

    private void EnableInput() {
        controls.CameraControls.Enable();

        controls.CameraControls.ActivateMouseLook.performed += ctx => mouseLookActive = true;
        controls.CameraControls.ActivateMouseLook.canceled += ctx => mouseLookActive = false;
    }

    private void OnDisable() {
        controls.CameraControls.Disable();
        CameraManager.cameraSwitchEvent -= OnCameraSwitch;
    }

    private void Update() {
        Vector2 direction = controls.CameraControls.Movement.ReadValue<Vector2>();
        transform.Translate(new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime);

        if (!mouseLookActive)
            return;

        float newRotationX = transform.localEulerAngles.y + controls.CameraControls.MouseLook.ReadValue<Vector2>().x * sensitivity;
        float newRotationY = transform.localEulerAngles.x - controls.CameraControls.MouseLook.ReadValue<Vector2>().y * sensitivity;

        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
    }
}
