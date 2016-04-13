using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
	
	//public instance variables
	public Transform[] starPoints;
	public GameObject star;

	// Use this for initialization
	void Start () {
		Points ();
	
	}
	
	// Update is called once per frame
	void Points () {
		for (int i = 0; i < starPoints.Length; i++) {
			int starCount = Random.Range (0, 2);
			if (starCount > 0)
				Instantiate (star, starPoints [i].position, Quaternion.identity);
		}
			
	
	}
}
