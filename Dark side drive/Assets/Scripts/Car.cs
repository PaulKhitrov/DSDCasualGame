using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(MeshCollider))]
public class Car : MonoBehaviour
{
    private int _heals = 1;
    public int Heals { get => _heals; }

    private void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshCollider>().convex = true;
    }

    public void GetHit()
    {
        if (_heals <= 0)
        {
            Debug.Log("Car is crashed!");
            return;
        }
        else
        {
            _heals -= 1;
        }
    }
}