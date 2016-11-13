using UnityEngine;
using System.Collections;

public class DipolDrawing : MonoBehaviour {

    private GameObject DipolElementUp;
    private GameObject DipolElementDown;
    private GameObject DipolElementLeft;
    private GameObject DipolElementRight;
    private GameObject Antena_Dipol;

    private Vector3 lengthResize;
    private Vector3 moveElements;

    private int maxDipolSize;
    private int minDipolSize;
    private int actualDipolSize;

    private bool isHorizontal;

    // Use this for initialization
    void Start () {
        DipolElementUp = GameObject.Find("DipolElementUp");
        DipolElementDown = GameObject.Find("DipolElementDown");
        DipolElementLeft = GameObject.Find("DipolElementLeft");
        DipolElementRight = GameObject.Find("DipolElementRight");
        Antena_Dipol = GameObject.Find("Antena_Dipol");

        lengthResize = new Vector3(0, 0, 0.5F);
        moveElements = new Vector3(0, 0, 0.25F);

        maxDipolSize = 10;
        minDipolSize = 1;
        actualDipolSize = 1;

        isHorizontal = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("z")) {
            if(actualDipolSize < maxDipolSize) {
                DipolElementUp.transform.localScale += lengthResize;
                DipolElementDown.transform.localScale += lengthResize;

                DipolElementLeft.transform.Translate(-moveElements);
                DipolElementRight.transform.Translate(moveElements);

                actualDipolSize++;
            }
        }

        if (Input.GetKeyDown("x")) {
            if(actualDipolSize > minDipolSize) {
                DipolElementUp.transform.localScale -= lengthResize;
                DipolElementDown.transform.localScale -= lengthResize;

                DipolElementLeft.transform.Translate(moveElements);
                DipolElementRight.transform.Translate(-moveElements);

                actualDipolSize--;
            }
        }

        if (Input.GetKeyDown("c")) {
            if(isHorizontal) {
                Antena_Dipol.transform.Rotate(Vector3.left * 90);
                isHorizontal = false;
            }
            else {
                Antena_Dipol.transform.Rotate(Vector3.right * 90);
                isHorizontal = true;
            }   
        }
    }
}
