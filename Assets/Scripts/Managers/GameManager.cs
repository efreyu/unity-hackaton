using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;
    [Header("Canvas Manager")]
    public Camera gameCamera;
    public CinemachineVirtualCamera fallowCamera;
    public Transform currentPlayer;
    [CanBeNull] private Transform _currentTile;
    
    [FormerlySerializedAs("GameObject")] public List<GameObject> Tiles = new List<GameObject>();
    public SceneManager scene;

    public static GameManager Instance
    {
        get => _instance;
    }
    private int _currentScore = 0;

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
        Init();
        DontDestroyOnLoad(gameObject);
    }


    public void Init()
    {
        Instance.gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Instance.fallowCamera = GameObject.FindGameObjectWithTag("FallowCamera").GetComponent<CinemachineVirtualCamera>();
        Instance.currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        ChangeFallow();
    }
    

    private void ChangeFallow()
    {
        if (Instance.fallowCamera != null)
        {
            Instance.fallowCamera.Follow = Instance.currentPlayer;
            Instance.fallowCamera.LookAt = null;
        }
    }

    private void FixedUpdate()
    {
        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, .02f);
//        Debug.Log(colliders.Length);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Debug.Log(colliders[i].gameObject.name);
//                Debug.Log(colliders[i].gameObject.TryGetComponent(typeof(LevelController), out Component component));
//                if (colliders[i].gameObject.TryGetComponent(typeof(LevelController), out Component component))
//                {
//                    TerminalController terminal = (TerminalController)component;
//                    terminal.TryUse();
                    
//                }
            }
        }*/
    }
}
