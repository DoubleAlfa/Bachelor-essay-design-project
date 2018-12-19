using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable, IInteractable
{

    float animTimer, speed = 1.3f;
    int reverse = 1;
    bool startAnim;
    Animation anim;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnim)
        {
            transform.position += ((Vector3.forward * reverse + Vector3.up) * Time.deltaTime * speed);
            animTimer += Time.deltaTime;
            if (animTimer >= (anim.clip.length / 2) - 0.5f)
            {
                startAnim = false;
            }
        }
        else if (animTimer < (anim.clip.length / 2) + 0.5f && animTimer != 0)
            animTimer += Time.deltaTime;
        else if (animTimer >= (anim.clip.length / 2) + 0.5f)
        {
            transform.position -= ((Vector3.forward * reverse + Vector3.up) * Time.deltaTime * speed);
            animTimer += Time.deltaTime;
            if (animTimer >= anim.clip.length)
            {
                animTimer = 0;
            }
        }


    }

    public void Interact()
    {
        if(!anim.isPlaying)
        {
            anim.Play();
            startAnim = true;
            if(anim.clip.name.Length >= 17)
            {
                reverse = -1;
            }
        }
    }
}
