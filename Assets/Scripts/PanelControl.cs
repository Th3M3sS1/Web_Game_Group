using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public RectTransform rectTransform;

    public PlayerController playerCamera;

    

    public Vector2 onScreeenPosition;
    public Vector2 offScreenPosition;
    private float timer;
    [Range(0.1f, 3)]
    public float speed;
    public bool onScreen = false;
    // Start is called before the first frame update
    void Start()
    {
     
        playerCamera = FindObjectOfType<PlayerController>();

        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offScreenPosition;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            onScreen = !onScreen;
            timer = 0f;

            if (onScreen)
            {
                
                Cursor.lockState = CursorLockMode.None;
                
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                
            }

        }
        if (onScreen)
        {
            MovePanelDown();
        }
        else
        {
            MovePanelUp();
        }
    }
    void MovePanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offScreenPosition, onScreeenPosition, timer);
        timer += Time.deltaTime;
        if (timer < 1)
        {
            timer += Time.deltaTime * speed;
        }
    }
    void MovePanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onScreeenPosition, offScreenPosition, timer);
        timer += Time.deltaTime;
        if (timer < 1)
        {
            timer += Time.deltaTime * speed;
        }

        
    }
}
