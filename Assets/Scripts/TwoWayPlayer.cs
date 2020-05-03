using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolidSample
{
	public class TwoWayPlayer : PlayerDefault
	{
		protected override void RightButtonShot()
		{
			Instantiate(shotPrefab, transform.position,
				Quaternion.Euler(0, 0, 15f));
			Instantiate(shotPrefab, transform.position,
				Quaternion.Euler(0, 0, -15f));
		}
	}
}