using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    private bool Enable { get; set; }

    [SerializeField] Sprite enable;
    [SerializeField] Sprite disable;

    private void Start()
    {
        var img = transform.GetChild(1).GetComponent<Image>();
        var btn = GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            Enable = !Enable;
            AudioListener.pause = Enable;
            img.sprite = Enable ? enable : disable;
        });
    }
}
