using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPositionUI: MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    private void OnEnable()
    {
        var screenpoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        GetComponent<RectTransform>().position = screenpoint;

        var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
