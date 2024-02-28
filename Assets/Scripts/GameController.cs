using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string colors = "";
    public GameObject wordOptions;
    public GameObject wordprefab;
    private List<string> wordList;
    public float attemptNum = 0;
    private float[] posOfWord = new float[] { -200f, -350, -500f, -650f, -800f, -950f, -1100f };
    public string guess = "";
    public GameObject directions;
    public GameObject wordsLeft;
    public GameObject wordsLeftText;
    public GameObject loserText;
    public GameObject guessInput1;
    public GameObject guessInput2;
    public GameObject guessInput3;
    public GameObject guessInput4;
    public GameObject guessInput5;
    public GameObject nextGuessInput;

    //Variables for FrequencyOfPositions()
    private float a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z = 0;

    //Variables for FrequencyOfPositions()
    private string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    //Variables for BestWord()
    private List<string> sameLetters = new List<string> { "1", "2", "3", "4", "5" };
    private List<string> differentLetters = new List<string>();
    private string currentBestWord = "No Word";
    private string currentBestWord2 = "";
    private string currentBestWord3 = "";
    private float highestScore = 0;
    private float secondScore = 0;
    private float thirdScore = 0;
    private Dictionary<string, float> letterFrequencies;
    private Dictionary<float, Dictionary<string, float>> positionFrequencies;
    private string possibleNextGuess = "";
    private float possibleNextGuessScore = 0;

    private string[] originalWordList = System.IO.File.ReadAllLines("Assets/Files/Wordle Common Words.txt");
    // Start is called before the first frame update
    void Start()
    {
        wordList = new List<string>(originalWordList);
        
        if (SceneManager.GetActiveScene().name == "OptimalSolveScene")
        {
            CreateNewOptions();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Dictionary<string,float> FrequencyOfRemaining(List<string> wordList)
    {
        a = 0;b = 0;c = 0;d = 0;e = 0;f = 0;g = 0;h = 0;i = 0;j = 0;k = 0;l = 0;m = 0;n = 0;o = 0;p = 0;q = 0;r = 0;s = 0;t = 0;u = 0;v = 0;w = 0;x = 0;y = 0;z = 0;
        foreach (string word in wordList)
        {
            List<string> lettersUsed = new List<string>();
            foreach (int index in Enumerable.Range(0, 5))
            {
                if (word.Substring(index,1) == "a" && lettersUsed.Contains("a") == false )
                {
                    a += 1;
                    lettersUsed.Add("a");
                }
                else if (word.Substring(index, 1) == "b" && lettersUsed.Contains("b") == false)
                {
                    b += 1;
                    lettersUsed.Add("b");
                }
                else if (word.Substring(index, 1) == "c" && lettersUsed.Contains("c") == false)
                {
                    c += 1;
                    lettersUsed.Add("c");
                }
                else if (word.Substring(index, 1) == "d" && lettersUsed.Contains("d") == false)
                {
                    d += 1;
                    lettersUsed.Add("d");
                }
                else if (word.Substring(index, 1) == "e" && lettersUsed.Contains("e") == false)
                {
                    e += 1;
                    lettersUsed.Add("e");
                }
                else if (word.Substring(index, 1) == "f" && lettersUsed.Contains("f") == false)
                {
                    f += 1;
                    lettersUsed.Add("f");
                }
                else if (word.Substring(index, 1) == "g" && lettersUsed.Contains("g") == false)
                {
                    g += 1;
                    lettersUsed.Add("g");
                }
                else if (word.Substring(index, 1) == "h" && lettersUsed.Contains("h") == false)
                {
                    h += 1;
                    lettersUsed.Add("h");
                }
                else if (word.Substring(index, 1) == "i" && lettersUsed.Contains("i") == false)
                {
                    i += 1;
                    lettersUsed.Add("i");
                }
                else if (word.Substring(index, 1) == "j" && lettersUsed.Contains("j") == false)
                {
                    j += 1;
                    lettersUsed.Add("j");
                }
                else if (word.Substring(index, 1) == "k" && lettersUsed.Contains("k") == false)
                {
                    k += 1;
                    lettersUsed.Add("k");
                }
                else if (word.Substring(index, 1) == "l" && lettersUsed.Contains("l") == false)
                {
                    l += 1;
                    lettersUsed.Add("l");
                }
                else if (word.Substring(index, 1) == "m" && lettersUsed.Contains("m") == false)
                {
                    m += 1;
                    lettersUsed.Add("m");
                }
                else if (word.Substring(index, 1) == "n" && lettersUsed.Contains("n") == false)
                {
                    n += 1;
                    lettersUsed.Add("n");
                }
                else if (word.Substring(index, 1) == "o" && lettersUsed.Contains("o") == false)
                {
                    o += 1;
                    lettersUsed.Add("o");
                }
                else if (word.Substring(index, 1) == "p" && lettersUsed.Contains("p") == false)
                {
                    p += 1;
                    lettersUsed.Add("p");
                }
                else if (word.Substring(index, 1) == "q" && lettersUsed.Contains("q") == false)
                {
                    q += 1;
                    lettersUsed.Add("q");
                }
                else if (word.Substring(index, 1) == "r" && lettersUsed.Contains("r") == false)
                {
                    r += 1;
                    lettersUsed.Add("r");
                }
                else if (word.Substring(index, 1) == "s" && lettersUsed.Contains("s") == false)
                {
                    s += 1;
                    lettersUsed.Add("s");
                }
                else if (word.Substring(index, 1) == "t" && lettersUsed.Contains("t") == false)
                {
                    t += 1;
                    lettersUsed.Add("t");
                }
                else if (word.Substring(index, 1) == "u" && lettersUsed.Contains("u") == false)
                {
                    u += 1;
                    lettersUsed.Add("u");
                }
                else if (word.Substring(index, 1) == "v" && lettersUsed.Contains("v") == false)
                {
                    v += 1;
                    lettersUsed.Add("v");
                }
                else if (word.Substring(index, 1) == "w" && lettersUsed.Contains("w") == false)
                {
                    w += 1;
                    lettersUsed.Add("w");
                }
                else if (word.Substring(index, 1) == "x" && lettersUsed.Contains("x") == false)
                {
                    x += 1;
                    lettersUsed.Add("x");
                }
                else if (word.Substring(index, 1) == "y" && lettersUsed.Contains("y") == false)
                {
                    y += 1;
                    lettersUsed.Add("y");
                }
                else if (word.Substring(index, 1) == "z" && lettersUsed.Contains("z") == false)
                {
                    z += 1;
                    lettersUsed.Add("z");
                }

            }
        }
        return new Dictionary<string, float> { { "a", a },{ "b",b }, { "c", c }, { "d", d }, { "e", e }, { "f", f }, { "g", g }, { "h", h }, { "i", i }, { "j", j }, { "k", k }, { "l", l }, { "m", m }, { "n", n }, { "o", o }, { "p", p }, { "q", q }, { "r", r }, { "s", s }, { "t", t }, { "u", u }, { "v", v }, { "w", w }, { "x", x }, { "y", y }, { "z", z }, };
    }

    private Dictionary<float,Dictionary<string,float>> FrequencyOfPositions(List<string> wordList)
    {
        Dictionary<float, Dictionary<string, float>> positions = new Dictionary<float, Dictionary<string, float>> { { 0, new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } } }, { 1, new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } } }, { 2, new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } } }, { 3, new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } } }, { 4, new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } } } };
        foreach (string word in wordList)
        {
            foreach (int index in Enumerable.Range(0, 5))
            {
                foreach (string letter in alphabet)
                {
                    if (word.Substring(index,1) == letter)
                    {
                        positions[index][letter] += 1;
                    }
                }
            }
        }
        return positions;
    }
    
    public void NarrowList()
    {
        List<string> blackLetters = new List<string>();
        Dictionary<float, string> yellowLetters = new Dictionary<float, string>();
        Dictionary<float, string> greenLetters = new Dictionary<float, string>();

        //Create greenLetters list
        foreach (int i in Enumerable.Range(0, 5))
        {
            if (colors.Substring(i,1) == "g")
            {
                greenLetters.Add(i, guess.Substring(i, 1));
            }
        }

        //Create yellowLetters list
        foreach (int i in Enumerable.Range(0, 5))
        {
            if(colors.Substring(i,1) == "y")
            {
                yellowLetters.Add(i,guess.Substring(i, 1));
            }
        }

        //Create blackLetters list
        foreach (int i in Enumerable.Range(0, 5))
        {
            if (colors.Substring(i, 1) == "b")
            {
                blackLetters.Add(guess.Substring(i, 1));
            }
        }

        //Remove if has a black letter
        List<string> wordsToRemove = new List<string>();
        foreach (string word in wordList)
        {
            foreach (int i in Enumerable.Range(0, 5))
            {
                //remove if has a black letter
                if (blackLetters.Contains(word.Substring(i,1)) == true && wordsToRemove.Contains(word) == false)
                {
                    //Find number of green letters that are the same as the black letter and the number of that letter in the word
                    float numGreenOrYellow = 0;
                    float numThatLetter = 0;
                    foreach(int j in Enumerable.Range(0, 5))
                    {
                        if (greenLetters.Keys.Contains(j) == true)
                        {
                            if (greenLetters[j] == word.Substring(i, 1))
                            {
                                numGreenOrYellow += 1;
                            }
                        }
                        if (yellowLetters.Keys.Contains(j) == true)
                        {
                            if (yellowLetters[j] == word.Substring(i, 1))
                            {
                                numGreenOrYellow += 1;
                            }
                        }
                        if (word.Substring(j,1) == word.Substring(i, 1))
                        {
                            numThatLetter += 1;
                        }
                    }
                    if (numThatLetter > numGreenOrYellow)
                    {
                        wordsToRemove.Add(word);
                    }
                }
                //Remove if does not have a green letter at that spot
                if (greenLetters.Keys.Contains(i))
                {
                    if (greenLetters[i] != word.Substring(i,1) && wordsToRemove.Contains(word) == false)
                    {
                        wordsToRemove.Add(word);
                    }
                }
                //Remove if has a yellow letter at that spot
                if (yellowLetters.Keys.Contains(i))
                {
                    if (yellowLetters[i] == word.Substring(i, 1) && wordsToRemove.Contains(word) == false)
                    {
                        wordsToRemove.Add(word);
                    }
                }
            }
            foreach (string yellowLetter in yellowLetters.Values)
            {
                if (word.Contains(yellowLetter) == false && wordsToRemove.Contains(word) == false)
                {
                    wordsToRemove.Add(word);
                }
            }
        }
        //Remove wordsToRemove
        foreach (string wordToRemove in wordsToRemove)
        {
            wordList.Remove(wordToRemove);
        }
    }

    private Dictionary<string[],float[]> BestWord(float attemptNum, List<string> wordList)
    {
        letterFrequencies = FrequencyOfRemaining(wordList);
        positionFrequencies = FrequencyOfPositions(wordList);

        //Check if special case
        float[] numTo5 = new float[] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
        bool specialCase = false;
        if (attemptNum < 5 && wordList.Count() >2 && wordList.Count() < 10)
        {
            sameLetters = new List<string> { "1", "2", "3", "4", "5" };
            differentLetters = new List<string>();
            string letter1 = "a";
            string letter2 = "a";
            string letter3 = "a";
            string letter4 = "a";
            string letter5 = "a";
            foreach (int i in Enumerable.Range(0, wordList.Count()))
            {
                if(i == 0)
                {
                    letter1 = wordList[i].Substring(0, 1);
                    letter2 = wordList[i].Substring(1, 1);
                    letter3 = wordList[i].Substring(2, 1);
                    letter4 = wordList[i].Substring(3, 1);
                    letter5 = wordList[i].Substring(4, 1);
                }
                else
                {
                    if (wordList[i].Substring(0, 1) != letter1)
                    {
                        differentLetters.Add(wordList[i].Substring(0, 1));
                        if (differentLetters.Contains(letter1) == false)
                        {
                            differentLetters.Add(letter1);
                        }
                        if (sameLetters.Contains("1") == true)
                        {
                            sameLetters.Remove("1");
                        }
                    }
                    if (wordList[i].Substring(1, 1) != letter2)
                    {
                        differentLetters.Add(wordList[i].Substring(1, 1));
                        if (differentLetters.Contains(letter2) == false)
                        {
                            differentLetters.Add(letter2);
                        }
                        if (sameLetters.Contains("2") == true)
                        {
                            sameLetters.Remove("2");
                        }
                    }
                    if (wordList[i].Substring(2, 1) != letter3)
                    {
                        differentLetters.Add(wordList[i].Substring(2, 1));
                        if (differentLetters.Contains(letter3) == false)
                        {
                            differentLetters.Add(letter3);
                        }
                        if (sameLetters.Contains("3") == true)
                        {
                            sameLetters.Remove("3");
                        }
                    }
                    if (wordList[i].Substring(3, 1) != letter4)
                    {
                        differentLetters.Add(wordList[i].Substring(3, 1));
                        if (differentLetters.Contains(letter4) == false)
                        {
                            differentLetters.Add(letter4);
                        }
                        if (sameLetters.Contains("4") == true)
                        {
                            sameLetters.Remove("4");
                        }
                    }
                    if (wordList[i].Substring(4, 1) != letter5)
                    {
                        differentLetters.Add(wordList[i].Substring(4, 1));
                        if (differentLetters.Contains(letter5) == false)
                        {
                            differentLetters.Add(letter5);
                        }
                        if (sameLetters.Contains("5") == true)
                        {
                            sameLetters.Remove("5");
                        }
                    }
                }
            }
            if (sameLetters.Count() >= 3)
            {
                specialCase = true;
            }
        }
        //Add scores for each word
        if (specialCase == true)
        {
            //Special Case
            highestScore = 0;
            secondScore = 0;
            thirdScore = 0;
            currentBestWord = "No Words";
            currentBestWord2 = "";
            currentBestWord3 = "";
            foreach (string word in originalWordList)
            {
                List<string> lettersUsed = new List<string>();
                List<string> wordsLeftUsed = new List<string>();
                float wordScore = 0;
                foreach (int i in Enumerable.Range(0, 5))
                {
                    bool wordHasBeenUsed = false;
                    foreach (string wordLeftUsed in wordsLeftUsed)
                    {
                        if (wordLeftUsed.Contains(word.Substring(i,1)) == true)
                        {
                            wordHasBeenUsed = true;
                        }
                    }
                    if (differentLetters.Contains(word.Substring(i,1)) == true && lettersUsed.Contains(word.Substring(i, 1)) == false)
                    {
                        if (wordHasBeenUsed == false)
                        {
                            wordScore += 10;
                        }
                        else
                        {
                            wordScore += 5;
                        }
                        foreach (string wordLeft in wordList)
                        {
                            //wordLeft.Replace(word.Substring(i, 1), " ");
                            if (wordLeft.Contains(word.Substring(i, 1)) == true)
                            {
                                wordsLeftUsed.Add(wordLeft);
                            }
                        }
                    }
                    lettersUsed.Add(word.Substring(i, 1));
                }
                //Check if is a high score
                if (wordScore > highestScore)
                {
                    currentBestWord3 = currentBestWord2;
                    currentBestWord2 = currentBestWord;
                    currentBestWord = word;
                    thirdScore = secondScore;
                    secondScore = highestScore;
                    highestScore = wordScore;
                }
                else if (wordScore > secondScore)
                {
                    currentBestWord3 = currentBestWord2;
                    currentBestWord2 = word;
                    thirdScore = secondScore;
                    secondScore = wordScore;
                }
                else if (wordScore > thirdScore)
                {
                    currentBestWord3 = word;
                    thirdScore = wordScore;
                }
            }
            if (highestScore <= 15)
            {
                specialCase = false;
            }
        }
        if (specialCase == false)
        {
            //Normal Case
            highestScore = 0;
            secondScore = 0;
            thirdScore = 0;
            currentBestWord = "No Words";
            currentBestWord2 = "";
            currentBestWord3 = "";
            foreach (string word in wordList)
            {
                List<string> lettersUsed = new List<string>();
                float wordScore = 0;
                foreach (int i in Enumerable.Range(0, 5))
                {
                    if (lettersUsed.Contains(word.Substring(i,1)) == true)
                    {
                        wordScore += letterFrequencies[word.Substring(i,1)] / 5;
                        wordScore += positionFrequencies[i][word.Substring(i, 1)];
                    }
                    else
                    {
                        wordScore += letterFrequencies[word.Substring(i, 1)];
                        wordScore += positionFrequencies[i][word.Substring(i, 1)];
                        lettersUsed.Add(word.Substring(i, 1));
                    }
                }
                //Check if is a high score
                if (wordScore > highestScore)
                {
                    currentBestWord3 = currentBestWord2;
                    currentBestWord2 = currentBestWord;
                    currentBestWord = word;
                    thirdScore = secondScore;
                    secondScore = highestScore;
                    highestScore = wordScore;
                }
                else if (wordScore > secondScore)
                {
                    currentBestWord3 = currentBestWord2;
                    currentBestWord2 = word;
                    thirdScore = secondScore;
                    secondScore = wordScore;
                }
                else if (wordScore > thirdScore)
                {
                    currentBestWord3 = word;
                    thirdScore = wordScore;
                }
            }

            //Posible Next Guess score
            if (possibleNextGuess.Count() == 5)
            {
                List<string> lettersUsed = new List<string>();
                possibleNextGuessScore = 0;
                foreach (int i in Enumerable.Range(0, 5))
                {
                    if (lettersUsed.Contains(possibleNextGuess.Substring(i, 1)) == true)
                    {
                        possibleNextGuessScore += letterFrequencies[possibleNextGuess.Substring(i, 1)] / 5;
                        possibleNextGuessScore += positionFrequencies[i][possibleNextGuess.Substring(i, 1)];
                    }
                    else
                    {
                        possibleNextGuessScore += letterFrequencies[possibleNextGuess.Substring(i, 1)];
                        possibleNextGuessScore += positionFrequencies[i][possibleNextGuess.Substring(i, 1)];
                        lettersUsed.Add(possibleNextGuess.Substring(i, 1));
                    }
                }
                possibleNextGuessScore = (float)System.Math.Round(possibleNextGuessScore / highestScore, 3);
            }
        }
        string[] wordsToReturn = { currentBestWord, currentBestWord2, currentBestWord3 };
        float[] scoresToReturn = { 1, (float)System.Math.Round(secondScore / highestScore , 3), (float)System.Math.Round(thirdScore / highestScore, 3) };
        Dictionary<string[], float[]> dictionaryToReturn = new Dictionary<string[], float[]> { { wordsToReturn, scoresToReturn } };
        return dictionaryToReturn;
    }

    public void AddColor(string colorToAdd)
    {
        colors += colorToAdd;
    }

    public void CreateNewOptions()
    {
        Dictionary<string[],float[]> options = BestWord(attemptNum, wordList);
        GameObject wordOptionsGO = Instantiate(wordOptions, new Vector3(0, posOfWord[(int) attemptNum], 0), wordOptions.transform.rotation);
        wordOptionsGO.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        wordOptionsGO.transform.SetSiblingIndex(0);
        GameObject.FindWithTag("Active Word Option 1").GetComponent<WordOptionController>().SetWord(options.Keys.ToArray()[0][0], options.Values.ToArray()[0][0]);
        GameObject.FindWithTag("Active Word Option 2").GetComponent<WordOptionController>().SetWord(options.Keys.ToArray()[0][1], options.Values.ToArray()[0][1]);
        GameObject.FindWithTag("Active Word Option 3").GetComponent<WordOptionController>().SetWord(options.Keys.ToArray()[0][2], options.Values.ToArray()[0][2]);
        if (options.Keys.ToArray()[0][0] == "No Words")
        {
            GameObject.FindWithTag("Choose Next Word Text").GetComponent<TextMeshProUGUI>().text = "No words. Did you make a mistake?";
        }
        else if (colors == "ggggg")
        {
            GameObject.FindWithTag("Choose Next Word Text").GetComponent<TextMeshProUGUI>().text = "You got the word!";
            Destroy(GameObject.FindWithTag("Active Word Option 1"));
        }
        else if (attemptNum >= 6 )
        {
            Destroy(GameObject.FindWithTag("Active Word Options"));
            loserText.SetActive(true);
        }
    }

    private void PrintAllValuesIn(List<string> list)
    {
        foreach (string x in list)
        {
            Debug.Log(x);
        }
    }

    public void ChooseWord(string wordToChoose)
    {
        guess = wordToChoose;
        GameObject wordGO = Instantiate(wordprefab, new Vector3(0, posOfWord[(int)attemptNum], 0), wordprefab.transform.rotation);
        wordGO.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        wordGO.transform.SetSiblingIndex(0);
        GameObject.FindWithTag("Active Letter Button 1").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guess.Substring(0,1);
        GameObject.FindWithTag("Active Letter Button 2").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guess.Substring(1, 1);
        GameObject.FindWithTag("Active Letter Button 3").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guess.Substring(2, 1);
        GameObject.FindWithTag("Active Letter Button 4").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guess.Substring(3, 1);
        GameObject.FindWithTag("Active Letter Button 5").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guess.Substring(4, 1);
    }

    public void PerformBestGuessScene()
    {
        wordList = new List<string>(originalWordList);
        if (guessInput1.GetComponent<InputField>().text.Count() == 5)
        {
            attemptNum = 0;
            guess = guessInput1.GetComponent<InputField>().text.ToLower();
            colors = "";
            colors += GameObject.Find("Letter Button 1 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 2 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 3 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 4 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 5 - 1").GetComponent<LetterButtonController>().color;
            NarrowList();

            if (guessInput2.GetComponent<InputField>().text.Count() == 5)
            {
                attemptNum = 1;
                guess = guessInput2.GetComponentInChildren<InputField>().text.ToLower();
                colors = "";
                colors += GameObject.Find("Letter Button 1 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 2 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 3 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 4 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 5 - 2").GetComponent<LetterButtonController>().color;
                NarrowList();

                if (guessInput3.GetComponent<InputField>().text.Count() == 5)
                {
                    attemptNum = 2;
                    guess = guessInput3.GetComponentInChildren<InputField>().text.ToLower();
                    colors = "";
                    colors += GameObject.Find("Letter Button 1 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 2 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 3 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 4 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 5 - 3").GetComponent<LetterButtonController>().color;
                    NarrowList();

                    if (guessInput4.GetComponent<InputField>().text.Count() == 5)
                    {

                        attemptNum = 3; 
                        guess = guessInput4.GetComponentInChildren<InputField>().text.ToLower();
                        colors = "";
                        colors += GameObject.Find("Letter Button 1 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 2 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 3 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 4 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 5 - 4").GetComponent<LetterButtonController>().color;
                        NarrowList();

                        if (guessInput5.GetComponent<InputField>().text.Count() == 5)
                        {
                            attemptNum = 4;
                            guess = guessInput5.GetComponentInChildren<InputField>().text.ToLower();
                            colors = "";
                            colors += GameObject.Find("Letter Button 1 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 2 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 3 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 4 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 5 - 5").GetComponent<LetterButtonController>().color;
                            NarrowList();
                        }
                    }
                }
            }
        }

        string bestGuess = BestWord(attemptNum, wordList).Keys.ToArray()[0][0];
        wordsLeft.SetActive(true);

        string wordsLeftString = "\u2022  Best guess #" + (attemptNum + 2).ToString() + ": <b>" + bestGuess + "</b>\n\n\u2022  Words left:\n";
        if (wordList.Count() > 0)
        {
            foreach (string word in wordList)
            {
                wordsLeftString += word + ", ";
            }
            wordsLeftText.GetComponent<TextMeshProUGUI>().text = wordsLeftString.Substring(0, wordsLeftString.Length - 2);
        }
        else
        {
            wordsLeftString += "No Words Left";
            wordsLeftText.GetComponent<TextMeshProUGUI>().text = wordsLeftString;
        }
    }

    public void PerformTestGuessScene()
    {
        wordList = new List<string>(originalWordList);
        if (guessInput1.GetComponent<InputField>().text.Count() == 5)
        {
            attemptNum = 0;
            guess = guessInput1.GetComponent<InputField>().text.ToLower();
            colors = "";
            colors += GameObject.Find("Letter Button 1 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 2 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 3 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 4 - 1").GetComponent<LetterButtonController>().color;
            colors += GameObject.Find("Letter Button 5 - 1").GetComponent<LetterButtonController>().color;
            NarrowList();

            if (guessInput2.GetComponent<InputField>().text.Count() == 5)
            {
                attemptNum = 1;
                guess = guessInput2.GetComponentInChildren<InputField>().text.ToLower();
                colors = "";
                colors += GameObject.Find("Letter Button 1 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 2 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 3 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 4 - 2").GetComponent<LetterButtonController>().color;
                colors += GameObject.Find("Letter Button 5 - 2").GetComponent<LetterButtonController>().color;
                NarrowList();

                if (guessInput3.GetComponent<InputField>().text.Count() == 5)
                {
                    attemptNum = 2;
                    guess = guessInput3.GetComponentInChildren<InputField>().text.ToLower();
                    colors = "";
                    colors += GameObject.Find("Letter Button 1 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 2 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 3 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 4 - 3").GetComponent<LetterButtonController>().color;
                    colors += GameObject.Find("Letter Button 5 - 3").GetComponent<LetterButtonController>().color;
                    NarrowList();

                    if (guessInput4.GetComponent<InputField>().text.Count() == 5)
                    {

                        attemptNum = 3;
                        guess = guessInput4.GetComponentInChildren<InputField>().text.ToLower();
                        colors = "";
                        colors += GameObject.Find("Letter Button 1 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 2 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 3 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 4 - 4").GetComponent<LetterButtonController>().color;
                        colors += GameObject.Find("Letter Button 5 - 4").GetComponent<LetterButtonController>().color;
                        NarrowList();

                        if (guessInput5.GetComponent<InputField>().text.Count() == 5)
                        {
                            attemptNum = 4;
                            guess = guessInput5.GetComponentInChildren<InputField>().text.ToLower();
                            colors = "";
                            colors += GameObject.Find("Letter Button 1 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 2 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 3 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 4 - 5").GetComponent<LetterButtonController>().color;
                            colors += GameObject.Find("Letter Button 5 - 5").GetComponent<LetterButtonController>().color;
                            NarrowList();
                        }
                    }
                }
            }
        }

        wordsLeft.SetActive(true);
        possibleNextGuess = nextGuessInput.GetComponent<InputField>().text.ToLower();

        string bestGuess = BestWord(attemptNum, wordList).Keys.ToArray()[0][0];

        string wordsLeftString = "Score for <b>" + possibleNextGuess + "</b> as guess #" + (attemptNum + 1).ToString() + ": <b>" + possibleNextGuessScore.ToString()  + "</b>";
        wordsLeftText.GetComponent<TextMeshProUGUI>().text = wordsLeftString;
    }

    public void ExitDirections()
    {
        directions.SetActive(false);
    }

    public void EnterDirections()
    {
        directions.SetActive(true);
        ExitWordsLeft();
    }

    public void ExitWordsLeft()
    {
        wordsLeft.SetActive(false);
    }

    public void EnterWordsLeft()
    {
        wordsLeft.SetActive(true);
        ExitDirections();

        //set text
        string text = "";
        if (wordList.Count() > 0)
        {
            foreach (string word in wordList)
            {
                text += word + ", ";
            }
            wordsLeftText.GetComponent<TextMeshProUGUI>().text = text.Substring(0, text.Length - 2);
        }
        else
        {
            wordsLeftText.GetComponent<TextMeshProUGUI>().text = "No Words Left";
        }
    }

    private float Wordle(string answer)
    {
        Dictionary<string, float> numEachLetterInAnswer = new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 },{ "z", 0 } };
        foreach (int i in Enumerable.Range(0, 5))
        {
            numEachLetterInAnswer[answer.Substring(i, 1)] += 1;
        }

        foreach (int j in Enumerable.Range(0, 11))
        {
            guess = BestWord(j, wordList).Keys.ToArray()[0][0];
            colors = "";

            Dictionary<string, float> numYellowsUsed = new Dictionary<string, float> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 }, { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 }, { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 } };
            foreach (int i in Enumerable.Range(0, 5))
            {
                if (guess.Substring(i,1) == answer.Substring(i, 1))
                {
                    colors += "g";
                }
                else if (answer.Contains(guess.Substring(i, 1)))
                {
                    if (numYellowsUsed[guess.Substring(i, 1)] < numEachLetterInAnswer[guess.Substring(i, 1)])
                    {
                        colors += "y";
                        numYellowsUsed[guess.Substring(i, 1)] += 1;
                    }
                    else
                    {
                        colors += "b";
                    }
                }
                else
                {
                    colors += "b";
                }
            }
            if (guess == answer)
            {
                return j + 1;
            }
            else
            {
                NarrowList();
            }
        }
        return 100;
    }

    private void SimulateWordle()
    {
        float num1 = 0;
        float num2 = 0;
        float num3 = 0;
        float num4 = 0;
        float num5 = 0;
        float num6 = 0;
        float num7 = 0;
        float num8 = 0;
        float num9 = 0;
        float num10 = 0;

        foreach (int n in Enumerable.Range(0, 2315))
        {
            wordList = new List<string>(originalWordList);
            string answer = wordList[n];

            float num = Wordle(answer);
            if (num == 1)
            {
                num1 += 1;
            }
            else if (num == 2)
            {
                num2 += 1;
            }
            else if (num == 3)
            {
                num3 += 1;
            }
            else if (num == 4)
            {
                num4 += 1;
            }
            else if (num == 5)
            {
                num5 += 1;
            }
            else if (num == 6)
            {
                num6 += 1;
            }
            else if (num == 7)
            {
                num7 += 1;
            }
            else if (num == 8)
            {
                num8 += 1;
            }
            else if (num == 9)
            {
                num9 += 1;
            }
            else if (num == 10)
            {
                num10 += 1;
            }
        }
        Debug.Log(num1);
        Debug.Log(num2);
        Debug.Log(num3);
        Debug.Log(num4);
        Debug.Log(num5);
        Debug.Log(num6);
        Debug.Log(num7);
        Debug.Log(num8);
        Debug.Log(num9);
        Debug.Log(num10);
    }

    public void OpenOptimalSolveScene()
    {
        SceneManager.LoadScene("OptimalSolveScene");
    }

    public void OpenBestGuessScene()
    {
        SceneManager.LoadScene("BestGuessScene");
    }

    public void OpenTestGuessScene()
    {
        SceneManager.LoadScene("TestGuessScene");
    }
}
