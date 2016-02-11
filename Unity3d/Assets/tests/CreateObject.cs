using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {

    // Use this for initialization

    GameObject cube;

    void Start ()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(1, 2, 3);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
