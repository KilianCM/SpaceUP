using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizzController : MonoBehaviour
{
    public Canvas QuizzCanvas;
    public VideoPlayer VideoPlayer;
    public int score = 0;

    private double currentTime;
    private QuestionAnswerList questionAnswerList;
    private Text questionText;
    private Button buttonAnswer1;
    private Button buttonAnswer2;
    private Question currentQuestion;
    private List<Answer> answers;
    private bool questionAnswered = false;

    // Start is called before the first frame update
    void Start()
    {
        QuizzCanvas.gameObject.SetActive(false);
        questionAnswerList = GetComponent<QuestionAnswerList>();
        questionText = QuizzCanvas.GetComponentInChildren<Text>();
        Button[] buttons = QuizzCanvas.GetComponentsInChildren<Button>();
        buttonAnswer1 = buttons[0];
        buttonAnswer2 = buttons[1];
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = VideoPlayer.time;
        if(currentTime < 38 && currentTime > 37.5 && !questionAnswered)
        {
            currentQuestion = questionAnswerList.GetQuestion(0);
            UpdateUI();
        } else if (currentTime < 66 && currentTime > 65.5 && questionAnswered)
        {
            currentQuestion = questionAnswerList.GetQuestion(1);
            UpdateUI();
        } else if (currentTime < 94.3 && currentTime > 93.8 && !questionAnswered)
        {
            currentQuestion = questionAnswerList.GetQuestion(2);
            UpdateUI();
        } else if (currentTime < 114 && currentTime > 113.5 && questionAnswered)
        {
            currentQuestion = questionAnswerList.GetQuestion(3);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        VideoPlayer.Pause();
        QuizzCanvas.gameObject.SetActive(true);
        questionText.text = currentQuestion.Value;
        answers = currentQuestion.Answers;
        buttonAnswer1.GetComponentInChildren<Text>().text = answers[0].Value;
        buttonAnswer2.GetComponentInChildren<Text>().text = answers[1].Value;
    }

    private void QuestionAnswered() {
        questionAnswered = !questionAnswered;
        QuizzCanvas.gameObject.SetActive(false);
        buttonAnswer1.GetComponent<Image>().color = Color.white;
        buttonAnswer2.GetComponent<Image>().color = Color.white;
        VideoPlayer.Play();
    }

    public void ClickButton1()
    {
        ClickHandle(buttonAnswer1);
    }

    public void ClickButton2()
    {
        ClickHandle(buttonAnswer2);
    }

    void ClickHandle(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == currentQuestion.GetCorrectAnswer())
        {
            score++;
            button.GetComponent<Image>().color = Color.green;
        }
        else
        {
            button.GetComponent<Image>().color = Color.red;
        }
        StartCoroutine(WaitBeforeRestart());
    }

    IEnumerator WaitBeforeRestart()
    {
        yield return new WaitForSeconds(2.5F);
        QuestionAnswered();
    }
}

