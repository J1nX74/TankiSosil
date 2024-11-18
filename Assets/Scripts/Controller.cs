using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{


    [SerializeField] FinishScreen finishScreen;
    void Start()
    {
        finishScreen.gameObject.SetActive(false);

    }


    void Update()
    {
        
    }
}
