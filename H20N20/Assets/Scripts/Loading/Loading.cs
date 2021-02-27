using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Loading : MonoBehaviour
{
	public AsyncOperation async;
	public Image progressbar;
	public Text txtPercent;
	public bool waitForUserInput = false;
	public bool ready = false;
	public float delay = 0;
	public int sceneToLoad = -1;

	// Start is called before the first frame update
	void Start()
	{
		Time.timeScale = 1.0f;
		Input.ResetInputAxes();
		System.GC.Collect();
		Scene currentScene = SceneManager.GetActiveScene();

		if (sceneToLoad < 0)
		{
			async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
		}
		else
		{
			async = SceneManager.LoadSceneAsync(sceneToLoad);
		}

		async.allowSceneActivation = false;
		if (waitForUserInput == false)
		{
			Invoke("Activate", delay);
		}
	}

	public void Activate()
	{
		ready = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (waitForUserInput && Input.anyKey)
		{
			ready = true;
		}

		if (progressbar)
		{
			progressbar.fillAmount = async.progress + 0.1f;
		}

		if (txtPercent)
		{
			txtPercent.text = ((async.progress + 0.1f) * 100).ToString("f2") + " %";
		}

		if (async.progress > 0.89f && SplashScreen.isFinished && ready)
		{
			async.allowSceneActivation = true;
		}
	}
}
