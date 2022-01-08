using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoresNameText;
    private void Start()
    {
        NameScoresManager.Instance.LoadName();
        GameObject.Find("InputName").GetComponent<TMPro.TMP_InputField>().text = NameScoresManager.Instance.inputName;
        NameScoresManager.Instance.LoadHName();
        NameScoresManager.Instance.LoadScores();
        bestScoresNameText.text = "Best Scores :"+ NameScoresManager.Instance.highestinputName + ":" + NameScoresManager.Instance.scores;
    }
    public void StartNew()
    {
        NameScoresManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
