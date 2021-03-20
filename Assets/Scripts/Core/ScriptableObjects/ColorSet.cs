using UnityEngine;

[CreateAssetMenu(fileName = "NewColorSet", menuName = "ColorSet", order = 51)]
public class ColorSet: ScriptableObject
{
    [SerializeField] Color[] colors = new Color[0];

    public int Lenght => colors.Length;

    public Color GetColor(int index)
    {
        if (index < 0 || index > Lenght - 1) throw new System.ArgumentOutOfRangeException();
        return colors[index];
    }
}
