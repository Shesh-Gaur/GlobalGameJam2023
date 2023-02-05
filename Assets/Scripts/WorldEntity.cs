using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldEntity : MonoBehaviour
{
    [Tooltip("Toggle Debug.Log Calls")]
    [SerializeField] protected bool debugPrint;

    [Header("World Entity Parent Class Parameters")]

    [Tooltip("Fill this with the interaction verb")]
    [SerializeField] protected string _interactionString;

    virtual public void Interact(PlayerController player)
    {
        Debug.Log(_interactionString);
    }

    virtual public void PrintInteractionString()
    {
        Debug.Log(_interactionString);
    }
}