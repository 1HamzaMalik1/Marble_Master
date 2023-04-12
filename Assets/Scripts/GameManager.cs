using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if(!Instance)
        Instance = this;
    }
    void Start()
    {
        
    }

    void StartingGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
