using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearnManager : MonoBehaviour
{	
	public GameObject Placeholder1;
	public GameObject Placeholder2;
	public GameObject Placeholder3;
	public GameObject Placeholder4;
	public GameObject NextButton;
	public GameObject PrevButton;
	
	int x = 0;

	private void Start()
	{
		PrevButton.SetActive(false);
		Placeholder1.SetActive(true);
		Placeholder2.SetActive(false);
		Placeholder3.SetActive(false);
		Placeholder4.SetActive(false);
	}
	
    public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void Next()
	{
		x = x+1;
		if (x == 1)
		{
			Placeholder1.SetActive(false);
			Placeholder2.SetActive(true);
			NextButton.SetActive(true);
			PrevButton.SetActive(true);
		}
		if (x == 2)
		{
			Placeholder2.SetActive(false);
			Placeholder3.SetActive(true);
			
		}
		if (x == 3)
		{
			Placeholder3.SetActive(false);
			Placeholder4.SetActive(true);
			NextButton.SetActive(false);
		}
	}
	
	public void Previous()
	{
		x = x-1;
		if (x == 0)
		{
			Placeholder1.SetActive(true);
			Placeholder2.SetActive(false);
			NextButton.SetActive(true);
			PrevButton.SetActive(false);
		}
		if (x == 1)
		{
			Placeholder2.SetActive(true);
			Placeholder3.SetActive(false);
		}
		if (x == 2)
		{
			Placeholder3.SetActive(true);
			Placeholder4.SetActive(false);
			NextButton.SetActive(true);
			PrevButton.SetActive(true);
		}
		
	}
}
