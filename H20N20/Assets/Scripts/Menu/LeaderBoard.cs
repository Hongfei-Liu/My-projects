using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeaderBoard : MonoBehaviour
{
    private Transform container;
    private Transform template;
    private List<Transform> highscoreEntryTransormList;
    private GameManager manage;

    private void Awake()
    {
        manage = GameManager.instance;
        //manage.score = container; //用 Gamemanager里的数值去代替container里的数值
        container = transform.Find("HighScoreContainer");
        template = container.Find("HighScoreTemplate");

        template.gameObject.SetActive(false);

        AddHighscoreEntry(100000, "LJL");

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        /*
        if (highscores == null) {
            
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(2000000, "LJL");
            AddHighscoreEntry(897621, "JOE");
            AddHighscoreEntry(872931, "DAV");
            AddHighscoreEntry(785123, "CAT");
            AddHighscoreEntry(542024, "MAX");
            AddHighscoreEntry(68245, "AAA");
            
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }
        */
            
        


        for (int i = 0; i< highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j< highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        highscoreEntryTransormList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, container, highscoreEntryTransormList);
        }
        /*
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
       string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("LeaderBoard", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("LeaderBoard")); 
        */
    }

    
    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform Container, List<Transform> transformList)
    {
        float templateHeight = 40f;
      
            Transform entryTransform = Instantiate(template, Container);
            RectTransform entryRecTransform = entryTransform.GetComponent<RectTransform>();
            entryRecTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string Rank;
            switch (rank)
            {
                default:
                    Rank = rank + "TH";
                    break;

                case 1:
                    Rank = "1ST";
                    break;
                case 2:
                    Rank = "2ND";
                    break;
                case 3:
                    Rank = "3RD";
                    break;
            }
            entryTransform.Find("Pos").GetComponent<Text>().text = Rank;

            string name = highscoreEntry.name;

            entryTransform.Find("Name").GetComponent<Text>().text = name;

            int score = highscoreEntry.score;

            entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

            transformList.Add(entryTransform);
     
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntryList.Add(highScoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
