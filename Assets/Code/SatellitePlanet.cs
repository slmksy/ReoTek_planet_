using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public class SatellitePlanet : BasePlanet
    {
		#region Constants

		#endregion

		#region Fields
		private Planet parentPlanet;
		private Vector3 rotateVector = new Vector3(0, 1, 0);
		#endregion

		#region Constructors
		public SatellitePlanet()
		{ 
		}
		#endregion

		#region Properties
		public Planet ParentPlanet
		{
			get { return parentPlanet; }
			private set { parentPlanet = value; }
		}
		#endregion

		#region Public Methods
		public void SetParentPlanet(Planet planet) 
		{
			ParentPlanet = planet;
			rotateVector = planet.GetPosition();
		}
		public override void Update() 
		{
			PlanetObject.transform.RotateAround(rotateVector, Vector3.up, Speed * Time.deltaTime);
			MoveToParent();
		}
		#endregion

		#region Private Methods
		private void MoveToParent() 
		{
			float diff = 0.0001f;
			List<Tuple<float, Vector3>> dictDist = new List<Tuple<float, Vector3>>();

			var vec1 = new Vector3(GetPosition().x - diff, GetPosition().y, GetPosition().z - diff);
			var dist1 = Vector3.Distance(parentPlanet.GetPosition(), vec1);
			dist1 = Math.Abs(dist1);
			dictDist.Add(new Tuple<float, Vector3>(dist1, vec1));

			var vec2 = new Vector3(GetPosition().x - diff, GetPosition().y, GetPosition().z + diff);
			var dist2 = Vector3.Distance(parentPlanet.GetPosition(), vec2);
			dist2 = Math.Abs(dist2);
			dictDist.Add(new Tuple<float, Vector3>(dist2, vec2));

			var vec3 = new Vector3(GetPosition().x + diff, GetPosition().y, GetPosition().z + diff);
			var dist3 = Vector3.Distance(parentPlanet.GetPosition(), vec3);
			dist3 = Math.Abs(dist3);
			dictDist.Add(new Tuple<float, Vector3>(dist3, vec3));

			var vec4 = new Vector3(GetPosition().x + diff, GetPosition().y, GetPosition().z - diff);
			var dist4 = Vector3.Distance(parentPlanet.GetPosition(), vec4);
			dist4 = Math.Abs(dist4);
			dictDist.Add(new Tuple<float, Vector3>(dist4, vec4));

			float minDist = float.MaxValue;
			Vector3 newPos = GetPosition();
			foreach (var dist in dictDist)
			{
				if (dist.Item1 < minDist)
				{
					minDist = dist.Item1;
					newPos = dist.Item2;
				}
			}

			SetPosition(newPos);
		}
		#endregion

		#region Protected Methods

		#endregion

		#region Events

		#endregion
	}
}
