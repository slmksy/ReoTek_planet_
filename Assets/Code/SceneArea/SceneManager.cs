using Assets.Code;
using Assets.Code.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    #region Constants

    #endregion

    #region Fields 
    private PlanetController planetController;
    public GameObject planetObj;
    public GameObject satelitteObj;
   
   
    #endregion

    #region Constructors
    public SceneManager() 
    {
        planetController = new PlanetController();
        
    }
    #endregion

    #region Properties

    #endregion

    #region Public Methods
    public void Start()
    {
        SceneEventController.OnPlanetClicked += OnPlanetClicked;
        SceneEventController.OnMaxSatelitteInputTextChanged += OnMaxSatelitteInputTextChanged;
        SceneEventController.OnCreatePlanet += OnCreatePlanet;
        SceneEventController.OnCreateSatelittePlanet += OnCreateSatelittePlanet;
        SceneEventController.OnBtnDeleteClicked += OnBtnDeleteClicked;
        ColliderDetector.OnCollision += ColliderDetector_OnCollision;
    }

    private void ColliderDetector_OnCollision(GameObject mainObject, GameObject otherObject)
    {
        var satellite = planetController.AskConnectedObjects(mainObject, otherObject);
        if(satellite != null) 
        {         
            satellite.ParentPlanet.RemoveSatelitte(satellite);
            

            if(satellite.ParentPlanet.GetSatelitteCount() == 0) 
            {
                Destroy(satellite.ParentPlanet.PlanetObject);
            }
            
            Destroy(otherObject);
        }
    }

    public void Update()
    {     
        planetController.UpdatePlanets();
    }

    #endregion

    #region Private Methods
    private void ChangeUiCanvasVisiblility(GameObject uiCanvas) 
    {
        uiCanvas.SetActive(!uiCanvas.activeSelf);       
    }

    #endregion

    #region Protected Methods

    #endregion

    #region Events
    private void OnCreatePlanet(Vector3 clikedLoc)
    {
        if (clikedLoc != null)
        {
            var planet = GameObject.Instantiate(planetObj, clikedLoc, Quaternion.identity);
            var planetRenderer = planet.GetComponent<Renderer>();

            System.Random rnd = new System.Random();
            planetRenderer.material.SetColor("_Color", planetController.GetRandomColor());
            planetController.AddPlanet(planet);
        }
    }

    private void OnCreateSatelittePlanet(Vector3 clikedLoc)
    {
        if (clikedLoc != null && planetController.IsAnyPlanetHavePlace())
        {
            Debug.Log(satelitteObj.name);
            var satelitte = GameObject.Instantiate(satelitteObj, clikedLoc, Quaternion.identity);
            var satelliteRenderer = satelitte.GetComponent<Renderer>();

            System.Random rnd = new System.Random();
            satelliteRenderer.material.SetColor("_Color", planetController.GetRandomColor());
            planetController.AddSatelittePlanet(satelitte);
        }
    }

    public void OnMaxSatelitteInputTextChanged(GameObject clickedObj, string inputText)
    {    
        int outVal;
        var isParsed = int.TryParse(inputText, out outVal);
        if (isParsed) 
        {
            Debug.Log(outVal.ToString());
            planetController.SetPlanetMaxSatellite(clickedObj, outVal);
        }
    }

    public void OnPlanetClicked(GameObject clickedObj, GameObject uiCanvas, InputField inputMaxSatellite )
    {
        ChangeUiCanvasVisiblility(uiCanvas);
        if (uiCanvas.activeSelf)
        {
            var maxSatellite = planetController.GetPlanetMaxSatellite(clickedObj);
            inputMaxSatellite.text = maxSatellite.ToString();
        }
    }

    private void OnBtnDeleteClicked(GameObject planet, GameObject uiCanvas)
    {
        foreach(var satellite in planetController.GetSatellites(planet)) 
        {
            Destroy(satellite.PlanetObject);
        }

        planetController.DeletePlanet(planet);
        Destroy(planet);

        ChangeUiCanvasVisiblility(uiCanvas);
    }
    #endregion










}
