/***********************************************************/
/**  © 2018 NULLcode Studio. All Rights Reserved.
/**  Разработано в рамках проекта: https://null-code.ru/
/**  Подписка на Рatreon: https://www.patreon.com/null_code
/***********************************************************/
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent(typeof(Toggle))]
public class CustomToggle : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    public float scale = 1; // изменение размера
    public Animator animator;
    public Toggle toggle;

    void OnValidate()
    {
        toggle.transform.localScale = new Vector3(scale, scale, 1);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        animator.SetBool("IsOn", toggle.isOn);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        eventData.pointerPress = null;
        EventSystem.current.SetSelectedGameObject(null); // сброс выбранного объекта
    }

    void Transition()
    {
        animator.SetBool("IsOn", toggle.isOn);
        animator.Play(toggle.isOn ? "ToggleOn" : "ToggleOff");
    }

#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Custom/Toggle")]
    static void CreateToggle()
    {
        if (Selection.activeTransform == null)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Canvas"); // добавить стандартный Canvas
        }

        string path = "Assets/NULLcode Studio/Toggle/Prefab/Toggle.prefab"; // путь к префабу Toggle
        GameObject prefab = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<Object>(path)) as GameObject;
        prefab.transform.SetParent(Selection.activeTransform, false);
        prefab.transform.localPosition = Vector3.zero;
        prefab.transform.localEulerAngles = Vector3.zero;
        prefab.transform.localScale = Vector3.one;
    }
#endif
}
