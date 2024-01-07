using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeArea : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    RectTransform panelsafearea;

    Rect currentdafearea = new Rect();
    ScreenOrientation currentoridentation = ScreenOrientation.AutoRotation;
    void Start()
    {   
        panelsafearea = GetComponent<RectTransform>();

        currentoridentation = Screen.orientation;
        currentdafearea = Screen.safeArea; 
    }

    void Applysafearea(){
        if (panelsafearea == null){
            return;
        }
        Rect safearea = Screen.safeArea;
        Vector2 anchorMin = safearea.position;
        Vector2 anchorMax = safearea.position - safearea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        panelsafearea.anchorMin = anchorMin;
        panelsafearea.anchorMax = anchorMax;

        currentoridentation = Screen.orientation;
        currentdafearea = Screen.safeArea;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentoridentation!=Screen.orientation|| (currentdafearea!=Screen.safeArea)){
            Applysafearea();
        }
    }
}
