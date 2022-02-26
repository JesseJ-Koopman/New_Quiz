using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    public static string actualAnswer;

    public static bool displayingQuestion = false;

    public int questionNumber;
   
    // Update is called once per frame
    void Update()
    {
        if (displayingQuestion == false)
        {
            displayingQuestion = true;
            questionNumber = Random.Range(1, 5);

            if (questionNumber == 1)
            {
                

                QuestionDisplay.newQuestion = "How much wood could a wood chuck chuck if a wood chuck could chuck wood? ";
                QuestionDisplay.newA = "A. Lots and Lots ";
                QuestionDisplay.newB = "B. None ";
                QuestionDisplay.newC = "C. Hardly any ";
                QuestionDisplay.newD = "D. Six ";

                actualAnswer = "A";
            }

            if (questionNumber == 2)
            {

                QuestionDisplay.newQuestion = "Who is the brother of Luigi? ";
                QuestionDisplay.newA = "A. D.K ";
                QuestionDisplay.newB = "B. Toad ";
                QuestionDisplay.newC = "C. Mario";
                QuestionDisplay.newD = "D. Link ";

                actualAnswer = "C";
            }

            if (questionNumber == 3)
            {

                QuestionDisplay.newQuestion = "Where is Japan? ";
                QuestionDisplay.newA = "A. Africa ";
                QuestionDisplay.newB = "B. Asia ";
                QuestionDisplay.newC = "C. Europe ";
                QuestionDisplay.newD = "D. Antarcia ";

                actualAnswer = "B";
            }

            if (questionNumber == 4)
            {

                QuestionDisplay.newQuestion = "How old is the world?";
                QuestionDisplay.newA = "A. 2022 years ";
                QuestionDisplay.newB = "B. 6 months ";
                QuestionDisplay.newC = "C. 10 years ";
                QuestionDisplay.newD = "D. Billions  of years ";

                actualAnswer = "D";
            }

            // All questions go above this line
            QuestionDisplay.pleaseUpdate = false;
        }

    }
}
