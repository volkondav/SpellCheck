using System;
using UnityEngine;
using Unity.VisualScripting;

public class GetAnimationClipLength : MonoBehaviour
{
    Animator m_Animator;
    AnimatorClipInfo[] m_CurrentClipInfo;

    float m_CurrentClipLength;
    string m_ClipName;

    void Awake()
    {
        // Get them_Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public float GetClipInfo(){

        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        //Access the Animation clip name
        // m_ClipName = m_CurrentClipInfo[0].clip.name;
        // print(m_ClipName);

        return m_CurrentClipLength;
    }
}