using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersActions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] characters;
    [SerializeField]
    Actions[] controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characters[0].name.Equals(controller[0].targetName) && characters[1].name.Equals(controller[1].targetName))
        {
            characters[0].GetComponent<Animator>().SetBool("Idle2", true);
            characters[1].GetComponent<Animator>().SetBool("Idle2", true);
        }

    }
}
