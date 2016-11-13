using UnityEngine;
using System.Collections;

public class MonopolDrawing : MonoBehaviour {

    private GameObject Monopol;
    private GameObject Antena_Monopol;

    private int maxMonopolSize;
    private int minMonopolSize;
    private int actualMonopolSize;

    private Vector3 lengthResize;
    private Vector3 moveElements;

    private bool isHorizontal;

    // Use this for initialization
    void Start () {
        Monopol = GameObject.Find("Monopol");
        Antena_Monopol = GameObject.Find("Antena_Monopol");

        lengthResize = new Vector3(0, 0.3F, 0);
        moveElements = new Vector3(0, 0.15F, 0);

        maxMonopolSize = 10;
        minMonopolSize = 1;
        actualMonopolSize = 1;

        isHorizontal = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z"))
        {
            if (actualMonopolSize < maxMonopolSize)
            {
                Monopol.transform.localScale += lengthResize;
                Monopol.transform.Translate(moveElements);
                actualMonopolSize++;
            }
        }

        if (Input.GetKeyDown("x"))
        {
            if (actualMonopolSize > minMonopolSize)
            {
                Monopol.transform.localScale -= lengthResize;
                Monopol.transform.Translate(-moveElements);
                actualMonopolSize--;
            }
        }

        if (Input.GetKeyDown("c"))
        {
            if (isHorizontal)
            {
                Antena_Monopol.transform.Rotate(Vector3.left * 90);
                isHorizontal = false;
            }
            else
            {
                Antena_Monopol.transform.Rotate(Vector3.right * 90);
                isHorizontal = true;
            }
        }
    }
}
