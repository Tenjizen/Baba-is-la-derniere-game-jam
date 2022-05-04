using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSFX;

    public AudioClip[] audioClips;

    public Slider sliderMusic;
    public Slider sliderSFX;

    [HideInInspector] public bool coroutine = false;
    //public float step = 1f;

    public float m_sliderMusicValue = 0.3f;
    public float m_sliderSfxValue = 0.3f;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        SetMusicLevel(m_sliderMusicValue);
        SetSFXLevel(m_sliderSfxValue);
        sliderMusic.value = m_sliderMusicValue;
        sliderSFX.value = m_sliderSfxValue;
    }

    public void SetMusicLevel(float sliderValue)
    {
        m_sliderMusicValue = sliderValue;
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        //Debug.Log(sliderValue);
    }
    public void SetSFXLevel(float sliderValue)
    {
        m_sliderSfxValue = sliderValue;
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);

        //Debug.Log(sliderValue);
    }
    public void PlayMusicSound(string name)
    {
        AudioClip clip = GetClip(name);
        audioSourceMusic.PlayOneShot(clip);
        Debug.Log(clip);
    }
    public void PlaySFXSound(string name)
    {
        AudioClip clip = GetClip(name);
        audioSourceSFX.PlayOneShot(clip);
    }

    public IEnumerator IEPlayMusicSound(string name)
    {
        AudioClip clip = GetClip(name);
        audioSourceMusic.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        StartCoroutine(IEPlayMusicSound(name));
    }
    //public IEnumerator step(string name)
    //{
    //    AudioClip clip = GetClip(name);
    //    audioSourceMusic.PlayOneShot(clip);
    //    yield return new WaitForSeconds(step);
    //}

    AudioClip GetClip(string name)
    {
        foreach (var item in audioClips)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }
    /* all sound,
    
   


     */



    /* 
       IEnumerator RunMoveForAllPlayer(BattleUnit sourceUnit, Move move)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < _playerParty.Monsters.Count; i++)
        {
            var player = _playerUnits[i];
            AudioManager.Instance.PlaySFXSound(move.Base.Sound);
            if (move.Base.Category == MoveCategory.Status)
            {
                StartCoroutine(RunMoveEffects(move, sourceUnit.Monster, _playerUnits[i].Monster, sourceUnit));
                if (player.Monster.HP > 0)
                    StartCoroutine(_playerUnits[i].PlayBoostAnimation());
            }
            else
            {
                if (player.Monster.HP > 0)
                {
                    player.Monster.HP += player.Monster.MaxHp / 5;
                    if (player.Monster.HP > player.Monster.MaxHp)
                        player.Monster.HP = player.Monster.MaxHp;
                    player.Monster.HpChanged = true;

                    StartCoroutine(player.Hud.UpdateHP());
                    if (player.Monster.HP > 0)
                        StartCoroutine(player.PlayHealAnimation());

                }
            }
        }
        yield return new WaitForSeconds(1.5f);

        sourceUnit.Monster.OnAfterTurn();
        yield return sourceUnit.Hud.UpdateHP();
        if (sourceUnit.IsPlayerUnit)
            sourceUnit.PlayFadeAnimation();
        if (sourceUnit.Monster.HP <= 0)
        {
            if (sourceUnit.isPlayerUnit)
                _playerUnitsDead.Add(_playerSelectedUnit);

            yield return _dialogBox.TypeDialog($"{sourceUnit.Monster.Base.Name} Fainted");
            sourceUnit.PlayFaintAnimation();

            var _hudTarget = sourceUnit.GetComponentInChildren<BattleHud>(true);
            _hudTarget.gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);

            CheckForBattleOver(sourceUnit);
        }
        canSelected = true;


    }
    */
}
