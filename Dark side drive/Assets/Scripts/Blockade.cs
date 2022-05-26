using UnityEngine;

public class Blockade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            car.Bump();
        }
        else
        {
            return;
        }
    }
}