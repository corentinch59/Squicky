using UnityEngine;
using UnityEngine.Events;

public class Firepit : MonoBehaviour, IBucketReceiver
{
    [SerializeField] private UnityEvent _onFireExtinguished;

    public event UnityAction OnFireExtinguished
    {
        add => _onFireExtinguished.AddListener(value);
        remove => _onFireExtinguished.RemoveListener(value);
    }

    public void ReceiveBucket(BucketInteractable bucket)
    {
        if(bucket == null) return;

        if (bucket.isBucketFilled)
        {
            bucket.isBucketFilled = false;
            _onFireExtinguished?.Invoke();
        }
    }
}
