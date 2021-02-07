using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SpectatorCamera : PlayerCamera {

    [SerializeField] private float cameraDistance = 5f;
    [SerializeField] private float transitionDuration = 3f;
    [SerializeField] private bool isActive = false;

    private InputHandler controls;
    private bool mouseLookActive = false;

    private Vector2 look = new Vector2();

    private void Awake() {
        CameraManager.cameraSwitchEvent += OnCameraSwitch;
        controls = new InputHandler();

        if (isActive)
            EnableInput();
    }

    private void OnCameraSwitch(CameraTypes cameraType, Transform transform) {
        if (cameraType == CameraTypes.SPECTATOR) {

            if(this.transform.parent != null) {
                Transform parent = this.transform.parent;
                this.transform.parent = null;
                Destroy(parent.gameObject);
            }
            
            EnableInput();
            SetObjectToSpectate(transform.root);

        } else if (controls.CameraControls.enabled)
            controls.CameraControls.Disable();
    }

    private void EnableInput() {
        controls.CameraControls.Enable();

        controls.CameraControls.ActivateMouseLook.performed += ctx => mouseLookActive = true;
        controls.CameraControls.ActivateMouseLook.canceled += ctx => mouseLookActive = false;
    }

    private void Update() {
        if (!mouseLookActive)
            return;

        look.y += controls.CameraControls.MouseLook.ReadValue<Vector2>().x * sensitivity;
        look.x += controls.CameraControls.MouseLook.ReadValue<Vector2>().y * sensitivity;

        look.x = Mathf.Clamp(look.x, -80, 0);
        transform.parent.localEulerAngles = new Vector3(0f, look.y, look.x);
    }

    private void OnDisable() {
        controls.CameraControls.Disable();
        CameraManager.cameraSwitchEvent -= OnCameraSwitch;
    }

    public void SetObjectToSpectate(Transform transformToFollow) {
        Transform parent = Instantiate(new GameObject()).transform;
        parent.parent = transformToFollow;
        parent.localPosition = Vector3.zero;
        parent.eulerAngles = Vector3.zero;
        this.transform.parent = parent;

        StartCoroutine(Transition());
    }

    private IEnumerator Transition() {
        float elapsedTime = 0;
        Vector3 oldPosition = this.transform.position;
        look = Vector2.zero;

        controls.CameraControls.Disable();

        while (elapsedTime < transitionDuration) {
            if (this.transform.parent == null) 
                break;

            this.transform.position = Vector3.Lerp(oldPosition, this.transform.parent.position + Vector3.left * cameraDistance, (elapsedTime / transitionDuration));
            this.transform.LookAt(this.transform.parent.position);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if(this.transform.parent != null)
            controls.CameraControls.Enable();

        yield return null;
    }

}
