using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    #region Constants

    #endregion

    #region Fields
    private PlanetController planetController;
    private Vector3 clikedLoc;
    public GameObject planetObj;
    public GameObject satelitteObj;
    #endregion

    #region Constructors
    public PlanetGenerator() 
    {
        planetController = new PlanetController();
    }
    #endregion

    #region Properties

    #endregion

    #region Public Methods
    public void Update()
    {     
        if (Input.GetButtonDown("Fire1"))
        {
            SetLocation(Input.mousePosition);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            CreatePlanet();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CreateSatelitte();
        }

        planetController.UpdatePlanets();
    }


    #endregion

    #region Private Methods
    private void CreateSatelitte()
    {
        if (clikedLoc != null && planetController.IsAnyPlanetHavePlace())
        {
            var gameObject = GameObject.Instantiate(satelitteObj, clikedLoc, Quaternion.identity);
            planetController.AddSatelittePlanet(gameObject);
        }
    }

    private void CreatePlanet()
    {
        if (clikedLoc != null )
        {
            var gameObject = GameObject.Instantiate(planetObj, clikedLoc, Quaternion.identity);
            planetController.AddPlanet(gameObject);
        }
    }

    private void SetLocation(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        clikedLoc = hit.point;
        clikedLoc.y = 0.5f;
    }

    private RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
    #endregion

    #region Protected Methods

    #endregion

    #region Events

    #endregion










}
