using UnityEngine;
using System.Collections;

public class SwichingScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
            Application.LoadLevel("Yagi_Uda");
        if (Input.GetKeyDown("2"))
            Application.LoadLevel("Monopol");
        if (Input.GetKeyDown("3"))
            Application.LoadLevel("Dipol");
        if (Input.GetKeyDown("4"))
            Application.LoadLevel("Log_Periodic");
    }
}
