using UnityEngine;
using System.Collections;

public class YagiUdaDrawing : MonoBehaviour {

    private GameObject DipolElement;
    private Vector3 DirektorPosition;
    private GameObject DirektorElement;
    
    private Vector3 vector1;
    private Vector3 vector2;

    private int numberOfDirektors;

    // Use this for initialization
    void Start () {
        DipolElement = GameObject.Find("DipolElement");
        DirektorElement = GameObject.Find("DirektorElement");
        vector1 = new Vector3(0, 0, 0.4F);
        vector2 = new Vector3(0, 0, 0.2F);

        numberOfDirektors = 0;
        DirektorPosition = DirektorElement.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z")) {
            //resize and move dipol
            DipolElement.transform.localScale += vector1;
            DipolElement.transform.Translate(vector2);

            //new direktor
            numberOfDirektors++;
            Instantiate(DirektorElement, DirektorPosition + new Vector3(0, 0, 0.5F * numberOfDirektors), Quaternion.identity);
        }
    }
}
