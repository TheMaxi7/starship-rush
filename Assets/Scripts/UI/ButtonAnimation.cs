using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public AnimationClip selected;
    public AnimationClip deselected;
    public AnimationClip pressed;

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>(); 
    }
    public void ButtonPressed()
    {   
        anim.clip = pressed;
        anim.Play();
    }

    public void ButtonSelected()
    {
        anim.clip = selected;
        anim.Play();
    }

    public void ButtonDeselected()
    {
        anim.clip = deselected;
        anim.Play();
    }
}
