using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWordButton : UIBaseButton<HudArea>
{
    [Header("Button Images")]
    [SerializeField] private Image m_CheckWordButtonBG;
    [SerializeField] private Image m_CheckWordButtonIcon;

    [Header("Button Status Colors")]
    [SerializeField] private Color m_BGDeactiveColor;
    [SerializeField] private Color m_BGActiveColor;
    [SerializeField] private Color m_IconDeactiveColor;
    [SerializeField] private Color m_IconActiveColor;
    public override void Initialize(HudArea _cachedComponent)
    {
        base.Initialize(_cachedComponent);
        GameManager.Instance.LevelManager.WordManager.OnChangedClickedWordEvent += SetCheckWordButtonStatus;
        SetCheckWordButtonStatus(-1, 1);
    }
    protected override void OnClickAction()
    {
        GameManager.Instance.LevelManager.WordManager.CheckWord();
    }
    #region Event
    public void SetCheckWordButtonStatus(int _clickedCount, int _emptyCount)
    {
        m_CheckWordButtonBG.color = (_clickedCount == _emptyCount) ? m_BGActiveColor : m_BGDeactiveColor;
        m_CheckWordButtonIcon.color = (_clickedCount == _emptyCount) ? m_IconActiveColor : m_IconDeactiveColor;
        m_Button.enabled = (_clickedCount == _emptyCount);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.Instance.LevelManager.WordManager.OnChangedClickedWordEvent -= SetCheckWordButtonStatus;
    }
    #endregion
}
