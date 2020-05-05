using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RandomSystem : MonoBehaviour
{
    [Header("群組")]
    public GameObject group;

    private Transform panel;

    private int count = 10;
    private List<int> totalCount = new List<int>();
    private List<int> randomCount = new List<int>();

    private void Start()
    {
        panel = GameObject.Find("顯示面板").transform;
    }

    /// <summary>
    /// 取得數量
    /// </summary>
    /// <param name="count">滑桿數量</param>
    public void GetCount(float count)
    {
        this.count = (int)count;
    }

    public void StartRandom()
    {
        StartCoroutine(StartShowCount());
    }

    private IEnumerator StartShowCount()
    {
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 200f / 255f);

        for (int i = 0; i < count; i++) totalCount.Add(i + 1);

        for (int i = 0; i < count; i++)
        {
            int r = Random.Range(0, totalCount.Count);
            randomCount.Add(totalCount[r]);
            totalCount.RemoveAt(r);
            GameObject temp = Instantiate(group, panel);
            temp.transform.GetChild(2).GetComponent<Text>().text = (i + 1).ToString();
            temp.transform.GetChild(5).GetComponent<Text>().text = (randomCount[i]).ToString();
            yield return new WaitForSeconds(0.1f);
        }

    }
}
