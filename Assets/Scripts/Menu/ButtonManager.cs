using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void CreateGame(string newSceneName)
	{
		SceneManager.LoadScene(newSceneName);
	}

	public void JoinGame(string newSceneName)
	{
		SceneManager.LoadScene(newSceneName);
	}

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
