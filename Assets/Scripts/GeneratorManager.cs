using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Objectives;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _gameOver;
    [SerializeField] private Button _resetGameBttn;
    [SerializeField] private GameObject _initScreen;

    public bool _gameActive;

    private float Delay = 2.0f;
    private int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int AddPoints)
    {
        Score += AddPoints;
        _score.text = "Score: " + Score;
    }

    public void GameOver()
    {
        _gameActive = false;
        _gameOver.gameObject.SetActive(true);
        _resetGameBttn.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WelcomeGame(int Difficult)
    {
        Delay /= Difficult;
        _gameActive = true;
        StartCoroutine(GenerateObjectives());
        Score = 0;
        UpdateScore(0);
        _initScreen.gameObject.SetActive(false);
    }

    IEnumerator GenerateObjectives()
    {
        while (_gameActive)
        {
            yield return new WaitForSeconds(Delay);
            int index = Random.Range(0, Objectives.Count);
            Instantiate(Objectives[index]);
        }
    }
}
