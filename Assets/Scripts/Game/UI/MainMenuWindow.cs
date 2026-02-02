using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : Window
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsGameButton;
    [SerializeField] private Button skillsWindowButton;

    public override void Initialize()
    {
        startGameButton.onClick.AddListener(StartGameHandler);
        optionsGameButton.onClick.AddListener(OpenOptionsHandler);
        skillsWindowButton.onClick.AddListener(OpenSkillsHandler);
    }

    protected override void OpenEnd()
    {
        base.OpenEnd();
        startGameButton.interactable = true;
        optionsGameButton.interactable = true;
        skillsWindowButton.interactable = true;
    }

    protected override void CloseStart()
    {
        base.CloseStart();
        startGameButton.interactable = false;
        optionsGameButton.interactable = false;
        skillsWindowButton.interactable = false;
    }

    private void StartGameHandler()
    {
        GameManager.Instance.StartGame();
        GameManager.Instance.WindowsService.ShowWindow<GameplayWindow>(false);
        Hide(false);
    }

    private void OpenOptionsHandler()
    {
        Hide(false);
        GameManager.Instance.WindowsService.ShowWindow<OptionsWindow>(false);
    }

    private void OpenSkillsHandler()
    {
        Hide(false);
        GameManager.Instance.WindowsService.ShowWindow<SkillsWindow>(false);
    }
}
