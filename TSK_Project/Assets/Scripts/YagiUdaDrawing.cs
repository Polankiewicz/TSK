using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class YagiUdaDrawing : MonoBehaviour {

    private GameObject DipolElement;
    private Vector3 DirektorPosition;
    private GameObject DirektorElement;
    
    private Vector3 vector1;
    private Vector3 vector2;

    private int numberOfDirektors;
    private int maxNumberOfDirektors;

    private Stack<Object> DirektorsStack;


    // Use this for initialization
    void Start () {
        DipolElement = GameObject.Find("DipolElement");
        DirektorElement = GameObject.Find("DirektorElement");
        vector1 = new Vector3(0, 0, 0.48F);
        vector2 = new Vector3(0, 0, 0.24F);

        numberOfDirektors = 0;
        maxNumberOfDirektors = 9;
        DirektorPosition = DirektorElement.transform.position;

        DirektorsStack = new Stack<Object>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z")) {
            if(numberOfDirektors < maxNumberOfDirektors)  {
                //resize and move dipol
                DipolElement.transform.localScale += vector1;
                DipolElement.transform.Translate(vector2);

                //new direktor
                numberOfDirektors++;
                Object newDirektor = Instantiate(DirektorElement, DirektorPosition + new Vector3(0, 0, 0.5F * numberOfDirektors), Quaternion.identity);
                DirektorsStack.Push(newDirektor);
            }
        }

        if (Input.GetKeyDown("x"))
        {
            if (numberOfDirektors > 0)
            {
                //resize and move dipol
                DipolElement.transform.localScale -= vector1;
                DipolElement.transform.Translate(-vector2);

                //remove direktor
                numberOfDirektors--;
                Destroy(DirektorsStack.Pop());
            }
        }
    }
}
