using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public abstract class BasePlanet : IPlanet
    {
		#region Constants

		#endregion

		#region Fields

		#endregion

		#region Constructors

		#endregion

		#region Properties
		public float Speed 
		{
			get;
			set;
		}

		public GameObject PlanetObject
		{
			get;
			protected set;
		}

		#endregion

		#region Public Methods
		public void SetPlanetGameObject(GameObject gameObject)
		{
			PlanetObject = gameObject;
		}

        public virtual void Update()
        {
           
        }

		public Vector3 GetPosition() 
		{
			return PlanetObject.transform.position;
		}

		public void SetPosition(Vector3 pos) 
		{
			PlanetObject.transform.position = pos;
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
