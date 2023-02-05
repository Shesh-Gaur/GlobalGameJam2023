using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProp : WorldEntity
{
    [SerializeField] float _health;
    [Tooltip("The minimum force required to do damage to the object.")]
    [SerializeField] float _damageForceThreshold;

    [HideInInspector] public bool held = false;

    //Rigidbody rb;
    PlayerController controller;

    private void OnCollisionEnter(Collision collision)
    {
        float damage = collision.impulse.magnitude;
        if (debugPrint)
        {
            Debug.Log(damage);
        }
        if (damage < _damageForceThreshold)
        {
            return;
        }
        _health -= damage;

        if (debugPrint)
        {
            Debug.Log(_health);
        }

        if (_health <= 0)
        {
            //Instantiate<Sounds>(, transform);
            Kill();
        }
    }

    void Kill()
    {
        if (held)
        {
            controller.releaseObject();
        }
        Destroy(this.gameObject);
    }

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
        _health = 100f;
        _interactionString = "Pick Up";
        _damageForceThreshold = 10f;
    }
}
