using UnityEngine;
using UnityEngine.UI;

// Goes on the large logo main menu object
public class LargeLogo : MonoBehaviour
{

	public float fadeStartDelayLength = 3;
	public AnimationCurve fadeCurve;

	private float currentAlpha = 0;

	private Image largeLogo;
	private float length;

	private void Start ()
	{
		
		Keyframe lastKey = fadeCurve.keys[fadeCurve.keys.Length - 1];

		length = lastKey.time + 0.5f;

		largeLogo = GetComponent<Image>();
	}

	private void FixedUpdate ()
	{

		if (fadeStartDelayLength <= 0)
		{

			largeLogo.color = new Color(1, 1, 1, fadeCurve.Evaluate(currentAlpha));
			currentAlpha += Time.fixedDeltaTime;
		}
		else
		{

			fadeStartDelayLength -= Time.fixedDeltaTime;
		}

		if (currentAlpha >= length)
		{

			this.gameObject.transform.parent.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
			this.enabled = false;
		}
	}
}
