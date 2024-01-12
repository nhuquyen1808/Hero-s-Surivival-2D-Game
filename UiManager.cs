
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Threading;


public class UiManager : MonoBehaviour
{
    public GameObject goldBar;
    public GameObject iconCoin;
    public Vector3 desCoin;
    public TextMeshProUGUI amountEnemyText;


    public static UiManager ins;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        desCoin = Camera.main.ScreenToWorldPoint(transform.position);
    }


    public void ScaleButton(GameObject obj, float _min, float _max, float _timer)
    {
        obj.transform.DOScale(_min, _timer).OnComplete(() =>
        {
            obj.transform.DOScale(_max, _timer).OnComplete(() =>
            {
                ScaleButton(obj, _min, _max, _timer);
            });
        });
    }

    public void PopUpPanel(GameObject obj, float _from)
    {
        obj.SetActive(true);
        obj.transform.DOScale(1, 1).From(_from);
    }

    public void SetActivePanel(GameObject gameObject, bool _active)
    {
        gameObject.SetActive(_active);
    }

    public void ShowListObjUi(List<GameObject> _list)
    {

        for (int i = 0; i < _list.Count; i++)
        {
            Sequence showItemUI = DOTween.Sequence();

            _list[i].gameObject.SetActive(true);

            showItemUI.AppendInterval(i * 0.1f);
            showItemUI.Append(_list[i].transform.DOScale(1.2f, 0.2f).From(0f));
            showItemUI.Append(_list[i].transform.DOScale(1, 0.2f));
        }
    }


}
