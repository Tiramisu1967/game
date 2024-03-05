using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CoolDownText
{
    public EnumTypes.PlayerSkill skill;
    public TextMeshProUGUI Text;
}
public class PlayerUI : MonoBehaviour
{
    public Image[] HealthImages = new Image[3];
    public Image[] ChainImages = new Image[4];
    public Image RepairSkill;
    public Image BombSkill;
    public Image freezeSkill;
    public Image RecoverySkill;
    public Slider FuelSlider;
    public Slider BossSlider;

    public TextMeshProUGUI SkillCooldownNoticeText;
    public List<CoolDownText> SkillCooldownTexts;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateSkills();
        UpdateFuel();
    }

    public void UpdateHealth()
    {
        if (GameManager.Instance.Player != null)
        {
            int HP = GameManager.Instance.Player.GetComponent<PlayerHPSystem>().Health;
            for (int i = 0; i < HealthImages.Length; i++)
            {
                HealthImages[i].gameObject.SetActive(i < HP);
            }
        }


    }

    public void UpdateChain(int chain)
    {
        if (GameManager.Instance.Player != null)
        {
            ChainImages[chain].gameObject.SetActive(true);
            ChainImages[chain].gameObject.GetComponent<Animator>().SetBool("ischain", true);
        }
    }

    public void chainrelease()
    {
        for (int i = 0; i < ChainImages.Length; i++)
        {
            ChainImages[i].gameObject.SetActive(false);
            ChainImages[i].gameObject.GetComponent<Animator>().SetBool("ischain", false);
        }
    }

    public void UpdateFuel()
    {
        FuelSlider.value = GameInstance.instance.CurrentPlayerFuel / 100;
    }

    public void UpdateSkills()
    {
        foreach (var item in SkillCooldownTexts)
        {
            bool bIsCoolDown = GameManager.Instance.Player.Skills[item.skill].bIsCoolDown;
            float CooldownTime = GameManager.Instance.Player.Skills[item.skill].CurrentTime;

            item.Text.gameObject.SetActive(bIsCoolDown);
            item.Text.text = $"{MathF.Round(CooldownTime)}";
        }
    }

    public void NoticeSkillCooldown(EnumTypes.PlayerSkill playerSkill)
    {
        StartCoroutine(NoticeText(playerSkill));
    }

    IEnumerator NoticeText(EnumTypes.PlayerSkill playerSkill)
    {
        SkillCooldownNoticeText.gameObject.SetActive(true);
        SkillCooldownNoticeText.text = $"{playerSkill.ToString()} is CoolTime";
        yield return new WaitForSeconds(3f);
        SkillCooldownNoticeText.gameObject.SetActive(false);
    }

    public void UpdateBoss(float Health)
    {

        BossSlider.gameObject.SetActive(true);
        Debug.Log(Health);
        BossSlider.value = Health;
        Health -= 0.00001f;

    }
}
