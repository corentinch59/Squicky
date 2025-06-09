using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepit : MonoBehaviour, IBucketReceiver
{
    public void ReceiveBucket(BucketInteractable bucket)
    {
        bucket.isBucketFilled = false;
        //Update journal fire extinguished and 
    }
}
