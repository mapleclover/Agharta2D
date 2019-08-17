using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : Singleton<PlayerSkill>
{

    public GameObject Skill;
    public int skillchange = 0;

    bool visible = false;
    float visibleTime = 0;

    
    public Sprite[] SkillSprites;
    public Image SkillUI;

    private void Start()
    {
        Skill.SetActive(false);
    }

    private void Update()
    {

        if (!GameOver.Instance.gameover)
        {
            if (Input.GetButtonDown("Skill"))
            {
                visible = true;
                visibleTime = 0;
                skillchange = skillchange + 1;
                if (skillchange > 2)
                    skillchange = 0;
            }
            SkillUI.sprite = SkillSprites[skillchange];

            if (visible)
            {
                Skill.SetActive(true);
                visibleTime += Time.deltaTime;
            }
            if (!visible)
            {
                Skill.SetActive(false);
            }

            if (visibleTime > 1)
            {
                visible = false;
                visibleTime = 0;
            }
        }

    }

    private void LateUpdate()
    {
        this.Skill.transform.position = new Vector3(PlayerMove.Instance.pos.x, PlayerMove.Instance.pos.y + 2, 0);

    }
}
