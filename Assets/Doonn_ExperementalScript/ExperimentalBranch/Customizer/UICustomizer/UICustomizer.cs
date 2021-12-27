using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomizer : MonoBehaviour
{
    [SerializeField] public GameObject _buttonPrefab;
    [SerializeField] private GameObject _panelToAttachButtonsTo;

    [SerializeField] private Button _buttonBase;
    [SerializeField] private Button _buttonTrack;
    [SerializeField] private Button _buttonWeapon;
    private List<Button> _buttonList = new List<Button>();

    private ModulTankSO[] _allModuls;

    private ModulTankSO _tempModul;

    List<ModulTankSO> _modulTrackList = new List<ModulTankSO>();
    List<ModulTankSO> _modulWeaponList = new List<ModulTankSO>();

    private void Start()
    {
        //Test 
        _buttonBase.onClick.AddListener(ClickBase);
        _buttonTrack.onClick.AddListener(ClickTrack);
        _buttonWeapon.onClick.AddListener(ClickWeapon);
        //

        _allModuls = LoadModulTank.AllLoadModulTank();
        UICustomizerEvent.Current.OnBtnClick += Test;
        //InitModulsTank();
    }

    private void ClickBase()
    {
        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Base)
            {

            }
        }
    }
    private void ClickTrack()
    {
        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Track)
            {
                _modulTrackList.Add(_allModuls[i]);
            }
        }

        if (_modulTrackList == null || _modulTrackList.Count <= 0) return;
        InitModulsTank(_modulTrackList);
    }
    private void ClickWeapon()
    {
        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Weapon)
            {
                _modulWeaponList.Add(_allModuls[i]);
            }
        }

        if (_modulWeaponList == null || _modulWeaponList.Count <= 0) return;
        InitModulsTank(_modulWeaponList);
    }

    private void Test(int id)
    {
        //Debug.Log("Test: " + modulTank);
        //_tempModul = _allModuls[id];
        //Debug.Log("Test: " + _tempModul.Prefab);
        //UICustomizerEvent.Current.GetModulTank(_modulTrackList[id]);
        UICustomizerEvent.Current.GetModulTank(_modulWeaponList[id]);
    }

    private void InitModulsTank(List<ModulTankSO> modulList)
    {
        //for (int i = 0; i < _allModuls.Length; i++)
        for (int i = 0; i < modulList.Count; i++)
        {
            var btn = Instantiate(_buttonPrefab);

            btn.transform.parent = _panelToAttachButtonsTo.transform;
            var parent = _panelToAttachButtonsTo.GetComponent<RectTransform>();
            var child = btn.GetComponent<RectTransform>();
            child.anchoredPosition = parent.anchoredPosition;

            var btnComponent = btn.gameObject.GetComponent<UI_Button>();
            btnComponent.BtnInit();
            btnComponent.ID = i;

            //var nameModul = _allModuls[i].Name;
            var nameModul = modulList[i].Name;

            btnComponent.SetText(nameModul);
        }
    }
}