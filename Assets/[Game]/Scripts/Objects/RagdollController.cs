﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public List<Collider> colliders;
    public Rigidbody mainRigidbody;
    public Collider mainCollider;

    private Animator animator;
    public Animator AnimatorRagdoll { get { return (animator == null) ? animator = GetComponentInChildren<Animator>() : animator; } }
    private Enemy2 enemy;
    public Enemy2 EnemyScript { get { return (enemy == null) ? enemy = GetComponentInChildren<Enemy2>() : enemy; } }

    public void ActivateRagdoll() 
    {
        AnimatorRagdoll.enabled = false;
        SetRigidbodies(false);
        SetColliders(true);
        EnemyScript.IsRagdoll = true;
    }

    public void DisableRagdoll() 
    {
        AnimatorRagdoll.enabled = true;
        SetRigidbodies(true);
        SetColliders(false);
        EnemyScript.IsRagdoll = false;
    }

    public void ForceRagdoll(Vector3 direction) 
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddForce(direction * 100f, ForceMode.Impulse);
        }
    }

    private void SetRigidbodies(bool state)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;            
        }
        mainRigidbody.isKinematic = !state;
    }

    private void SetColliders(bool state)
    {
        foreach (var item in colliders)
        {
            item.enabled = state;
        }
        mainCollider.enabled = !state;
    }
}
