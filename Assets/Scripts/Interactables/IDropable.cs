using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDropable
{
    public void Use(GameObject interactor);
    public void Drop();
}
