﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public interface IPlanet 
    {
        public void SetPlanetGameObject(GameObject gameObject);
        public void Update();
    }
}
