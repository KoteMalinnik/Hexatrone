/*
 * Класс создает сериализуемый объект, который содержит возможные цвета сфер
 */

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "NewColorSet", menuName = "ColorSet", order = 51)]
public class ColorSet: ScriptableObject, IEnumerable<Color>
{
    [SerializeField] private List<Color> colors = new List<Color>();

    public int Count => colors.Count;

    public Color GetColor(int index)
    {
        if (index < 0 || index >= Count) throw new System.ArgumentOutOfRangeException();

        return colors[index];
    }

    // IEnumerable<Color> interface implementation

    public IEnumerator<Color> GetEnumerator()
    {
        return ((IEnumerable<Color>)colors).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)colors).GetEnumerator();
    }
}
