using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float ZombiesSpawned { get; set; }
    public bool SpawnedBeloved { get; set; }

    [SerializeField] private Text victoryText;
    [SerializeField] private Text loseText;

    public void GameWon()
    {
        victoryText.enabled = true;
        Time.timeScale = 0;
    }

    public void GameLost()
    {
        loseText.enabled = true;
        Time.timeScale = 0;
    }


}
