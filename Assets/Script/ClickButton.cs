using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite pressed, unPressed;
    [SerializeField] private AudioClip audioPressed, audioUnPressed;
    [SerializeField] private AudioSource source;
    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pressed;
        source.PlayOneShot(audioPressed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = unPressed;
        source.PlayOneShot(audioUnPressed);
    }

    public void iWasClicked()
    {
        

    }
}
