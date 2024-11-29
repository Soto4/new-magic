using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CardClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private AudioClip _audioPressed, _audioUnPressed;
    [SerializeField] private AudioSource _source;
    public void OnPointerDown(PointerEventData eventData)
    {
        _source.PlayOneShot(_audioPressed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _source.PlayOneShot(_audioUnPressed);
    }

    public void iWasClicked()
    {

    }
}