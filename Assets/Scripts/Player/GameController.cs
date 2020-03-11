using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{
    private ScoreController scoreController;
    public static int end_score = 0;

    /***        SAVE HIGH SCORE PART        ***/

    private List<HighscoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    public Transform[] selectorArr;
    private string path = "highScore";


    /***        USE FOR DEBUG TO DELETE         ***/

    public Text DebugT;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("GameController").GetComponent<ScoreController>();
       // highScore = GameObject.Find("GameController").GetComponent<HighScoreBehavior>();
       string Json_path = Path.Combine(Application.persistentDataPath, "Resources", 
                path + "Mode" + 0 + ".json");
        DebugT.text = Json_path;
    }

    public void GameOver()
    {
        end_score = scoreController.GetScore();
       // GameObject.Find("GameController").GetComponent<HighScoreBehavior>().AddHighscoreEntry(end_score, GameOptions.name, GameOptions.timeMode);
       string Json_path = Path.Combine(Application.persistentDataPath, "Resources", 
                path + "Mode" + 0 + ".json");
        DebugT.text = Json_path;
        if (File.Exists (Json_path))
            File.WriteAllText(Json_path, "json");
        SceneManager.LoadScene(2);
    }

    /***        SAVE HIGH SCORE PART        ***/

    private void Awake()
    {
        Highscore highscore = JsonUtility.FromJson<Highscore>(ReadFileJson(GameOptions.timeMode));


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