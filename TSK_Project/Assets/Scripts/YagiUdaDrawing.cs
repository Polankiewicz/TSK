using UnityEngine;
using System.Collections;

public class YagiUdaDrawing : MonoBehaviour {

    private GameObject DipolElement;
    public Vector3 vector1;
    public Vector3 vector2;

    // Use this for initialization
    void Start () {
        DipolElement = GameObject.Find("DipolElement");
        vector1 = new Vector3(0, 0, 0.1F);
        vector2 = new Vector3(0, 0, 0.05F);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("z")) {
            DipolElement.transform.localScale += vector1;
            DipolElement.transform.Translate(vector2);
        }
    }
}
