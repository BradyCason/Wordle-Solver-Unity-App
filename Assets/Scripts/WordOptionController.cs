using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordOptionController : MonoBehaviour
{
    private GameController gameController;
    public string word;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWord(string wordToSet, float score)
    {
        word = wordToSet;
        if (word == "" || word == "No Words")
        {
            Destroy(gameObject);
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = word + " - " + score.ToString();
        }
    }

    public void Click()
    {
        gameController.ChooseWord(word);
        Destroy(GameObject.FindGameObjectWithTag("Active Word Options"));
    }
}
