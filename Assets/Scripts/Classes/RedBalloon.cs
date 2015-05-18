using System;
using UnityEngine;

	public class RedBalloon : BalloonPowers
	{
		public RedBalloon ()
		{
			Primary = (GameObject)Resources.Load("Fireball");

		}
	}

