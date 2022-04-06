using Assets.Code.Controller;
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
		private Colors colors;
		#endregion

		#region Constructors
		public PlanetController()
		{
			colors = new Colors();
		}
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		public Color GetRandomColor() 
		{
			return colors.GetRandomColor();
		}

		public void AddPlanet(GameObject gameObject) 
		{
			Planet planet = new Planet();
			planet.SetPlanetGameObject(gameObject);
			
			planet.MaxSatelliteCount = 5;

			PlanetModel.Instance.AddPlanet(planet);
		}

		public void DeletePlanet(GameObject gameObject) 
		{
			var planet = PlanetModel.Instance.Planets.First(t => t.PlanetObject.Equals(gameObject));			
			PlanetModel.Instance.RemovePLanet(planet);
		}

		public IReadOnlyCollection<SatellitePlanet> GetSatellites(GameObject gameObject) 
		{
			var planet = PlanetModel.Instance.Planets.First(t => t.PlanetObject.Equals(gameObject));
			return planet.GetSatellites();
		}

		public SatellitePlanet? AskConnectedObjects(GameObject mainObject, GameObject otherObject )
		{
			var planets = PlanetModel.Instance.Planets;
            if (planets.Any(t=>t.PlanetObject.Equals(mainObject))) 
			{
				var planet = planets.First(t => t.PlanetObject.Equals(mainObject));
				if(planet.GetSatellites().Any(t => t.PlanetObject.Equals(otherObject))) 
				{
					return planet.GetSatellites().First(t => t.PlanetObject.Equals(otherObject)); 
				}
			}
			Debug.Log("null");
			return null;
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

		public void SetPlanetMaxSatellite(GameObject gameObject, int maxCount) 
		{
			foreach(var planet in PlanetModel.Instance.Planets) 
			{
                if (planet.PlanetObject.Equals(gameObject)) 
				{
					Debug.Log("object found");
					planet.MaxSatelliteCount = maxCount;
				}
			}
		}

		public int GetPlanetMaxSatellite(GameObject gameObject) 
		{
			if(PlanetModel.Instance.Planets.Any(t => t.PlanetObject.Equals(gameObject)))
			{
				var planet = PlanetModel.Instance.Planets.First(t => t.PlanetObject.Equals(gameObject));
				return planet.MaxSatelliteCount;
			}

			return 0;		
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
				if(planet.PlanetObject == null) 
				{
					continue;
				}
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
