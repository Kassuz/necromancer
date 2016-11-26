using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float ZombiesSpawned { get; set; }
    public bool SpawnedBeloved { get; set; }

    [SerializeField] private Text victoryText;

    public void GameWon()
    {
        victoryText.enabled = true;
        Time.timeScale = 0;
    }


}
