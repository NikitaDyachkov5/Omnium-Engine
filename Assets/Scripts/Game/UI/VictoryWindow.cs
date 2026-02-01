using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWindow : Window
{
    [Space][SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text recordScoreText;

    public override void Initialize()
    {
        continueButton.onClick.AddListener(ContinueButtonClickHandler);
    }

    private void ContinueButtonClickHandler()
    {
        Hide(true);
        GameManager.Instance.WindowsService.ShowWindow<MainMenuWindow>(false);
    }

    protected override void OpenStart()
    {
        base.OpenStart();
        scoreText.text = GameManager.Instance.ScoreSystem.Score.ToString();
        recordScoreText.gameObject.SetActive(GameManager.Instance.ScoreSystem.InNewScoreRecord);
    }
}
