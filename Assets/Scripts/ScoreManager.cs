using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int m_BestScore { private set; get; }
    public int m_Rings { private set; get; }

    public TMP_Text m_BestScoreText;
    public TMP_Text m_ScoreText;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_BestScore = PlayerPrefs.GetInt("best_score", 0);
        m_BestScoreText.text = "Best:" + m_BestScore.ToString();

        m_ScoreText.text = "Score:" + BrickSpawner.Instance.m_LevelOfFinalBrick.ToString();
    }

    public void AddRingToInventory(int value)
    {
        if (value > 0)
            m_Rings += value;

        PlayerPrefs.SetInt("rings", m_Rings);
    }

    public void UpdateScore()
    {
        if (BrickSpawner.Instance.m_LevelOfFinalBrick > m_BestScore)
        {
            m_BestScore =  BrickSpawner.Instance.m_LevelOfFinalBrick;
            m_BestScoreText.text = "Best:" + m_BestScore.ToString();

            PlayerPrefs.SetInt("best_score", m_BestScore);
        }

        m_ScoreText.text = "Score:" + BrickSpawner.Instance.m_LevelOfFinalBrick.ToString();
    }
}