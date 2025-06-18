using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject target
    {
        get => _target;
        set
        {
            _target = value;
            arrowImage.enabled = _target != null;
        }
    }
    
    [SerializeField]
    private Image arrowImage;
    
    [SerializeField]
    private GameObject _target;
    
    // Start is called before the first frame update
    void Start()
    {
        arrowImage.enabled = _target != null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // get screen space position of target (even if outside screen)
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
            
            // if on screen hide and stop showing, else show and rotate
            if (screenPos.x >= 0 && screenPos.x <= Screen.width && 
                screenPos.y >= 0 && screenPos.y <= Screen.height)
            {
                arrowImage.enabled = false;
                return;
            }
            else
            {
                arrowImage.enabled = true;
            }
            
            // calculate angle from center of screen to target. Take into account if the target is behind the camera which flips the rotation
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 direction = screenPos - screenCenter;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (Vector3.Dot(Camera.main.transform.forward, target.transform.position - Camera.main.transform.position) < 0)
            {
                angle += 180f; // flip the arrow if the target is behind the camera
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
