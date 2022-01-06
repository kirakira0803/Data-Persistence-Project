using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public Text highScoreTest;

    private void OnCollisionEnter(Collision other)
    {
        NameScoresManager.Instance.LoadScores();
        if (NameScoresManager.Instance.scores < Manager.m_Points)
        {
            NameScoresManager.Instance.LoadName();
            NameScoresManager.Instance.SaveScores(Manager.m_Points);
            NameScoresManager.Instance.SaveHName();
            highScoreTest.text = "Best Score :" + NameScoresManager.Instance.inputName + ":" + Manager.m_Points;
        }
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
