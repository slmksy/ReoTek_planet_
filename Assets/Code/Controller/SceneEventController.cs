using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Controller
{
    public class SceneEventController : MonoBehaviour
    {
        #region Constants

        #endregion

        #region Fields
        public InputField inputMaxSatellite;
        public Button btnDelete;
        public GameObject uiCanvas;

        private Vector3 clikedLoc;
        private GameObject lastClickedObj;

        public static event Action<GameObject, GameObject> OnBtnDeleteClicked;
        public static event Action<GameObject,GameObject, InputField> OnPlanetClicked;
        public static event Action<GameObject, string> OnMaxSatelitteInputTextChanged;
        public static event Action<Vector3> OnCreatePlanet;
        public static event Action<Vector3> OnCreateSatelittePlanet;
        #endregion

        #region Constructors
        public SceneEventController() 
        {
        }
        #endregion

        #region Properties

        #endregion

        #region Public Methods
        public void Start()
        {
            inputMaxSatellite.onValueChanged.AddListener(delegate 
            { 
                OnMaxSatelitteInputTextChanged?.Invoke(lastClickedObj, inputMaxSatellite.text); 
            });

            btnDelete.onClick.AddListener(delegate
            {
                OnBtnDeleteClicked?.Invoke(lastClickedObj, uiCanvas);
            });
        }


        public void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (IsPlaneClicked(Input.mousePosition))
                {
                    SetLocation(Input.mousePosition);
                }
                if (IsPlanetClicked(Input.mousePosition))
                {
                    OnPlanetClicked?.Invoke(lastClickedObj, uiCanvas, inputMaxSatellite);                
                }
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                OnCreatePlanet?.Invoke(clikedLoc);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                OnCreateSatelittePlanet?.Invoke(clikedLoc);              
            }
        }

        private bool IsPlaneClicked(Vector2 mousePosition)
        {
            var hit = GetRaycastHit(mousePosition);
            if (hit.collider == null)
            {
                return false;
            }

            var obj = hit.collider.gameObject;
            return (obj.Equals(gameObject));
        }

        private bool IsPlanetClicked(Vector2 mousePosition)
        {
            var hit = GetRaycastHit(mousePosition);
            if (hit.collider == null)
            {
                return false;
            }

            var obj = hit.collider.gameObject;
            lastClickedObj = obj;

            return (obj.name.Contains("Planet"));
        }

        private void SetLocation(Vector2 mousePosition)
        {
            var hit = GetRaycastHit(mousePosition);
            clikedLoc = hit.point;
            clikedLoc.y = 3f;
        }

        private RaycastHit GetRaycastHit(Vector2 mousePosition)
        {
            return RayFromCamera(mousePosition, 1000.0f);
        }

        private RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
        {
            RaycastHit hit;           
            var ray = Camera.main.ScreenPointToRay(mousePosition);
            Physics.Raycast(ray, out hit, rayLength);

            return hit;
        }
        #endregion

        #region Private Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Events

        #endregion


    }
}
