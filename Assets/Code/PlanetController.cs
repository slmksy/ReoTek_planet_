using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public class PlanetController
    {
		#region Constants

		#endregion

		#region Fields

		#endregion

		#region Constructors
		public PlanetController()
		{
		}
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		public void AddPlanet(GameObject gameObject) 
		{
			Planet planet = new Planet();
			planet.SetPlanetGameObject(gameObject);
			planet.SetPlanetGameObject(gameObject);
			planet.MaxSatelliteCount = 5;

			PlanetModel.Instance.AddPlanet(planet);

		}

		public void AddSatelittePlanet(GameObject gameObject)
		{
			SatellitePlanet satellitePlanet = new SatellitePlanet();
			satellitePlanet.SetPlanetGameObject(gameObject);
			satellitePlanet.Speed = 20f;

			var nearPlanet = FindNearPlanet(gameObject.transform.position);
			if (nearPlanet != null) 
			{
				satellitePlanet.SetParentPlanet(nearPlanet);
				nearPlanet.AddSatelitte(satellitePlanet);
			}
			
		}

		public void UpdatePlanets()
		{
			foreach (var planet in PlanetModel.Instance.Planets)
			{
				planet.Update();
			}
		}


		#endregion

		#region Private Methods
		public bool IsAnyPlanetHavePlace()
		{
			foreach (var planet in PlanetModel.Instance.Planets)
			{
				if(planet.GetSatelitteCount() < planet.MaxSatelliteCount) 
				{
					return true;
				}
			}

			return false;
		}

		private Planet FindNearPlanet(Vector3 satellitePos) 
		{
			float bestDistance = float.MaxValue;
			Planet nearPlanet = null;

			foreach (var planet in PlanetModel.Instance.Planets)
			{
				var planetPos = planet.GetPosition();
				var distace = Vector3.Distance(planetPos, satellitePos);
				distace = Math.Abs(distace);

				if (planet.MaxSatelliteCount > planet.GetSatelitteCount() &&
					distace < bestDistance)
				{
					bestDistance = distace;
					nearPlanet = planet;
				}
			}

			return nearPlanet;			
		}
		#endregion

		#region Protected Methods

		#endregion

		#region Events

		#endregion
	}
}
