using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum LevelType
{
    ROOM,
    HALL
}
public class LevelController : MonoBehaviour
{
    public GameObject enterObject;

    public GameObject exitObject;

    public LevelType type;

    public Transform wherePlayerCanRespawn;
}