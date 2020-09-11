using UnityEngine;
using UnityEngine.UI;

namespace CustomScreen.Logic
{
	public abstract class SliderController : MonoBehaviour
	{
		#region Fields
		[SerializeField] Slider slider = null;
		Image fillRectImage = null;

		[SerializeField] ColorSet colorSet = null;
		#endregion

		#region Properties
		protected Slider Slider => slider;
		protected ColorSet ColorSet => colorSet;
		protected Image FillRectImage
		{
			get
            {
				if (fillRectImage != null) return fillRectImage;

				fillRectImage = slider.fillRect.GetComponent<Image>();
				return fillRectImage;
			}
		}
        #endregion

		#region Abstract Methods
		protected abstract void UpdateValue(int newValue);
		protected abstract void UpdateColor(int formLevel);
		protected abstract void UpdateMaxValue(int newMaxValue);

		protected abstract void OnEnable();
		protected abstract void OnDisable();
		#endregion

	}
}