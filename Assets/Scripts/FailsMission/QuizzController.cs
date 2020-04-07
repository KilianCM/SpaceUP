using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizzController : MonoBehaviour
{
    public Canvas QuizzCanvas;
    public VideoPlayer VideoPlayer;

    private double currentTime;
    private QuestionAnswerList questionAnswerList;
    private Text questionText;
    private Button buttonAnswer1;
    private Button buttonAnswer2;
    private Question currentQuestion;

    // Start is called before the first frame update
    void Start()
    {
        QuizzCanvas.gameObject.SetActive(false);
        questionAnswerList = GetComponent<QuestionAnswerList>();
        questionText = QuizzCanvas.GetComponentInChildren<Text>();
        //buttonAnswer1 = QuizzCanvas.transform.FindChild("ButtonAnswer1").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = VideoPlayer.time;
        if(currentTime < 38 && currentTime > 37.5)
        {
            currentQuestion = questionAnswerList.GetQuestion(0);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        VideoPlayer.Pause();
        QuizzCanvas.gameObject.SetActive(true);
        questionText.text = currentQuestion.Value;
    }
}
