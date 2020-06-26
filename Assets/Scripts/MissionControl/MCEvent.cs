using LoadQuestions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCEvent
{   
    public static GameObject panel;
    public static GameObject scorePanel;
    public static Dictionary<string, GameObject> elementsType;
    public static Questions questions;
    public static GameObject timer;
    public static GameObject filler;

    private List<GameObject> UIElements;
    private int answerValue;


    private const int columns = 4;
    private const int rows = 3;

    private static int questionIndex = 0;
    public static int score = 0;

    delegate void MyDelegate();
    MyDelegate myDelegate;

    public MCEvent()
    {
        timer.GetComponent<Timer>().Reset();
        timer.GetComponent<Timer>().mcEvent = this;
        GameObject[] answers = GameObject.FindGameObjectsWithTag("Answer");
        foreach (GameObject answer in answers)
        {
            GameObject.Destroy(answer);
        }
        LoadQuestions.Question question = questions.Question[questionIndex];
        MCEvent.panel.transform.Find("QuestionText").GetComponent<Text>().text = question.QuestionText;
        updateScore();
        this.UIElements = new List<GameObject>();
        foreach (LoadQuestions.Element elementData in question.Elements.Element)
        {
            this.UIElements.Add(MCElement.CreateInstance(elementsType[elementData.Type], elementData, panel));
        }
        this.answerValue = question.AnswerValue;

        float stdSize = 200; 
        List<GameObject> shuffleElement = ShuffleList(UIElements);
        int elementIdx = 0;
        float panelH = MCEvent.panel.transform.GetComponent<RectTransform>().rect.height;

        Vector3 pos = new Vector3(-((columns/2)*stdSize), panelH/4, 0);
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns;)
            {
                if (elementIdx < shuffleElement.Count)
                {
                    MCElement element = shuffleElement[elementIdx].GetComponent<MCElement>();
                    if (columns - c >= element.size)
                    {
                        c += element.size;
                        shuffleElement[elementIdx].transform.localPosition = pos;
                        element.EventHandler = this;
                        elementIdx++;
                        pos.x += stdSize * element.size;
                    }
                    else
                    {
                        c++;
                        //GameObject instance = GameObject.Instantiate(filler) as GameObject;
                        GameObject fillerInstance = GameObject.Instantiate(filler, panel.transform, false) as GameObject;
                        fillerInstance.transform.localPosition = pos;
                        pos.x += stdSize;
                        /*instance.transform.SetParent(panel.transform, false);
                        instance.transform.localPosition = pos;*/
                    }
                }
                else
                {
                    c++;
                    GameObject fillerInstance = GameObject.Instantiate(filler, panel.transform, false) as GameObject;
                    fillerInstance.transform.localPosition = pos;
                    pos.x += stdSize;
                }
                
            }
            pos.x = -((columns / 2) * stdSize);//reset horizontal pos
            pos.y -= stdSize;
        }



        /*float panelW = MCEvent.panel.transform.GetComponent<RectTransform>().rect.width;
        float offset = panelW / 2;//panel position on x goes from -800 to +800 => offset to 0 - 1600 to make simpler operation
        Vector3 nextPosition = new Vector3((panelW / (columns + 1) - offset), 0);

        foreach (GameObject uiElement in ShuffleList(UIElements))//set position
        {
            uiElement.transform.localPosition = nextPosition;
            if (nextPosition.x + (panelW / (columns + 1)) + offset >= panelW)
            {
                nextPosition.x = panelW / (columns + 1) - offset;
                nextPosition.y -= 100;
            }
            else
            {
                nextPosition.x += panelW / (columns + 1);
            }
            MCElement element = uiElement.GetComponent<MCElement>();
            element.EventHandler = this;
        }*/
        timer.GetComponent<Timer>().isStarted = true;
    }

    private void updateScore()
    {
        panel.transform.Find("Score").GetComponent<Text>().text = score.ToString();
        panel.transform.Find("QuestionCount").GetComponent<Text>().text = (questionIndex + 1) + "/" + questions.Question.Count;
    }

    public void NextQuestion()
    {
        questionIndex++;
        if (questions.Question.Count > questionIndex)
        {
            new MCEvent();
        }
        else
        {
            panel.SetActive(false);
            timer.SetActive(false);
            scorePanel.transform.Find("Score").GetComponent<Text>().text = score.ToString();
            scorePanel.SetActive(true);
            if (PlayerData.MoonMissionScore < score)
            {
                PlayerData.MoonMissionScore = score;
            }
        }
    }

    public bool CheckAnswer(bool isCorrect,int value)
    {
        isCorrect = isCorrect && value == this.answerValue;
        if (isCorrect)
        {
            score += 100;
            this.NextQuestion();
        }
        else
        {
            score -= 50;
        }
        updateScore();
        return isCorrect;
    }

    public static List<T> ShuffleList<T>(List<T> list)
    {
        List<T> shuffled = list;
        System.Random random = new System.Random();
        int n = shuffled.Count;

        for (int i = shuffled.Count - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);

            T value = shuffled[rnd];
            shuffled[rnd] = shuffled[i];
            shuffled[i] = value;
        }
        return shuffled;
    }
}
