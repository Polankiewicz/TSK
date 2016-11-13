using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogPeriodicDrawing : MonoBehaviour {

    private GameObject PeriodicElementUp;
    private GameObject PeriodicElementDown;

    private int numberOfDirektors;
    private int maxNumberOfDirektors;
    private int minNumberOfDirektors;

    private Vector3 periodicLengthResize;
    private Vector3 periodicMoveElements;


    private Stack<GameObject> DirektorsStack;

    private GameObject PeriodicDirektorLeft;
    private GameObject PeriodicDirektorRight;

    private Vector3 DirektorPositionLeft;
    private Vector3 DirektorPositionRight;


    // Use this for initialization
    void Start () {
        PeriodicElementUp = GameObject.Find("PeriodicElementUp");
        PeriodicElementDown = GameObject.Find("PeriodicElementDown");

        numberOfDirektors = 0;
        maxNumberOfDirektors = 8;
        minNumberOfDirektors = 0;

        periodicMoveElements = new Vector3(-0.24F, 0, 0);
        periodicLengthResize = new Vector3(-0.48F, 0, 0);


        DirektorsStack = new Stack<GameObject>();

        PeriodicDirektorLeft = GameObject.Find("PeriodicDirektorLeft");
        PeriodicDirektorRight = GameObject.Find("PeriodicDirektorRight");

        DirektorPositionLeft = PeriodicDirektorLeft.transform.position;
        DirektorPositionRight = PeriodicDirektorRight.transform.position;
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown("z"))
        {
            if (numberOfDirektors < maxNumberOfDirektors)
            {
                //resize and move periodic long elements
                PeriodicElementUp.transform.localScale -= periodicLengthResize;
                PeriodicElementUp.transform.Translate(periodicMoveElements);
                PeriodicElementDown.transform.localScale -= periodicLengthResize;
                PeriodicElementDown.transform.Translate(periodicMoveElements);

                //new direktor
                numberOfDirektors++;

                float upDownPosition = 0;
                if (numberOfDirektors % 2 == 1)
                    upDownPosition = -0.3F;
                else
                    upDownPosition = 0;

                GameObject newDirektor = Instantiate(PeriodicDirektorLeft, DirektorPositionLeft + new Vector3(-0.5F * numberOfDirektors, upDownPosition, 0), Quaternion.identity) as GameObject;
                newDirektor.transform.localScale = new Vector3(0.075F, 0.075F, 1F - 0.05F * numberOfDirektors);
                DirektorsStack.Push(newDirektor);

                newDirektor = Instantiate(PeriodicDirektorRight, DirektorPositionRight + new Vector3(-0.5F * numberOfDirektors, -upDownPosition, 0), Quaternion.identity) as GameObject;
                newDirektor.transform.localScale = new Vector3(0.075F, 0.075F, 1F - 0.05F * numberOfDirektors);
                DirektorsStack.Push(newDirektor);
            }
        }

        if (Input.GetKeyDown("x"))
        {
            if (numberOfDirektors > 0)
            {
                //resize and move periodic long elements
                PeriodicElementUp.transform.localScale += periodicLengthResize;
                PeriodicElementUp.transform.Translate(-periodicMoveElements);
                PeriodicElementDown.transform.localScale += periodicLengthResize;
                PeriodicElementDown.transform.Translate(-periodicMoveElements);

                //remove direktor
                numberOfDirektors--;
                Destroy(DirektorsStack.Pop());
                Destroy(DirektorsStack.Pop());
            }
        }



    }
}
