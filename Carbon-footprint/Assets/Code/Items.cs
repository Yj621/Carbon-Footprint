using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public Image key1;
    public Image key2;
    public Image key;
    public Image wood;
    public Image blade;
    public Image knife;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Key1":
                if (Input.GetKey(KeyCode.G))
                {
                    key1.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                }
                break;
            case "Key2":
                if (Input.GetKey(KeyCode.G))
                {
                    key2.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                }
                break;
            case "Wood":
                if (Input.GetKey(KeyCode.G))
                {
                    wood.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                }
                break;
            case "Blade":
                if (Input.GetKey(KeyCode.G))
                {
                    blade.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                }
                break;                
            case "Knife":
                if (Input.GetKey(KeyCode.G))
                {
                    knife.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                }
                break;               
            default:
                break;
        }
        if (key1.gameObject.activeSelf && key2.gameObject.activeSelf)
        {
            key1.gameObject.SetActive(false);
            key2.gameObject.SetActive(false);
            key.gameObject.SetActive(true);
        }
        if (wood.gameObject.activeSelf && blade.gameObject.activeSelf)
        {
            wood.gameObject.SetActive(false);
            blade.gameObject.SetActive(false);
            knife.gameObject.SetActive(true);
        }
    }

}

