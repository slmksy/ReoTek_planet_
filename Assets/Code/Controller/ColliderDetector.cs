using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Controller
{
    public class ColliderDetector : MonoBehaviour
    {
		#region Constants

		#endregion

		#region Fields
		public static event Action<GameObject, GameObject> OnCollision;
		#endregion

		#region Constructors
		public ColliderDetector() 
		{

		}
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

		#region Events
		void OnCollisionEnter(Collision other)
		{
			
			OnCollision?.Invoke(gameObject, other.gameObject);
		}
		#endregion





	}
}
