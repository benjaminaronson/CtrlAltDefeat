using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SimpleMovingPlatform : Freezable
{
		public GameObject endPoint;
		
		// movement characteristics
		[Tooltip("Amount of time it takes for the platform to go from the start, to the end, and back to the start.")]
		public float timePerPeriod = 1f;
		
		// private stuff
		private float m_length;
		
		private float m_elapsedTime = 0;
		
		// path characteristics
		// note that the start point is assumed to be the position that the moving platform starts in
		private Vector3 m_startPoint;
		private Vector3 m_endPoint;
		private Vector3 m_direction;
		
    // Start is called before the first frame update
    public virtual void Start()
    {
			m_startPoint = transform.position;
			m_endPoint = endPoint.transform.position;
			
			m_direction = m_endPoint - m_startPoint;
			
			m_length = m_direction.magnitude;
    }

    // Update is called once per frame
    public virtual void Update()
    {
			if(!isFrozen()){
				// current position based on time
				// this is normalized to path length (makes speed consistent)
				float pos = (float)Math.Cos( (m_elapsedTime * Math.PI * 2) / timePerPeriod );
				
				// normalize to 0, 1 range
				pos = (-pos + 1) / 2;
				
				// determine position in path
				// 0 = startPoint
				// 1 = endPoint
				Vector3 position = m_startPoint + m_direction * pos;
				
				// set position
				transform.position = position;
				
				// increment elapsed time
				m_elapsedTime += Time.deltaTime;
			}
    }
}
