using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonController : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        gameController.colors = "";
        GameObject letterButton = GameObject.FindGameObjectWithTag("Active Letter Button 1");
        letterButton.GetComponent<LetterButtonController>().Submit();
        letterButton = GameObject.FindGameObjectWithTag("Active Letter Button 2");
        letterButton.GetComponent<LetterButtonController>().Submit();
        letterButton = GameObject.FindGameObjectWithTag("Active Letter Button 3");
        letterButton.GetComponent<LetterButtonController>().Submit();
        letterButton = GameObject.FindGameObjectWithTag("Active Letter Button 4");
        letterButton.GetComponent<LetterButtonController>().Submit();
        letterButton = GameObject.FindGameObjectWithTag("Active Letter Button 5");
        letterButton.GetComponent<LetterButtonController>().Submit();

        gameController.NarrowList();
        gameController.attemptNum += 1;
        gameController.CreateNewOptions();

        Destroy(GameObject.Find("Extras"));
    }
}
