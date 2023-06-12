using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QuestnAns;
	
	public AudioSource TimeUp;
	
	bool timerActive = false;
	bool stopwatchActive = false;
	
	public Text QuestionTxt;
	public Text ScoreTxt;
	public Text Number;
	public Text CurrentScore;
	public Text PointsTxt;
	public Text TimeText;
	public Text DurationText;
	
	public GameObject[] options;
	public GameObject QuizPanel;
	public GameObject ScorePanel;
	public GameObject PausePanel;
	
	public float currentTime;
	public float startTime;
	
	public int currentQuest;
	public int score;
	public int Points;
	
	int TotalQuestions = 0;
	int x = 1;
	int i = 0;
	int Zo = 0;
	int m = 40;
	int a = 1;
	int c = 7;
	int noOfRandomNums = 20;
	int n = 0;

	public void Start()
	{
		currentTime =30;
		startTime = 0;
		timerActive = true;
		stopwatchActive = true;
		Zo = UnityEngine.Random.Range(1,39);
		TotalQuestions = QuestnAns.Count;
		ScorePanel.SetActive(false);
		QuizPanel.SetActive(true);
		genQuest();
	}
	
	void Update()
	{
		if (timerActive == true)
		{
			currentTime = currentTime - Time.deltaTime;
			if (currentTime <= 0)
			{
				TimeUp.Play();
				timerActive = false;
				x +=1;
				for (int i = 0; i < options.Length; i++)
				{
					options[i].GetComponent<Button>().enabled = false;
					options[i].GetComponent<Image>().color = Color.red;
					if(QuestnAns[currentQuest].CorrectAnswer == i+1)
					{
						options[i].GetComponent<Button>().enabled =false;
						options[i].GetComponent<Answer>().isCorrect =true;
						options[i].GetComponent<Image>().color = Color.green;
					}
				}
				Invoke("genQuest", 2.5f);
			}
		}
		if (stopwatchActive == true)
		{
			startTime = startTime + Time.deltaTime;
		}
		TimeSpan time = TimeSpan.FromSeconds(currentTime);
		TimeText.text = time.Seconds.ToString();
		TimeSpan time2 = TimeSpan.FromSeconds(startTime);
		DurationText.text = "Play Time = " + time2.ToString(@"mm\:ss");
	}
	
	public void Retry()
	{
		SceneManager.LoadScene("QUIZ");
	}
	
	public void Exit()
	{
		SceneManager.LoadScene("Menu");
	}
	
	void GameOver()
	{
		QuizPanel.SetActive(false);
		ScorePanel.SetActive(true);
		PausePanel.SetActive(false);
		ScoreTxt.text = score + "/ 20";
		Details();
		PointsTxt.text = Points.ToString();
	}
	
	void Details()
	{
		Points = score * 5;
	}
	
	public void Correct()
	{
		timerActive = false;
		x +=1;
		score += 1;
		for (int i = 0; i < options.Length; i++)
		{
			options[i].GetComponent<Button>().enabled=false;
		}
		Invoke("genQuest", 2f);
	}
	
	public void Wrong()
	{
		for (int i = 0; i < options.Length; i++)
		{
			options[i].GetComponent<Button>().enabled=false;
			if(QuestnAns[currentQuest].CorrectAnswer == i+1)
			{
				options[i].GetComponent<Answer>().isCorrect =true;
				options[i].GetComponent<Image>().color = Color.green;
			}
		}
		timerActive = false;
		x +=1;
		Invoke("genQuest", 2.5f);
	}
	
	void setAns()
	{
		for (int i = 0; i < options.Length; i++)
		{
			options[i].GetComponent<Answer>().isCorrect =false;
			options[i].transform.GetChild(0).GetComponent<Text>().text = QuestnAns[currentQuest].Answer[i];
			options[i].GetComponent<Image>().color = options[i].GetComponent<Answer>().startColor;
			options[i].GetComponent<Button>().enabled = true;
			if(QuestnAns[currentQuest].CorrectAnswer == i+1)
			{
				options[i].GetComponent<Answer>().isCorrect =true;
			}
		}
	}
	
	void genQuest()
	{
		timerActive = true;
		stopwatchActive = true;
		currentTime = 31;
		Number.text = "Q. " + x + " Of 20";
		CurrentScore.text = score + "/ 20";
		if(n<noOfRandomNums)
		{
			int[] randomNums = new int[40];
			randomNums[0] = Zo;
			for(i=1; i<40; i++)
			{
				randomNums[i] = ((randomNums[i-1] * a) + c) % m;
			}
			currentQuest = randomNums[n];
			QuestionTxt.text = QuestnAns[currentQuest].Question;
			n +=1;
			setAns();
			Debug.Log(currentQuest);
		}
		else
		{
			n=0;
			timerActive = false;
			stopwatchActive = false;
			GameOver();
		}
	}
	
	public void Pause()
	{
		timerActive = false;
		stopwatchActive = false;
		PausePanel.SetActive(true);
		QuizPanel.SetActive(false);
	}
	
	public void Resume()
	{
		timerActive = true;
		stopwatchActive = true;
		PausePanel.SetActive(false);
		QuizPanel.SetActive(true);
	}
	
}
