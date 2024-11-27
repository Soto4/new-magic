using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTypingOnClick : MonoBehaviour
{
    public TypingEffect typingEffect;  // Referensi ke script TypingEffect

    void Update()
    {
        // Jika klik kiri, skip typing
        if (Input.GetMouseButtonDown(0))
        {
            typingEffect.SkipTyping();
        }
    }
}
