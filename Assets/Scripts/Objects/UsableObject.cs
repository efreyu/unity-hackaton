using UnityEngine;
using UnityEngine.Rendering;

public class UsableObject : MonoBehaviour
{

    private bool _isUsableObject = false;

    protected bool IsUsableObject
    {
        get => _isUsableObject;
        set => _isUsableObject = value;
    }
    private void Awake()
    {
        //
    }

    void Start()
    {
        //
    }
}