using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PlayerManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerHighestScore
    {
        public string playerName;
        public int playerScore = 0;
    }
    
    // Start is called before the first frame update
    public static PlayerManager instance;
    private string _playerName;
    public string PlayerName
    {
        get => _playerName;
        set => _playerName = value;
    }

    public PlayerHighestScore playerHighestScore;

    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if (instance != null)
        {
            Debug.Log("loads");
            Destroy(gameObject);
            return;
        }

        LoadHighScore();
        instance = this;
        DontDestroyOnLoad(gameObject);

        _playerName = "default";
    }

    public void PlayerNewHighScore(int score)
    {
        if (playerHighestScore == null)
        {
            playerHighestScore = new PlayerHighestScore();
        }

        playerHighestScore.playerName = _playerName;
        playerHighestScore.playerScore = score;
        
        string json = JsonUtility.ToJson(playerHighestScore);
  
        File.WriteAllText(Application.persistentDataPath + "/player-highscore.json", json);
    }
    
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/player-highscore.json";
        if (File.Exists(path))
        {
            Debug.Log("PLAYER EXIST");
            string json = File.ReadAllText(path);
            playerHighestScore = JsonUtility.FromJson<PlayerHighestScore>(json);
        }
    }
}
