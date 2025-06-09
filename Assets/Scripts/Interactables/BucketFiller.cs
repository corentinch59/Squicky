using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFiller : IBucketReceiver
{
    public void ReceiveBucket(BucketInteractable bucket)
    {
        bucket.isBucketFilled = true;
    }
}
