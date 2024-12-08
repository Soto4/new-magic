using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _pressed, _unPressed;
    [SerializeField] private AudioClip _audioPressed;
    [SerializeField] private AudioSource _source;

    // Fungsi dipanggil saat tombol ditekan
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_image != null)
        {
            _image.sprite = _pressed; // Ubah sprite ke "pressed"
        }
        else
        {
            Debug.LogError("Image reference is missing in ClickButton!");
        }

        if (_source != null && _audioPressed != null)
        {
            _source.PlayOneShot(_audioPressed); // Mainkan audio saat tombol ditekan
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip (_audioPressed) is missing in ClickButton!");
        }
    }

    // Fungsi dipanggil saat tombol dilepas
    public void OnPointerUp(PointerEventData eventData)
    {
        if (_image != null)
        {
            _image.sprite = _unPressed; // Ubah sprite ke "unPressed"
        }
        else
        {
            Debug.LogError("Image reference is missing in ClickButton!");
        }

    }

    // Fungsi kosong untuk klik tambahan (jika diperlukan)
    public void iWasClicked()
    {
        Debug.Log("Button was clicked!");
    }
}
