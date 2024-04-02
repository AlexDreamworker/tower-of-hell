using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleInputNamespace
{
	public class LookJoystick : MonoBehaviour
	{
		public SimpleInput.AxisInput xAxis = new SimpleInput.AxisInput("Horizontal");
		public SimpleInput.AxisInput yAxis = new SimpleInput.AxisInput("Vertical");

		private void OnEnable()
		{
			xAxis.StartTracking();
			yAxis.StartTracking();

			SimpleInput.OnUpdate += OnUpdate;
		}

		private void OnDisable()
		{
			xAxis.StopTracking();
			yAxis.StopTracking();

			SimpleInput.OnUpdate -= OnUpdate;
		}

		private void OnUpdate()
		{
			float mouseX = 0;
			float mouseY = 0;
			
			if (Input.touchCount == 0)
				return;

			if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			{
				if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Moved)
				{
					if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
						return;

					mouseX = Input.GetTouch(1).deltaPosition.x;
					mouseY = Input.GetTouch(1).deltaPosition.y;
				}
			}
			else
			{
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
				{
					if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
						return;

					mouseX = Input.GetTouch(0).deltaPosition.x;
					mouseY = Input.GetTouch(0).deltaPosition.y;
				}

			}
			
			xAxis.value = mouseX * -1;
			yAxis.value = mouseY * -1;
		}
	}
}