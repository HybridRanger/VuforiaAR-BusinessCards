using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public int speed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1 * speed, 0));
	}
}
