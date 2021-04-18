using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroMove : MonoBehaviour
{
    float h, v;
    float speed = 3.0f;

    bool jumping;
    float lastTime;

    Animator mAvatar;

    public Transform missile_pos;
    public GameObject Hero_Missile;

    public GameObject missile_effect;

    AudioSource shootSound;

    public void OnTouchValueChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        mAvatar = GetComponent<Animator>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mAvatar.SetFloat("Speed", (h * h + v * v));

        if (h != 0f && v != 0f)
        {
            transform.Rotate(0, h, 0);
            transform.Translate(0, 0, v * speed * Time.deltaTime);
        }

        Debug.Log("last Time : "+lastTime);
    }
    
    public void OnJumpBtnDown()
    {
        jumping = true;
        StartCoroutine(JumpHero());
    }

    public void OnJumpBtnUp()
    {
        jumping = false;
    }

    IEnumerator JumpHero()
    {
        if(Time.time-lastTime>1f)
        {
            lastTime = Time.time;
            while(jumping)
            {
                mAvatar.SetTrigger("Jump");
                jumping = false;
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void OnMissileShootDown()
    {
        shootSound.Play();
        GameObject imsy = Instantiate(missile_effect, missile_pos.position, missile_pos.rotation);
        Destroy(imsy, 0.5f);
    }

    public void OnMissileShootUp()
    {
        Instantiate(Hero_Missile, missile_pos.position, missile_pos.rotation);
    }
}
