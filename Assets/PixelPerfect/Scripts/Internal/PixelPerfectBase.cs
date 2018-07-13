using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PixelPerfectBase : MonoBehaviour {

	[Range(1,10)]public int  pixelScale=1;
	public bool scaledSnap=false;
	[Tooltip("Destroys this script during runtime (performance improvement)")]
	public bool isStatic=true;
	
	protected Vector3 fixedPosition;
	protected Vector3 checkPosition;
	protected float   checkPixelScale;
	protected Vector3 offset=Vector3.zero;

	void Start() {
		if (isStatic && Application.isPlaying) {
			Destroy(this);
		}
	}

	public void LateUpdate() {
		UpdateScale();
		UpdatePosition();
	}
	
	public virtual void UpdateScale() {
		if (checkPixelScale!=pixelScale) {
			Transform saveParent=transform.parent;
			transform.parent=null;
			transform.localScale=new Vector3(
				Mathf.Sign(transform.localScale.x)*pixelScale,
				Mathf.Sign(transform.localScale.y)*pixelScale,
				transform.localScale.z);
			transform.parent=saveParent;
			checkPixelScale=pixelScale;
		}
	}
	
	public virtual void UpdatePosition() {
		if (checkPosition!=transform.position) {
			float snapFactor=scaledSnap?pixelScale:1;
			
			fixedPosition=new Vector3(
				Mathf.Floor((transform.position.x+offset.x)/(PixelPerfect.unitsPerPixel*snapFactor))*PixelPerfect.unitsPerPixel*snapFactor,
				Mathf.Floor((transform.position.y+offset.y)/(PixelPerfect.unitsPerPixel*snapFactor))*PixelPerfect.unitsPerPixel*snapFactor,
				transform.position.z);
			transform.position=fixedPosition-offset;
			
			checkPosition=transform.position;
		}
	}
}
