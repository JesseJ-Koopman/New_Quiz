using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    public GameObject answerABackBlue; // Blue is Waiting
    public GameObject answerABackGreen; // Green is Correct
    public GameObject answerABackRed; // Red is Wrong

    public GameObject answerBBackBlue; // Blue is Waiting
    public GameObject answerBBackGreen; // Green is Correct
    public GameObject answerBBackRed; // Red is Wrong

    public GameObject answerCBackBlue; // Blue is Waiting
    public GameObject answerCBackGreen; // Green is Correct
    public GameObject answerCBackRed; // Red is Wrong

    public GameObject answerDBackBlue; // Blue is Waiting
    public GameObject answerDBackGreen; // Green is Correct
    public GameObject answerDBackRed; // Red is Wrong

    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;


    public AudioSource correctFX;
    public AudioSource wrongFX;

    public GameObject currentScore;
    public int scoreValue;
    public int bestScore;
    public GameObject bestDisplay;


    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScoreQuiz");
        bestDisplay.GetComponent<Text>().text = "BEST: " + bestScore;
    }

    void Update()
    {
        currentScore.GetComponent<Text>().text = "SCORE: " + scoreValue; 
    }

    public void AnswerA()
    {
        if (QuestionGenerate.actualAnswer == "A")
        {
            answerABackGreen.SetActive(true);
            answerABackBlue.SetActive(false);
            correctFX.Play();
            scoreValue += 5;
           
        }
        else
        {
            answerABackRed.SetActive(true);
            answerABackBlue.SetActive(false);
            wrongFX.Play();
            scoreValue = 0;
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;

        StartCoroutine(NextQuestion());

    }

    public void AnswerB()
    {
        if (QuestionGenerate.actualAnswer == "B")
        {
            answerBBackGreen.SetActive(true);
            answerBBackBlue.SetActive(false);
            correctFX.Play();
            scoreValue += 5;
        }
        else
        {
            answerBBackRed.SetActive(true);
            answerBBackBlue.SetActive(false);
            wrongFX.Play();
            scoreValue = 0;
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;

        StartCoroutine(NextQuestion());
    }

    public void AnswerC()
    {
        if (QuestionGenerate.actualAnswer == "C")
        {
            answerCBackGreen.SetActive(true);
            answerCBackBlue.SetActive(false);
            correctFX.Play();
            scoreValue += 5;
        }
        else
        {
            answerCBackRed.SetActive(true);
            answerCBackBlue.SetActive(false);
            wrongFX.Play();
            scoreValue = 0;
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;

        StartCoroutine(NextQuestion());
    }

    public void AnswerD()
    {
        if (QuestionGenerate.actualAnswer == "D")
        {
            answerDBackGreen.SetActive(true);
            answerDBackBlue.SetActive(false);
            correctFX.Play();
            scoreValue += 5;
        }
        else
        {
            answerDBackRed.SetActive(true);
            answerDBackBlue.SetActive(false);
            wrongFX.Play();
            scoreValue = 0;
        }

        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;

        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion()
    {

        if (bestScore < scoreValue)
        {
            PlayerPrefs.SetInt("BestScoreQuiz", scoreValue);
            bestScore = scoreValue;
            bestDisplay.GetComponent<Text>().text = "BEST: " + scoreValue;
        }

        yield return new WaitForSeconds(2);

        answerABackGreen.SetActive(false);
        answerBBackGreen.SetActive(false);
        answerCBackGreen.SetActive(false);
        answerDBackGreen.SetActive(false);

        answerABackRed.SetActive(false);
        answerBBackRed.SetActive(false);
        answerCBackRed.SetActive(false);
        answerDBackRed.SetActive(false);

        answerABackBlue.SetActive(true);
        answerBBackBlue.SetActive(true);
        answerCBackBlue.SetActive(true);
        answerDBackBlue.SetActive(true);

        answerA.GetComponent<Button>().enabled = true;
        answerB.GetComponent<Button>().enabled = true;
        answerC.GetComponent<Button>().enabled = true;
        answerD.GetComponent<Button>().enabled = true;

        QuestionGenerate.displayingQuestion = false;

    }

}
