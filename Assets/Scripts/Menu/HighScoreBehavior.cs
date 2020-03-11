using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoreBehavior : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    public Transform[] selectorArr;
    private string path = "highScore";


    private void Awake()
    {
        entryContainer = transform.Find("Score Panel");
        entryTemplate = entryContainer.Find("Score Infos");

        entryTemplate.gameObject.SetActive(false);

        int d = 0;
        Highscore highscore = JsonUtility.FromJson<Highscore>(ReadFileJson(d));


        for (int i = 0; i < highscore.highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscore.highScoreEntryList.Count; j++)
            {
                if (highscore.highScoreEntryList[j].score < highscore.highScoreEntryList[i].score){
                HighscoreEntry tmp = highscore.highScoreEntryList[i];
                highscore.highScoreEntryList[i] = highscore.highScoreEntryList[j];
                highscore.highScoreEntryList[j] = tmp;
                }
            }
        }
        highScoreEntryTransformList = new List<Transform>();

        
        selectorArr = new Transform[10];

        for (int i = 0; i < 5; i++){
            CreateArrayInfoScore( entryContainer, highScoreEntryTransformList, i);
        }
          UpdateHighScore(0);
    }

    public void UpdateHighScore(int SelectedTimeMode)
    {
        Highscore highscore = JsonUtility.FromJson<Highscore>(ReadFileJson(SelectedTimeMode));



        for (int i = 0; i < highscore.highScoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscore.highScoreEntryList.Count; j++)
            {
                if (highscore.highScoreEntryList[j].score < highscore.highScoreEntryList[i].score){
                HighscoreEntry tmp = highscore.highScoreEntryList[i];
                highscore.highScoreEntryList[i] = highscore.highScoreEntryList[j];
                highscore.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        for (int i = 0; i < 5; i++)
        {
            CreateHighscoreEntryTransform(highscore.highScoreEntryList[i], i, highScoreEntryTransformList);
        }
    }

    private void CreateArrayInfoScore( Transform container, List<Transform> transformList, int rank)
    {
        float templateHeight = 25f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        if (rank < 5)
            entryRectTransform.anchoredPosition = new Vector2(0f, -templateHeight * rank + 55f);
       /* else
            entryRectTransform.anchoredPosition = new Vector2(100f, -templateHeight * (rank - 5) + 55f); */
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("number").GetComponent<Text>().text = (rank + 1).ToString();
        entryTransform.Find("name").GetComponent<Text>().text = "TRON";
        entryTransform.Find("score").GetComponent<Text>().text = "00000";

        transformList.Add(entryTransform);
        selectorArr[rank] = entryTransform;
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highScoreEntry, int rank, List<Transform> transformList)
    {
        int score = highScoreEntry.score;
        Debug.Log("it's " + rank + " time we iterrate in create high score entry transform");
        selectorArr[rank].Find("number").GetComponent<Text>().text = (rank + 1).ToString();
        selectorArr[rank].Find("name").GetComponent<Text>().text = highScoreEntry.name;
        selectorArr[rank].Find("score").GetComponent<Text>().text = score.ToString();
    }

    public void AddHighscoreEntry(int score, string name, int SelectedTimeMode){
        HighscoreEntry highScoreEntry = new HighscoreEntry {score = score, name = name};
        
       // string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscore highscore = JsonUtility.FromJson<Highscore>(ReadFileJson(SelectedTimeMode));

        highscore.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highscore);
        WriteFileJson(json, SelectedTimeMode);
    } 

    private void WriteFileJson(string json, int SelectedTimeMode)
    {
        //File.WriteAllText(path + "Mode" + SelectedTimeMode + ".json", string.Empty);
        //Write some text to the test.txt file
        //StreamWriter writer = new StreamWriter(path + "Mode" + SelectedTimeMode + ".json", true);
        //TextAsset theList = Resources.Load<TextAsset>(path + "Mode" + SelectedTimeMode);
        //theList.text = json;
        string Json_path = Path.Combine(Application.persistentDataPath, "Resources", 
                path + "Mode" + SelectedTimeMode + ".json");

        File.WriteAllText(Json_path, json);
    }

    private string ReadFileJson(int SelectedTimeMode)
    {
        //Read the text from directly from the test.txt file
        TextAsset theList = Resources.Load<TextAsset>(path + "Mode" + SelectedTimeMode);
        string result = theList.text;

        return result;
    }

    private class Highscore{
        public List<HighscoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}