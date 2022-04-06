using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Controller
{
    public class Colors
    {
		#region Constants

		#endregion

		#region Fields
		private Dictionary<int, UnityEngine.Color> colorDict = new Dictionary<int, UnityEngine.Color>();
		#endregion

		#region Constructors
		public Colors() 
		{
			GenerateColors();
		}
		#endregion

		#region Properties

		#endregion

		#region Public Methods
		public UnityEngine.Color GetRandomColor() 
		{
			Random random = new Random();
			return colorDict[random.Next(colorDict.Count)];
		}
		#endregion

		#region Private Methods
		private void GenerateColors() 
		{
			colorDict.Add(0, UnityEngine.Color.white);
			colorDict.Add(1, UnityEngine.Color.black);
			colorDict.Add(2, UnityEngine.Color.gray);
			colorDict.Add(3, UnityEngine.Color.red);
			colorDict.Add(4, UnityEngine.Color.blue);
			colorDict.Add(5, UnityEngine.Color.green);
			colorDict.Add(6, UnityEngine.Color.cyan);
			colorDict.Add(7, UnityEngine.Color.yellow);
			colorDict.Add(8, UnityEngine.Color.magenta);
			



		}
		#endregion

		#region Protected Methods

		#endregion

		#region Events

		#endregion

	}
}
