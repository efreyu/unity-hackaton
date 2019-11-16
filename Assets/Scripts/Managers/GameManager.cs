using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;
    [Header("Canvas Manager")]
//    public Canvas mainMenuCanvas;
//    public Canvas settingsMenuCanvas;
//    public Canvas infoMenuCanvas;
//    public Canvas pauseMenuCanvas;
//    public Canvas endGameCanvas;
    public Camera gameCamera;
    
//    [Header("Audio Manager")]
//    public Slider musicSlider;
//    public Slider sfxSlider;
//    public Button soundToggleButton;
//    public Sprite soundOnSprite;
//    public Sprite soundOffSprite;
//    
//    [Header("Score Manager")]
//    public TextMesh currentScoreObj;
//    public TextMesh highScoreObj;
//    public TextMesh timeAvaliableObj;
    
    public static GameManager Instance
    {
        get => _instance;
    }
    private int _currentScore = 0;
//    public int CurrentScore
//    {
//        get => _currentScore;
//        set
//        {
//            if (value > 0)
//            {
//                _currentScore += value * 10;
//                _timeAvailable += value * 2;
//            }
//            else
//            {
//                _currentScore = value;
//            }
//            currentScoreObj.text = "Current Score: " + _currentScore;
//            if (_currentScore <= PlayerPrefs.GetInt("HighScore", 0))
//                return;
//            PlayerPrefs.SetInt("HighScore", _currentScore);
//            highScoreObj.text = $"Highest Score: {_currentScore}";
//        }
//    }
    private bool _isGameRunning;

    void Awake()
    {
        MakeInstance();
    }
    private void MakeInstance()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        _instance = this;
//        UIManager.InitScoreUi();
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (_isGameRunning) return;
        
        _isGameRunning = true;
        
    }
    public void EndGame(bool backToMenu = false)
    {
        if (!_isGameRunning) return;
        
        _isGameRunning = false;
//        if (backToMenu)
//        {
//            return;
//        }
//        Time.timeScale = 0f;
//        Instance.gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
//        Instance.gameCamera.cullingMask = 1 << LayerMask.NameToLayer("EndGameLayer");
//        Instance.endGameCanvas = GameObject.FindGameObjectWithTag("EndGameCanvas").GetComponent<Canvas>();
//        Instance.endGameCanvas.enabled = true;
    }
    
    
}
