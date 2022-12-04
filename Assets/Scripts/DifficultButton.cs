using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{
    private Button _difficultGameBttn;
    private GeneratorManager _scriptGeneratorManager;

    public int Difficult;

    // Start is called before the first frame update
    void Start()
    {
        _scriptGeneratorManager = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();
        _difficultGameBttn = GetComponent<Button>();
        _difficultGameBttn.onClick.AddListener(SetDifficult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficult()
    {
        Debug.Log("Pushed: " + gameObject.name);
        _scriptGeneratorManager.WelcomeGame(Difficult);
    }
}
