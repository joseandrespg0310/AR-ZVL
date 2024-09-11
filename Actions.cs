using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    //Loq hace el jugadro al ser detectado
    public string targetName;
    public void TargetDetected()
    {
        targetName = gameObject.name;
    }
}
