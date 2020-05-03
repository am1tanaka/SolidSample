using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolidSample
{
	public class UpDownLeftPlayer : PlayerDefault
	{
		protected override void RightButtonShot()
		{
			Instantiate(shotPrefab, transform.position,
				Quaternion.Euler(0, 0, 90f));
			Instantiate(shotPrefab, transform.position,
				Quaternion.Euler(0, 0, -90f));
			Instantiate(shotPrefab, transform.position,
				Quaternion.Euler(0, 0, 180f));
		}
	}
}