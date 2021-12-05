using UnityEngine;
using UnityEngine.UI;

public class UIInterfaceManager : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private Image[] _action;
    [SerializeField] private Player _player;
    [Header("Character Slider")]
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private Slider _sliderMP;
    [SerializeField] private Slider _sliderPW;

    private void Start()
    {
        for (int i = 0; i < _action.Length; i++)
        {
            _action[i].sprite = _player.Weapons[_player.WeaponsId].Skilllists[i].SpellPrifab.GetComponent<Spell>().Icon;
        }

        _player.SliderChange += UpdateSlider;
        _player.SliderMax += SetMaxValueSlider;
    }
    private void OnDisable()
    {
        _player.SliderChange -= UpdateSlider;
        _player.SliderMax -= SetMaxValueSlider;
    }

    private void SetMaxValueSlider(int hpmax, int mpmax, int pwmax)
    {
        if (hpmax != _sliderHP.maxValue)
            _sliderHP.maxValue = hpmax;

        if (mpmax != _sliderMP.maxValue)
            _sliderMP.maxValue = mpmax;

        if (pwmax != _sliderPW.maxValue)
            _sliderPW.maxValue = pwmax;
    }
    private void UpdateSlider(int hp, int mp, int pw)
    {
        if (hp != _sliderHP.value)
            _sliderHP.value = hp;

        if (mp != _sliderMP.value)
            _sliderMP.value = mp;

        if (pw != _sliderPW.value)
            _sliderPW.value = pw;
    }
}
