using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private InputField playerName;
    [SerializeField] private Button buttonStartGame;
    private string _playerName;
    
    void Start()
    {
        playerName.onEndEdit.AddListener(EditedName);
        buttonStartGame.onClick.AddListener(StartGame);
        
        playerName.text = PlayerManager.instance.PlayerName;
    }
    
    void EditedName(string name)
    {
        PlayerManager.instance.PlayerName = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
