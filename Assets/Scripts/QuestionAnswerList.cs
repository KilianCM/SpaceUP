﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswerList : MonoBehaviour
{
    private List<Question> quizzContent = new List<Question>();

    // Start is called before the first frame update
    void Start()
    {
        List<Answer> list = new List<Answer>();
        list.Add(new Answer("Vrai", true));
        list.Add(new Answer("Faux", false));
        Question question = new Question("L'explosion a été causée par une baisse de pression dans le réservoir ?", list);
        quizzContent.Add(question);

        list = new List<Answer>();
        list.Add(new Answer("3", true));
        list.Add(new Answer("2", false));
        question = new Question("Combien d'astronautes sont décédés dans cet accident ?", list);
        quizzContent.Add(question);

        list = new List<Answer>();
        list.Add(new Answer("Des fortes vibrations", true));
        list.Add(new Answer("Une rotation trop rapide de la fusée", false));
        question = new Question("Qu'est-ce que l'effet POGO ?", list);
        quizzContent.Add(question);

        list = new List<Answer>();
        list.Add(new Answer("Ejection automatique par l'ordinateur de bord", true));
        list.Add(new Answer("Extincteur automatique", false));
        question = new Question("Quelle avancée technologique a sauvé les astronautes ?", list);
        quizzContent.Add(question);
    }

    Question GetQuestion(int index)
    {
        if (index > quizzContent.Count)
            return null;
        return quizzContent[index];
    }
}

class Question
{
    private string value;
    private List<Answer> answers;

    public Question(string value, List<Answer> answers)
    {
        Value = value;
        Answers = answers;
    }

    public string Value { get => value; set => this.value = value; }
    internal List<Answer> Answers { get => answers; set => answers = value; }

    public string GetCorrectAnswer()
    {
        return Answers.Find(answer => answer.Correct).Value;
    }
}

class Answer
{
    private string value;
    private bool correct;

    public Answer(string value, bool correct)
    {
        this.Value = value;
        this.Correct = correct;
    }

    public string Value { get => value; set => this.value = value; }
    public bool Correct { get => correct; set => correct = value; }
}