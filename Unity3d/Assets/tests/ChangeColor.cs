using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

    GameObject object1, object2;

    // Use this for initialization
    void Start () {
        object1 = GameObject.Find("Sphere1");
        object2 = GameObject.Find("Sphere2");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    object1.renderer.material.color = new Color(20,50,100,50);
	}
}
