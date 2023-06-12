using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
	public QuizManager QM;
	public AudioSource CorrectSound;
	public AudioSource WrongSound;
	public Color startColor;
	
	public void Start()
	{
		startColor = GetComponent<Image>().color;
	}
	
	public void Ans()
	{
		if(isCorrect)
		{
			GetComponent<Image>().color = Color.green;
			Debug.Log("Correct");
			CorrectSound.Play();
			QM.Correct();
		}
		else
		{
			GetComponent<Image>().color = Color.red;
			Debug.Log("False");
			WrongSound.Play();
			QM.Wrong();
		}
	}
}
