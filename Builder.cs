
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public  Builder() 
    {

    }

    [SerializeField] private Transform pointBuild;
    [SerializeField] private GameObject roomForBuild;

    public List<string> usedQuestions;

    private GameObject rightRoom, leftRoom, forwardRoom;

    private void Awake()
    {
        usedQuestions = new List<string>();
    }

    private void OnTriggerEnter(Collider other)
    {
        MainBuildRoom();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void MainBuildRoom()
    {
        switch (gameObject.tag)
        {
            case "RightBuilder":

                rightRoom = Instantiate(roomForBuild, pointBuild);
                rightRoom.tag = "RightRoom";
                
                break;

            case "LeftBuilder":
                leftRoom = Instantiate(roomForBuild, pointBuild);
                leftRoom.tag = "LeftRoom";

                break;

            case "ForwardBuilder":
                forwardRoom = Instantiate(roomForBuild, pointBuild);
                forwardRoom.tag = "ForwardRoom";

                break;
        }
      
    }

    public void BuildRightRoom(Transform _pointBuild)
    {

        rightRoom = Instantiate(roomForBuild, _pointBuild);
        rightRoom.tag = "RightRoom";

    }
}
