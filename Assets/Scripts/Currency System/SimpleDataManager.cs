using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDataManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        playerData.InitVariables();
    }
}
