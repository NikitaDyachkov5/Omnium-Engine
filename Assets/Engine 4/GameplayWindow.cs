using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayWindow : Window
{
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private Slider healthSlider;

    [Space]
    [SerializeField]
    private Slider experienceSlider;

    [Space]
    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private TMP_Text coinsText;

    public override void Initialize()
    {
        
    }

    protected override void OpenStart()
    {
        base.OpenStart();
        var player = GameManager.Instance.CharacterFactory.Player;

        UpdateHealthVisual(player);
        player.LiveComponent.OnCharacterHealthChange += UpdateHealthVisual;
    }

    protected override void CloseStart()
    {
        base.CloseStart();

        var player= GameManager.Instance.CharacterFactory.Player;
        if (player == null)
            return;

        player.LiveComponent.OnCharacterHealthChange -= UpdateHealthVisual;
    }

    private void UpdateHealthVisual(Character character)
    {
        int health = (int)character.LiveComponent.Health;
        int healthMax = (int)character.LiveComponent.MaxHealth;

        healthText.text = health + "/" + healthMax;
        healthSlider.maxValue = healthMax;
        healthSlider.value = health;
    }
}
