namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TraitInstance
	{
		private TraitDescriptor m_Descriptor;

		public TraitDescriptor Descriptor => m_Descriptor;
		public string IDName => m_Descriptor.IDName;

		public TraitInstance(TraitDescriptor descriptor)
		{
			m_Descriptor = descriptor;
		}
	}
}
