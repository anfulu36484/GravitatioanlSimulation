using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GravitatioanlSimulation;

public class DataUnity3d_3DVisualiser : MonoBehaviour
{

    private Model _model;
    List<GameObject> _spheres;

    // Use this for initialization
    void Start () {
	    _model = new ModelGenerator1().Generate();
        _spheres =new List<GameObject>();

        var sphere1 = GameObject.Find("Sphere1");
        sphere1.transform.position = new Vector3(_model.r[0].X, _model.r[0].Y, _model.r[0].Z);
        sphere1.renderer.material.color = _model.color[0];
        _spheres.Add(sphere1);

        for (int i = 1; i < _model.dimension; i++)
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = new Vector3(_model.r[i].X, _model.r[i].Y, _model.r[i].Z);
            obj.renderer.material.color = _model.color[i];
            _spheres.Add(obj);
        }

        

    }
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < _model.dimension; i++)
	    {
	        _spheres[i].transform.position = new Vector3(_model.r[i].X, _model.r[i].Y, _model.r[i].Z);
        }
	    _model.NextStep();
	}
}
