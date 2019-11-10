namespace d4160.Systems.XRCameraRig
{
    using UnityEngine;
    using UnityTemplateProjects;

    [RequireComponent(typeof(SimpleCameraController))]
    public class XRSimulator : MonoBehaviour
    {
        [Header("XR GAME OBJECTS")]
        public Transform cameraRig;
        public Transform leftController;
        public Transform rightController;
        [Header("SIMULATOR INPUTS")]
        public HandInputBase leftHand;
        public HandInputBase rightHand;

        private SimpleCameraController _controller;

        private void Awake()
        {
            _controller = GetComponent<SimpleCameraController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetControllerTarget(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetControllerTarget(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetControllerTarget(2);
            }
        }

        public void SetControllerTarget(int index)
        {
            switch (index)
            {
                case 0:
                    _controller.SetTarget(cameraRig);
                break;
                case 1:
                    _controller.SetTarget(leftController);
                break;
                case 2:
                    _controller.SetTarget(rightController);
                break;
            }
        }

        public void SetActive(bool active)
        {
            leftHand.enabled = active;
            rightHand.enabled = active;

            if(!_controller)
                _controller = GetComponent<SimpleCameraController>();

            _controller.enabled = active;
        }
    }
}