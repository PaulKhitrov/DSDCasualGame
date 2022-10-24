using UnityEngine;
using System;

public class FinishLine : MonoBehaviour
{
    public event Action IsCrossFinishLine;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            IsCrossFinishLine?.Invoke();
        }
        else
        {
            return;
        }
    }
}
