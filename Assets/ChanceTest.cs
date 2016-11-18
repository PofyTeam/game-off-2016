using UnityEngine;
using System.Collections.Generic;
using PofyTools.Distribution;

public class ChanceTest : MonoBehaviour
{
	[Range (0f, 1f)]public float chance;
	private Chance _chance;
	//public List<bool> _result;
	// Use this for initialization
	void Start ()
	{
		this._chance = new Chance (chance, true);
		ToString ();
		this._chance.autoDeckSize = false;
		this._chance.chance = 0.123f;
		ToString ();

		this._chance.autoDeckSize = true;
		this._chance.chance = 0.75f;
		ToString ();


	}

	void ToString ()
	{
		Debug.Log (_chance.Count);
		for (int i = 0; i < 1000; ++i) {
			//this._result.Add (chance.Value);
			Debug.Log (_chance.Value);
		}
	}
}
