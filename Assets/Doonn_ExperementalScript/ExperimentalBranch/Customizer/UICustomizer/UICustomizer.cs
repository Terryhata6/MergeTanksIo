using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomizer : MonoBehaviour
{
    [SerializeField] public GameObject _imgBackground;
    [SerializeField] public GameObject _buttonPrefab;
    [SerializeField] private GameObject _panelToAttachButtonsTo;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _panel2;
    [SerializeField] private GameObject _temp;
    [SerializeField] private Button _buttonBase;
    [SerializeField] private GameObject _buttonBaseObject;
    [SerializeField] private Button _buttonTrack;
    [SerializeField] private Button _buttonWeapon;
    private List<Button> _buttonList = new List<Button>();
    private ModulTankSO[] _allModuls;
    private ModulTankSO _tempModul;
    List<ModulTankSO> _modulTrackList = new List<ModulTankSO>();
    List<ModulTankSO> _modulWeaponList = new List<ModulTankSO>();
    List<ModulTankSO> _modulBaseList = new List<ModulTankSO>();
    List<GameObject> _buttonPrefabList = new List<GameObject>();
    [SerializeField] private Animator _animator;

    private void Start()
    {
        //Test 
        _buttonBase.onClick.AddListener(ClickBase);
        _buttonTrack.onClick.AddListener(ClickTrack);
        _buttonWeapon.onClick.AddListener(ClickWeapon);
        //

        _allModuls = LoadModulTank.AllLoadModulTank();
        Init();

        UICustomizerEvent.Current.OnBtnClick += Test;
        _panel2.SetActive(false);
    }

    private void Init()
    {
        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Weapon)
            {
                _modulWeaponList.Add(_allModuls[i]);
            }
        }
        
        InitModulsTank(_modulWeaponList);

        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Track)
            {
                _modulTrackList.Add(_allModuls[i]);
            }
        }

        InitModulsTank(_modulTrackList);

        for (int i = 0; i < _allModuls.Length; i++)
        {
            if (_allModuls[i].ModulType == TypeModul.Base)
            {
                _modulBaseList.Add(_allModuls[i]);
            }
        }

        InitModulsTank(_modulBaseList);

        _panel2.SetActive(false);
        _temp.SetActive(false);
    }

    private void ClickBase()
    {
        // _imgBackground.SetActive(false);
        // _temp.SetActive(true);
        // var te = _temp.GetComponent<RectTransform>();
        // var btn = _buttonBaseObject.GetComponent<RectTransform>();
        // te.anchoredPosition = btn.anchoredPosition;
        // te.sizeDelta = btn.sizeDelta;


        if(_temp.TryGetComponent(out UI_Button_ModulType modul))
        {
            modul.SetSprite(_buttonBase.image.sprite);
            var te =  _temp.GetComponent<RectTransform>();
            var btn = _buttonBaseObject.GetComponent<RectTransform>();
            //te.anchoredPosition = btn.anchoredPosition;
            te.sizeDelta = btn.sizeDelta;

            Debug.Log(btn.anchoredPosition);
        }

        _panel2.SetActive(true);
        if(_panel.TryGetComponent(out UI_Button_ModulType modulk))
        {
            modulk.SetSprite(_buttonBase.image.sprite);
        }

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Base)
            {
                _buttonPrefabList[i].SetActive(true);
            }
        }
        
        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Weapon)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Track)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }
    }

    private void ClickTrack()
    {
        _panel2.SetActive(true);
        if(_panel.TryGetComponent(out UI_Button_ModulType modul))
        {
            modul.SetSprite(_buttonTrack.image.sprite);
        }

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Track)
            {
                _buttonPrefabList[i].SetActive(true);
            }
        }

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Weapon)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }

        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Base)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }
    }
    private void ClickWeapon()
    {
        Debug.Log("QQQQQQQQQQQQQQ");
        _panel2.SetActive(true);
        if(_panel.TryGetComponent(out UI_Button_ModulType modul))
        {
            modul.SetSprite(_buttonWeapon.image.sprite);
        }
        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Weapon)
            {
                _buttonPrefabList[i].SetActive(true);
            }
        }
        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Track)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }
        for (int i = 0; i < _buttonPrefabList.Count; i++)
        {
            if (_buttonPrefabList[i].GetComponent<UI_Button>().Type == TypeModul.Base)
            {
                _buttonPrefabList[i].SetActive(false);
            }
        }

    }

    private void Test(int id, TypeModul modulType)
    {
        if (modulType == TypeModul.Weapon)
        {
            UICustomizerEvent.Current.GetModulTank(_modulWeaponList[id]);
        }
        else if (modulType == TypeModul.Track)
        {
            UICustomizerEvent.Current.GetModulTank(_modulTrackList[id]);
        }
        else if (modulType == TypeModul.Base)
        {
            UICustomizerEvent.Current.GetModulTank(_modulBaseList[id]);
        }

        //Debug.Log("Test: " + modulTank);
        //_tempModul = _allModuls[id];
        //Debug.Log("Test: " + _tempModul.Prefab);
    }

    private void InitModulsTank(List<ModulTankSO> modulList)
    {
        //for (int i = 0; i < _allModuls.Length; i++)
        for (int i = 0; i < modulList.Count; i++)
        {
            var btn = Instantiate(_buttonPrefab);

            btn.transform.parent = _panelToAttachButtonsTo.transform;
            //var parent = _panelToAttachButtonsTo.GetComponent<RectTransform>();
            //var child = btn.GetComponent<RectTransform>();
            //child.anchoredPosition = parent.anchoredPosition;

            var btnComponent = btn.gameObject.GetComponent<UI_Button>();
            btnComponent.BtnInit();
            btnComponent.ID = i;
            btnComponent.Type = modulList[i].ModulType;
            //var nameModul = _allModuls[i].Name;
            var nameModul = modulList[i].Name;

            btnComponent.SetText(nameModul);
            btn.SetActive(false);
            _buttonPrefabList.Add(btn);
        }
    }

    private bool isOpen = true;
    public void OpenAndClose()
    {
        if (isOpen)
        {
            _animator.Play("Close");
            isOpen = false;
            Debug.Log(isOpen);
            _panel2.SetActive(false);
            return;
        }
        else
        {
            _animator.Play("Open");
            isOpen = true;
            Debug.Log(isOpen);
            return;
        }
    }
}