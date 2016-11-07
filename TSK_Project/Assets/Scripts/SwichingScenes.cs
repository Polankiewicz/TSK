using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwichingScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
            SceneManager.LoadScene("Yagi_Uda");
        if (Input.GetKeyDown("2"))
            SceneManager.LoadScene("Monopol");
        if (Input.GetKeyDown("3"))
            SceneManager.LoadScene("Dipol");
        if (Input.GetKeyDown("4"))
            SceneManager.LoadScene("Log_Periodic");
    }
}
