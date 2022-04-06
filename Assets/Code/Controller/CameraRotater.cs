using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public class CameraRotater : MonoBehaviour
    {
        #region Constants

        #endregion

        #region Fields
        private Vector3 targetPos = new Vector3(1.25f, 1, 1.25f);
        private int degrees = 0;
        private float minFov = 15f;
        private float maxFov = 90f;
        private float sensitivity = 10f;
        #endregion

        #region Constructors
        public CameraRotater() 
        {
        }
        #endregion

        #region Properties

        #endregion

        #region Public Methods
        public void Update()
        {
            RotateCam();
            CamZoom();
        }
        #endregion

        #region Private Methods
        private void RotateCam()
        {
            if (Input.GetMouseButton(1))
            {
                degrees = 10;
                transform.RotateAround(targetPos, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            }
            if (!Input.GetMouseButton(1))
            {
                transform.RotateAround(targetPos, Vector3.up, degrees * Time.deltaTime);
            }
            else
            {
                degrees = 0;
            }
        }

        private void CamZoom()
        {
            var fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
        #endregion

        #region Protected Methods

        #endregion

        #region Events

        #endregion

    }
}
