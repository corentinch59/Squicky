using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Tent : MonoBehaviour
{
    private Transform _visual;
    public UnityEvent onFinished;
    public UnityEvent onFinishedCord;

    
    public void UpdateCords()
    {
        TentCordInteractable[] cords = GetComponentsInChildren<TentCordInteractable>();
        foreach (var cord in cords)
        {
            if (!cord.cut)
            {
                // un fil coupé
                transform.DOShakeRotation(0.5f, new Vector3(0, 10, 0));
                onFinishedCord.Invoke(); // callback progression quete
                return;
            }
        }
        
        //  tente qui s'envole
        Sequence seq = DOTween.Sequence();
        seq.Join(transform.DOMoveY(transform.position.y + 10, 1));
        seq.Join(transform.DOShakeRotation(1, new Vector3(20, 20, 20)));
        seq.Join(transform.DOScale(0, 1));
        seq.AppendCallback(() => Destroy(gameObject));
        onFinished.Invoke(); //callback progression quete
    }
    
    
    
}
