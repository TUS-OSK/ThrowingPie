using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {



    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toMain() {
        SceneManager.LoadScene("Main");
    }

    public void toStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void toGameClear()
    {
        coroutine = WaitAndGo(3f, "GameClear");
        StartCoroutine(coroutine);
    }

    public void toGameover()
    {
        coroutine = WaitAndGo(3f,"Gameover");
        StartCoroutine(coroutine);
    }

    IEnumerator WaitAndGo(float waitTime,string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
