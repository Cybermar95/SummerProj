using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowWindow : MonoBehaviour
{
    public float ShowTime;
    public GameObject Window;

    private bool IsShow = false;

	void Start ()
    {
        Window = GameObject.Find("WindowID");
    }
	
    public void OnClick()
    {
        IsShow = true;
    }
	
	void Update ()
    {
	    if (IsShow)
        {
            if(Window.transform.localScale.x >= 1)
            {
                Window.transform.localScale = new Vector3(1,1,1);
                IsShow = false;
            }
            else
            {
                float delta = Time.deltaTime / ShowTime;
                float x = Window.transform.localScale.x + delta;
              
                Window.transform.localScale = new Vector3(x, x, 1);
            }
        }
	}
}
