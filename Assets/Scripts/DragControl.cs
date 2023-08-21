using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    public Draggble LastDragged => lastDragged;
    public bool isDragActive = false;
    Vector2 screenPos;
    Vector3 woroldPos;
    Draggble lastDragged;
   
    private void Awake() {
        DragControl[] controllers = FindObjectsOfType<DragControl>();
        if(controllers.Length>1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragActive)
        {
            if (Input.GetMouseButtonUp(0)|| (Input.touchCount 
            == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPos = new Vector2(mousePos.x, mousePos.y);
        } 
        else if (Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        woroldPos = Camera.main.ScreenToWorldPoint(screenPos);
        
        if(isDragActive)
        {
            Drag();
        }
        else 
        {
            RaycastHit2D hit = Physics2D.Raycast(woroldPos, Vector2.zero);
            if (hit.collider != null)
            {
                Draggble draggble = hit.transform.gameObject.GetComponent<Draggble>();
                if(draggble != null)
                    {
                        lastDragged = draggble;
                        InitDrag();
                    }        
            }
        }
    }

    void InitDrag()
    {
        lastDragged.LastPosition = LastDragged.transform.position;
        UpdateDragStatuds(true);
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector2(woroldPos.x, woroldPos.y);
    }
    void Drop()
    {
        UpdateDragStatuds(false);
    }

    void UpdateDragStatuds(bool IsDragging)
    {
        isDragActive = lastDragged.IsDragging = IsDragging;
        lastDragged.gameObject.layer = IsDragging ? Layer.Dragging : Layer.Default;
    }
}
