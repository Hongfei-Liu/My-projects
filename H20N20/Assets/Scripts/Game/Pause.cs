using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	public GameObject pause;
	public GameObject hpPanel;
	//public bool isPaused = false;
	//public GameObject GameStartPanel;

	public GameObject skill;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Cancel"))
		{
			pause.SetActive(true);
			Time.timeScale = 0f;
			//isPaused = true;
			skill.SetActive(false);
			hpPanel.SetActive(false);
		}
	}

	public void ResumeGame()
	{
		//dis.SetActive(true);
		pause.SetActive(false);
		Time.timeScale = 1f;
		//isPaused = false;
		skill.SetActive(true);
		hpPanel.SetActive(true);
	}

	//public void Mainmenu()
	//{
	//	Cursor.lockState = CursorLockMode.Confined;
	//	Cursor.visible = true;
	//	SceneManager.LoadScene("GameScene");
	//}

	//public void StartGame()
	//{
	//	//Cursor.lockState = CursorLockMode.Confined;
	//	//Cursor.visible = true;
	//	Time.timeScale = 0f;
	//	GameStartPanel.SetActive(false);
	//	ResumeGame();
	//}
}
