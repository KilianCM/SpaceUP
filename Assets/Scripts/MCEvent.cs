using LoadQuestions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCEvent
{   
    public static GameObject panel;
    public static Dictionary<string, GameObject> elementsType;
    public static Questions questions;
    public static Timer timer;

    private List<GameObject> UIElements;
    private int answerValue;
    private const int columns = 2;
    private static int questionIndex = 0;

    delegate void MyDelegate();
    MyDelegate myDelegate;

    public MCEvent()
    {
        timer.Reset();
        timer.mcEvent = this;
        GameObject[] answers = GameObject.FindGameObjectsWithTag("Answer");
        foreach (GameObject answer in answers)
        {
            GameObject.Destroy(answer);
        }
        LoadQuestions.Question question = questions.Question[questionIndex];
        MCEvent.panel.GetComponentInChildren<Text>().text = question.QuestionText;
        this.UIElements = new List<GameObject>();
        foreach (LoadQuestions.Element elementData in question.Elements.Element)
        {
            this.UIElements.Add(MCElement.CreateInstance(elementsType[elementData.Type], elementData.Text, panel));
        }
        this.answerValue = question.AnswerValue;

        float panelW = MCEvent.panel.transform.GetComponent<RectTransform>().rect.width;
        float offset = panelW / 2;//panel position on x goes from -800 to +800 => offset to 0 - 1600 to make simpler operation
        Vector3 nextPosition = new Vector3((panelW / (columns + 1) - offset), 0);
        foreach (GameObject uiElement in UIElements)
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
        }
        timer.isStarted = true;
    }

    public bool CheckAnswer(GameObject element,int value)
    {
        bool isCorrect = element.GetInstanceID() == UIElements[0].GetInstanceID() && value == this.answerValue;
        if (isCorrect)
        {
            questionIndex++;
            new MCEvent();
        }
        return isCorrect;
    }

    public void TimerComplete()
    {
        questionIndex++;
        new MCEvent();
    }


}
