using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D collider;
    public LevelChanger level;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        level = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player(Girl)")
        {
            Debug.Log("Yep!");
            level.LoadLevel("GoodMorning");
        }
    }
}
