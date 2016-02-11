using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{


    GameObject object1, object2;


    // Use this for initialization
    void Start()
    {
        object1 = GameObject.Find("Sphere1");
        object2 = GameObject.Find("Sphere2");
    }

    // Update is called once per frame
    void Update()
    {
        object1.transform.localScale = new Vector3(object1.transform.localScale.x + 0.01f, object1.transform.localScale.y + 0.01f, object1.transform.localScale.z + 0.01f);
        object1.transform.position = new Vector3(object1.transform.position.x + 0.01f, object1.transform.position.y + 0.01f, object1.transform.position.z + 0.01f);
        object1.transform.localScale = new Vector3(object1.transform.localScale.x + 0.01f, object1.transform.localScale.y + 0.01f, object1.transform.localScale.z + 0.01f);
        object2.transform.position = new Vector3(object2.transform.position.x + 0.01f, object2.transform.position.y + 0.01f, object2.transform.position.z + 0.01f);
    }
}