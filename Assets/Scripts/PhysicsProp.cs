using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProp : WorldEntity
{    
    [HideInInspector] public bool held = false;

    PlayerController controller;

    public void AssignHolder(PlayerController con)
    {
        controller = con;
    }

    override public void Interact(PlayerController player)
    {
        player.grabObject();
    }

    private void Reset()
    {
        _interactionString = "Pick Up";
    }
}