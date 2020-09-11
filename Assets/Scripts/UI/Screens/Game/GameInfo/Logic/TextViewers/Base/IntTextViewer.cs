using UnityEngine;
using UnityEngine.UI;

public abstract class IntTextViewer : MonoBehaviour
{
	#region Fields
	[SerializeField] Text text_value = null;
	#endregion

	#region Properties
	protected Text TextValue => text_value;
	#endregion

	#region Abstract Methods
	protected abstract void UpdateText(int newValue);

	protected abstract void OnEnable();
	protected abstract void OnDisable();
	#endregion
}
