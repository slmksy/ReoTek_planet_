using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public class Planet : BasePlanet
    {
        #region Constants

        #endregion

        #region Fields
        private int maxSatelliteCount;
        private List<SatellitePlanet> satelliteList;
        #endregion

        #region Constructors
        public Planet()
        {
            satelliteList = new List<SatellitePlanet>();
        }
        #endregion

        #region Properties
        public int MaxSatelliteCount
        {
            get { return maxSatelliteCount; }
            set { maxSatelliteCount = value; }
        }

        #endregion

        #region Public Methods
        public void AddSatelitte(SatellitePlanet satellite)
        {
            satelliteList.Add(satellite);
        }
        public void RemoveSatelitte(SatellitePlanet satellite)
        {
            satelliteList.Remove(satellite);
        }

        public IReadOnlyCollection<SatellitePlanet> GetSatellites() 
        {
            return satelliteList.AsReadOnly();
        }

        public int GetSatelitteCount() 
        {
            return satelliteList.Count();
        }

        public override void Update()
        {
            foreach(var satellite in satelliteList) 
            {
                satellite.Update();
            }
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
