namespace d4160.Systems.XRCameraRig
{
    using UnityEngine;

    public class XRSetup : MonoBehaviour
    {
        public bool xrActived;
        [Header("SETTINGS")]
        public Transform cameraRig;
        public XRSimulator xrSimulator;
        [Tooltip("Correct camerra height for stationary experience")]
        public SetCorrectCameraHeight correctCameraHeight;
        public Camera xrCamera;
        [Range(30, 120)]
        public int xrFieldOfView = 90;
        [Range(30, 120)]
        public int noXRFieldOfView = 60;
        public HandInputBase leftHandInput;
        public HandInputBase rightHandInput;

        private bool _xrActived;

        private void Awake()
        {
            SetActiveXR(xrActived);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SetActiveXR(!_xrActived);
            }
        }

        public void SetActiveXR(bool active)
        {
            _xrActived = active;

            if (xrSimulator)
            {
                xrSimulator.SetActive(!active);
                xrSimulator.enabled = !active;
            }

            if (correctCameraHeight)
            {
                correctCameraHeight.enabled = active;

                if (active && cameraRig)
                    correctCameraHeight.SetCameraHeight(cameraRig.position.y);
            }

            if (leftHandInput)
                leftHandInput.enabled = active;
            if (rightHandInput)
                rightHandInput.enabled = active;

            if (xrCamera)
                xrCamera.fieldOfView = active ? xrFieldOfView : noXRFieldOfView;
        }
    }
}