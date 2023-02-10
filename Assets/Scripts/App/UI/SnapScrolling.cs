using System;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;

namespace App.UI
{
	public class SnapScrolling : MonoBehaviour
	{
		public Action<Template> OnTemplateSnapped;
		
		private SnapScrollingItem _item = null;
		private Template _snappedTemplate;
		private int _previousNearestSnapIndex;

		public bool IsVertical;
		
		[Header("Snapping")]
		[Range(1, 50)]
		[SerializeField]
		private float _snapSpeed = 25;
		[SerializeField]
		private float _scrollingVelocitySnapThreshold = 400;
		[SerializeField]
		private bool _inertiaWhenScrolling = true;

		[Header("Scaling")]
		[Range(1f, 100f)]
		[SerializeField]
		public float _scaleSpeed;
		[SerializeField]
		public float _minScale = 1;
		[SerializeField]
		public float _maxScale = 1.2f;
		[SerializeField]
		public float _circleRadius = 3f;
		[SerializeField]
		public float _maxCircleDistance = 1000f;

		[SerializeField]
		public float _minScaleDst = 400;
		[SerializeField]
		public float _maxScaleDst = 200;

		[Header("Others")]
		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private float _itemOffset = 50;

		private RectTransform _contentRect;
		private bool _isScrolling;

		private int _count;
		private int _lastIndex = -1;

		private void Start()
		{
			Attach();
		}

		private void OnValidate()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
			{
				if (_contentRect != null)
				{
					Attach();
				}
			}
#endif
		}

		private int FindNearestChildIndex()
		{
			var nearestPos = float.MaxValue;
			var res = -1;
			for (int i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				if (child.gameObject.activeSelf)
				{
					var delta = 0f;
					if (IsVertical)
					{
						delta = _scrollRect.transform.position.y - child.position.y;
					}
					else
					{
						delta = _scrollRect.transform.position.x - child.position.x;
					}
					var distance = Mathf.Abs(delta);
					if (distance < nearestPos)
					{
						nearestPos = distance;
						res = i;
					}
				}
			}

			return res;
		}

		private void Update()
		{
			if (_count != transform.childCount)
			{
				Attach();
				return;
			}

			if (_lastIndex == -1)
			{
				SyncOrder();
			}

			for (int i = 0; i < transform.childCount; i++)
			{
				var item = transform.GetChild(i).GetComponent<RectTransform>();
				var scale = CalculateScale(item);

				var currScale = item.localScale.x;
				currScale = Mathf.SmoothStep(currScale, scale, _scaleSpeed * Time.unscaledDeltaTime);
				item.localScale = new Vector3(currScale, currScale, 1);
			}

			Snap();
		}

		private float CalculateScale(Transform item)
		{
			var distance = 0f;
			if (IsVertical)
			{
				distance = Mathf.Abs(_scrollRect.transform.position.y - item.position.y);
			}
			else
			{
				distance = Mathf.Abs(_scrollRect.transform.position.x - item.position.x);
				item.localPosition = new Vector3(
					item.localPosition.x, 
					(distance < _maxCircleDistance ? distance : _maxCircleDistance) * _circleRadius, 
					item.localPosition.z);
			}
			
			var dstFactor = Mathf.Clamp01((distance - _maxScaleDst) / (_minScaleDst - _maxScaleDst));
			return Mathf.Lerp(_minScale, _maxScale , 1.0f - dstFactor);
		}

		private void Snap()
		{
			var velocity = IsVertical ? _scrollRect.velocity.y : _scrollRect.velocity.x;
			var scrollVelocity = Mathf.Abs(velocity);
			if (scrollVelocity < _scrollingVelocitySnapThreshold && !_isScrolling)
			{
				var nearestIdx = FindNearestChildIndex();
				if (nearestIdx >= 0)
				{
					_scrollRect.inertia = false;
					var pos = _contentRect.anchoredPosition;
					if (IsVertical)
					{
						pos.y = Mathf.SmoothStep(_contentRect.anchoredPosition.y,
							-transform.GetChild(nearestIdx).GetComponent<RectTransform>().anchoredPosition.y,
							_snapSpeed * Time.unscaledDeltaTime);
					}
					else
					{
						pos.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x,
							-transform.GetChild(nearestIdx).GetComponent<RectTransform>().anchoredPosition.x,
							_snapSpeed * Time.unscaledDeltaTime);
					}
					_contentRect.anchoredPosition = pos;
					
					if (_item == null)
					{
						_item = transform.GetChild(nearestIdx)
							.GetComponentInChildren<SnapScrollingItem>();
						if (_item != null)
						{
							_lastIndex = nearestIdx;
							transform.GetChild(nearestIdx).SetAsLastSibling();
						}
					}
					
					_previousNearestSnapIndex = nearestIdx;
				}
			}
			else
			{
				if (_item != null)
				{
					_item = null;
					transform.GetChild(transform.childCount - 1).SetSiblingIndex(_lastIndex);
					_lastIndex = -1;
				}
			}

