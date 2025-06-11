using UnityEngine;
using UnityEngine.Events;

public class BucketFiller : MonoBehaviour, IBucketReceiver
{
    [SerializeField] private UnityEvent _onBucketFilled;
    
    public event UnityAction OnBucketFilled
    {
        add => _onBucketFilled.AddListener(value);
        remove => _onBucketFilled.RemoveListener(value);
    }

    public void ReceiveBucket(BucketInteractable bucket)
    {
        if (bucket == null) return;

        if(!bucket.isBucketFilled)
        {
            bucket.isBucketFilled = true;
            _onBucketFilled?.Invoke();
        }
    }
}
