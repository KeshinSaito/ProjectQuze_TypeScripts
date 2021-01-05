
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerRoom : MonoBehaviour
{
    [Tooltip("Lenght textQustions = lenght questions")]
    [SerializeField] private Text[] questions;

    [Tooltip("Lenght textQustions = lenght questions")]
    [SerializeField] private string[] textsQuestions;

    [SerializeField] private Transform pointBuild;

    public Builder builder;
    private bool isFirstQuestion;

    private void Start()
    {
        GetBuilder();
        SetQustions();
        


    }
    
    private void OnTriggerEnter(Collider other)
    {
        builder.BuildRightRoom(pointBuild);
    }

    private void SetQustions()
    {
        if(builder.usedQuestions.Count == 0)
        {
            isFirstQuestion = true;
            foreach (Text question in questions)
            {
                string placingQustion = textsQuestions[Random.Range(0, textsQuestions.Length - 1)];
                if (!isFirstQuestion)
                {
                    foreach (string usedQuestion in builder.usedQuestions)
                    {
                        if (placingQustion != usedQuestion )
                        {
                            builder.usedQuestions.Add(placingQustion);
                            question.text = placingQustion;
                            isFirstQuestion = false;
                            break;
                        }
                        else
                        {
                            Debug.LogWarning("Qustion >> " + placingQustion + " was placced");
                            continue;
                        }
                    }
                }
                else
                {
                    builder.usedQuestions.Add(placingQustion);
                    question.text = placingQustion;
                    isFirstQuestion = false;
                }
            }
        }
        else if(builder.usedQuestions.Count != 0)
        {
            
            foreach (Text question in questions)
            {
                string placingQustion = textsQuestions[Random.Range(0, textsQuestions.Length-1)];
                foreach (string usedQuestion in builder.usedQuestions)
                {
                   
                    if (usedQuestion != placingQustion)
                    {
                        builder.usedQuestions.Add(placingQustion);
                        question.text = placingQustion;
                        break;
                    } 
                    else if(usedQuestion == placingQustion)
                    {
                        Debug.LogWarning("Qustion >> " + placingQustion + " was placced");
                        continue;
                    }
                }
            }
        }
    }
    private void GetBuilder()
    {
        switch (gameObject.tag)
        {
            case "RightRoom":
                builder = GameObject.FindGameObjectWithTag("RightBuilder").GetComponent<Builder>();
                break;

            case "LeftRoom":
                builder = GameObject.FindGameObjectWithTag("LeftBuilder").GetComponent<Builder>();
                break;

            case "ForwardRoom":
                builder = GameObject.FindGameObjectWithTag("ForwardBuilder").GetComponent<Builder>();
                break;
        }
    }
}