			if (transform.GetChild(_previousNearestSnapIndex).TryGetComponent<Template>(out var template))
			{
				CallbackSnapTemplate(template);
			}
		}

		private void CallbackSnapTemplate(Template template)
		{
			if (_snappedTemplate == template)
			{
				return;
			}

			_snappedTemplate = template;
			OnTemplateSnapped?.Invoke(_snappedTemplate);
		}

		public void Attach()
		{
			if (_contentRect == null)
			{
				_contentRect = GetComponent<RectTransform>();
			}
			
			Attach(FindNearestChildIndex());
		}

		public void FirstAttach()
		{
			if (_contentRect == null)
			{
				_contentRect = GetComponent<RectTransform>();
			}
			
			for (var i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				var offset = child.position;
				if (IsVertical)
				{
					offset.y = 100 * (i - 1);
					child.position = offset;
				}
				else
				{
					offset.x = 100 * (i - 1);
					child.position = offset;
				}
			}
		}

		private void Attach(int idx)
		{
			if (idx < 0)
			{
				return;
			}

			var target = transform.GetChild(idx).GetComponent<RectTransform>();
			var scale = CalculateScale(target);
			target.localScale = new Vector3(scale, scale, 1);

			_scrollRect.velocity = Vector2.zero;
			_scrollRect.inertia = false;
			if (IsVertical)
			{
				_contentRect.anchoredPosition = new Vector2(target.anchoredPosition.x, -_contentRect.anchoredPosition.y);
			}
			else
			{
				_contentRect.anchoredPosition = new Vector2(-target.anchoredPosition.x, _contentRect.anchoredPosition.y);
			}

			for (int i = idx - 1; i >= 0; i--)
			{
				if (transform.GetChild(i).gameObject.activeSelf)
				{
					SyncItem(i, false);
				}
			}

			for (int i = idx + 1; i < transform.childCount; i++)
			{ 
				if (transform.GetChild(i).gameObject.activeSelf)
				{
					SyncItem(i, true);
				}
			}

			SyncOrder();
			_count = transform.childCount;
		}

		private void SyncItem(int i, bool forward)
		{
			var child = transform.GetChild(i).GetComponent<RectTransform>();
			var dir = forward ? -1 : 1;
			var prevIdx = i + dir;
			while (!transform.GetChild(prevIdx).gameObject.activeSelf)
			{
				prevIdx += dir;
			}
			var prev = transform.GetChild(prevIdx).GetComponent<RectTransform>();
			var pos = prev.anchoredPosition;
			if (IsVertical)
			{
				pos.y -= dir * (prev.sizeDelta.y + _itemOffset);
			}
			else
			{
				pos.x -= dir * (prev.sizeDelta.x + _itemOffset);
			}
			child.anchoredPosition = pos;
			var scale = CalculateScale(child);
			child.localScale = new Vector3(scale, scale, 1);
		}


		private void SyncOrder()
		{
			var childCount = transform.childCount;

			var nearestIndex = FindNearestChildIndex();
			var left = 0;
			var right = 0;

			for (int i = 0; i < nearestIndex; i++)
			{
				if (transform.GetChild(i).gameObject.activeSelf)
				{
					left++;
				}
			}

			for (int i = nearestIndex + 1; i < childCount; i++)
			{
				if (transform.GetChild(i).gameObject.activeSelf)
				{
					right++;
				}
			}


			while (right - left > 1)
			{
				var last = transform.GetChild(childCount - 1);
				last.SetAsFirstSibling();
				SyncItem(0, false);
				right--;
				left++;
			}

			while (left - right > 1)
			{
				var first = transform.GetChild(0);
				first.SetAsLastSibling();
				SyncItem(childCount - 1, true);
				left--;
				right++;
			}
		}

		public void Scrolling(bool scroll)
		{
			_isScrolling = scroll;
			if (scroll) _scrollRect.inertia = _inertiaWhenScrolling;
		}
	}
}