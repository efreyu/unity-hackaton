using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D))]
public class LevelManager : MonoBehaviour
{
    private Collider2D m_Collider;
    public string StartLevel;
    public List<string> FillLevel = new List<string>();
    public string FinishLevel;
    public GameObject Player;
    public LevelChanger levelChanger;
    public GameManager gameManager;
//    private GameObject _dontFallowCamera;
    

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
//        _dontFallowCamera = GameObject.FindGameObjectWithTag("_DontFallow");
//        gameManager.enableFallow(_dontFallowCamera == null);
//        gameManager.registreList(StartLevel, FillLevel, FinishLevel);
        registreList();

        gameObject.AddComponent<FixZIndex>();
        if (m_Collider == null)
        {
            m_Collider = GetComponent<Collider2D>();
            m_Collider.isTrigger = true;
        }
    }

    private void registreList()
    {
//        Debug.Log(StartLevel);
//        Debug.Log(FillLevel);
//        Debug.Log(FinishLevel);
        
        Shuffle(new System.Random(), FillLevel);
//        Debug.Log(FillLevel);
//        for (var i = 0; i < FillLevel.Count; i++)
//        {
//            Debug.Log(FillLevel[i]);
//        }
    }

    private void Shuffle(System.Random random, List<string> FillLevel)
    {
        for (var i = 0; i < FillLevel.Count; i++)
        {
            int j = random.Next(FillLevel.Count);
            
//            Debug.Log(FillLevel[i]);
            Debug.Log(j);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        levelChanger.LoadLevel("Lobby");
    }
    
}