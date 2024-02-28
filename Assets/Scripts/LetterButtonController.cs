using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonController : MonoBehaviour
{
    public string color = "b";
    private GameController gameController;
    private bool active = true;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        if (active == true)
        {
            if (color == "b")
            {
                color = "y";
                SetButtonColor("y");
            }
            else if (color == "y")
            {
                color = "g";
                SetButtonColor("g");
            }
            else if (color == "g")
            {
                color = "b";
                SetButtonColor("b");
            }
        }
    }

    void SetButtonColor(string color)
    {
        ColorBlock colors = GetComponent<Button>().colors;
        if (color == "b")
        {
            colors.normalColor = new Color32(120, 124, 126, 255);
            colors.highlightedColor = new Color32(100, 104, 106, 255);
            colors.pressedColor = new Color32(100, 104, 106, 255);
            colors.selectedColor = new Color32(120, 124, 126, 255);
            GetComponent<Button>().colors = colors;
        }
        else if (color == "y")
        {
            colors.normalColor = new Color32(201, 180, 88, 255);
            colors.highlightedColor = new Color32(176, 158, 82, 255);
            colors.pressedColor = new Color32(176, 158, 82, 255);
            colors.selectedColor = new Color32(201, 180, 88, 255);
            GetComponent<Button>().colors = colors;
        }
        else if (color == "g")
        {
            colors.normalColor = new Color32(104, 167, 98, 255);
            colors.highlightedColor = new Color32(87, 142, 82, 255);
            colors.pressedColor = new Color32(87, 142, 82, 255);
            colors.selectedColor = new Color32(104, 167, 98, 255);
            GetComponent<Button>().colors = colors;
        }
    }

    public void Submit()
    {
        gameController.AddColor(color);

        tag = "Non-Active Letter Button";
        active = false;
    }
}
