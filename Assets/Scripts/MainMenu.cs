using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.anyKey)
        {
            LevelChanger level = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
            level.LoadLevel("BigMap");
        }
    }
}
