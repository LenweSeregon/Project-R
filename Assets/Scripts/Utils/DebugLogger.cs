namespace com.CompanyR.FrameworkR.Utils
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class DebugLogger
	{
		public static void Log(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log(message, context);
			}
		}

		public static void Log(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log(message);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertion(message, context);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertion(message);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertionFormat(context, format, args);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertionFormat(format, args);
			}
		}

		public static void LogError(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(message);
			}
		}

		public static void LogError(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(message, context);
			}
		}

		public static void LogErrorFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogErrorFormat(format, args);
			}
		}

		public static void LogErrorFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogErrorFormat(context, format, args);
			}
		}

		public static void LogException(System.Exception exception)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogException(exception);
			}
		}

		public static void LogException(System.Exception exception, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogException(exception, context);
			}
		}

		public static void LogFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(context, format, args);
			}
		}

		public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(logType, logOptions, context, format, args);
			}
		}

		public static void LogFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(format, args);
			}
		}

		public static void LogWarning(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning(message, context);
			}
		}

		public static void LogWarning(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning(message);
			}
		}

		public static void LogWarningFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarningFormat(context, format, args);
			}
		}

		public static void LogWarningFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarningFormat(format, args);
			}
		}
	}
}

