using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public class PlanetModel
    {
		#region Constants

		#endregion

		#region Fields
		private static PlanetModel instance = null;
		private List<Planet> planetList;
		#endregion

		#region Constructors
		private PlanetModel()
		{
			planetList = new List<Planet>();
		}
		#endregion

		#region Properties
		public static PlanetModel Instance 
		{
            get 
			{
				if (instance == null) 
				{
					instance = new PlanetModel();
				}

				return instance;
			}
		}

		public ReadOnlyCollection<Planet> Planets 
		{
            get 
			{
				return planetList.AsReadOnly();
			}
		}
		#endregion

		#region Public Methods
		public void AddPlanet(Planet planet) 
		{
			planetList.Add(planet);
		}

		public void RemovePLanet(Planet planet)
		{
			planetList.Remove(planet);
		}

		public Planet GetNearPlanet(Vector3 position) 
		{
			float bestDistance = float.MaxValue;
			Planet nearPlanet = null;

			foreach (var planet in planetList) 
			{
				var planetPos = planet.PlanetObject.transform.position;
				var distace = Vector3.Distance(planetPos, position);
				distace = Math.Abs(distace);

				if (distace < bestDistance) 
				{
					bestDistance = distace;
					nearPlanet = planet;
				}
			}

			return nearPlanet;
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
