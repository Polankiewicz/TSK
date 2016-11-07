using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class YagiUdaDrawing : MonoBehaviour {

    private GameObject DipolElement;
    private Vector3 vector1;
    private Vector3 vector2;

    // direktor
    private Vector3 DirektorPosition;
    private GameObject DirektorElement;
    
    private int numberOfDirektors;
    private int maxNumberOfDirektors;

    private Stack<GameObject> DirektorsStack;

    // reflektor
    private GameObject ReflektorElement;
    private Vector3 ReflektorPosition;

    private int numberOfReflektors;
    private int maxNumberOfReflektors;

    private Stack<GameObject> ReflektorsStack;


    // Use this for initialization
    void Start () {
        DipolElement = GameObject.Find("DipolElement");
        vector1 = new Vector3(0, 0, 0.48F);
        vector2 = new Vector3(0, 0, 0.24F);

        //direktor
        DirektorElement = GameObject.Find("DirektorElement");
        
        numberOfDirektors = 0;
        maxNumberOfDirektors = 9;
        DirektorPosition = DirektorElement.transform.position;

        DirektorsStack = new Stack<GameObject>();

        // reflektor
        ReflektorElement = GameObject.Find("ReflektorElement");

        numberOfReflektors = 0;
        maxNumberOfReflektors = 4;
        ReflektorPosition = ReflektorElement.transform.position;

        ReflektorsStack = new Stack<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        // DIREKTORS
        if (Input.GetKeyDown("z")) {
            if(numberOfDirektors < maxNumberOfDirektors)  {
                //resize and move dipol
                DipolElement.transform.localScale += vector1;
                DipolElement.transform.Translate(vector2);

                //new direktor
                numberOfDirektors++;
                GameObject newDirektor = Instantiate(DirektorElement, DirektorPosition + new Vector3(0, 0, 0.5F * numberOfDirektors), Quaternion.identity) as GameObject;
                newDirektor.transform.localScale = new Vector3(1.5F - 0.1F * numberOfDirektors, 0.2F, 0.2F);
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

        // REFLEKTORS
        if (Input.GetKeyDown("c"))
        {
            if (numberOfReflektors < maxNumberOfReflektors)
            {
                //resize and move dipol
                DipolElement.transform.localScale += vector1;
                DipolElement.transform.Translate(-vector2);

                //new reflector
                numberOfReflektors++;
                GameObject newReflektor = Instantiate(ReflektorElement, ReflektorPosition + new Vector3(0, 0, -0.5F * numberOfReflektors), Quaternion.identity) as GameObject;
                //newReflektor.transform.localScale = new Vector3(1.5F - 0.1F * numberOfReflektors, 0.2F, 0.2F);
                ReflektorsStack.Push(newReflektor);
            }
        }

        if (Input.GetKeyDown("v"))
        {
            if (numberOfReflektors > 0)
            {
                //resize and move dipol
                DipolElement.transform.localScale -= vector1;
                DipolElement.transform.Translate(vector2);

                //remove reflector
                numberOfReflektors--;
                Destroy(ReflektorsStack.Pop());
            }
        }
    }
}
