using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHorizintalPanel : UIAbstract
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GameObject _updateButton;
    [SerializeField] private GameObject _panelToAttachButtonsTo;
    [SerializeField] private GameObject _instantButton;
    private List<GameObject> _buttonPrefabList = new List<GameObject>();
    private UIUpdateButton _upd;
    private UIButton _uiBtn;


    private void Start()
    {
        _upd = _updateButton.gameObject.GetComponent<UIUpdateButton>();
        _uiBtn = _buttonPrefab.GetComponent<UIButton>();

        CreateButtonAndAttachToPanel(3);
        InitButton();
        
        UIEvent.CurrentUI.OnClickButton += UIUpdate;
    }


    private void CreateButtonAndAttachToPanel(int countButton)
    {
        for (int i = 0; i < countButton; i++)
        {
            _instantButton = (GameObject) Instantiate(_buttonPrefab);
            _instantButton.transform.SetParent(_panelToAttachButtonsTo.transform);
            AddButton(_instantButton);
        }
    }

    private void AddButton(GameObject go)
    {
        if (!_buttonPrefabList.Contains(go))
        {
            _buttonPrefabList.Add(go);
        }
    }

    private void InitButton()
    {
        List<AbstractPerk> perkList = new List<AbstractPerk>();
        perkList = LoadPerksSystem.GetRandomPerkList(3);
        Debug.Log(perkList[0]);
        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            _buttonPrefabList[i].GetComponent<UIButton>().SetPerk(perkList[i]);
        }
    }



    private void UIUpdate()
    {
        List<AbstractPerk> perkList = new List<AbstractPerk>();
        perkList = LoadPerksSystem.GetRandomPerkList(3);

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            _buttonPrefabList[i].GetComponent<UIButton>().SetPerk(perkList[i]);
        }
    }
}