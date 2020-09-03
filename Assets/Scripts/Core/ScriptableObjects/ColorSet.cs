using UnityEngine;

[CreateAssetMenu(fileName = "NewColorSet", menuName = "ColorSet", order = 51)]
public class ColorSet: ScriptableObject
{
    #region Fields
    [SerializeField] Color[] colors = new Color[0];
    #endregion

    #region Properties
    public int Lenght => colors.Length;
    #endregion

    public Color GetColor(int index)
    {
        if (index < 0 || index > Lenght - 1) throw new System.ArgumentOutOfRangeException();
        return colors[index];
    }
}
