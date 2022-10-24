using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)),
    RequireComponent(typeof(MeshCollider))]
public class Car : MonoBehaviour
{
    public event Action IsCarBumped;

    private int _heals = 2;
    public int Heals { get => _heals; }

    private void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshCollider>().convex = true;
    }

    public void Bump()
    {
        _heals -= 1;
        IsCarBumped?.Invoke();
    }

    public void RestoreHeals()
    {
        _heals = 2;
    }
}