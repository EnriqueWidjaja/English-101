using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	
	public GameObject MenuPanel;
	public GameObject AboutPanel;
	
	private void Start()
	{
		MenuPanel.SetActive(true);
		AboutPanel.SetActive(false);
	}
	
    public void Play()
	{
		SceneManager.LoadScene("QUIZ");
	}
	
	public void About()
	{
		MenuPanel.SetActive(false);
		AboutPanel.SetActive(true);
		Debug.Log("About");
	}
	
	public void BackToMenu()
	{
		MenuPanel.SetActive(true);
		AboutPanel.SetActive(false);
		Debug.Log("Menu");
	}
	
	public void Learn()
	{
		SceneManager.LoadScene("Learn");
	}
	
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
}
