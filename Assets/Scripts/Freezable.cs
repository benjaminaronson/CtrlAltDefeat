using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
	private bool m_frozen = false;
	
	public bool isFrozen(){
		return m_frozen;
	}
	
	public void freeze(){
		setFrozen(true);
	}
	
	public void unfreeze(){
		setFrozen(false);
	}
	
	public void setFrozen(bool frozen){
		m_frozen = frozen;
	}
}
