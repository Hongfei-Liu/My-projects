using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private GameObject planeInstance = null;
    public int score = 0;
    public static float enemyBasicRate1 = 0.5f;

    [SerializeField] private Text scoreText;
    [SerializeField] private string preTextScore = "SCORE: ";

  

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);    // Destory the current gameObject
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = preTextScore + score.ToString("D8");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = preTextScore + score.ToString("D8");
    }

    public void Death()
    {
        Destroy(planeInstance);
    }
}
