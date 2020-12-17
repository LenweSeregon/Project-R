namespace com.CompanyR.FrameworkR.Utils
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class DebugLogger
	{
		public static void Log(object message, Object context)
		{
#if UNITY_EDITOR
			Debug.Log(message, context);
#endif
		}

		public static void Log(object message)
		{
#if UNITY_EDITOR
			Debug.Log(message);
#endif
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message, Object context)
		{
#if UNITY_EDITOR
			Debug.LogAssertion(message, context);
#endif
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
#if UNITY_EDITOR
			Debug.LogAssertion(message);
#endif
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(Object context, string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogAssertionFormat(context, format, args);
#endif
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogAssertionFormat(format, args);
#endif
		}

		public static void LogError(object message)
		{
#if UNITY_EDITOR
			Debug.LogError(message);
#endif
		}

		public static void LogError(object message, Object context)
		{
#if UNITY_EDITOR
			Debug.LogError(message, context);
#endif
		}

		public static void LogErrorFormat(string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogErrorFormat(format, args);
#endif
		}

		public static void LogErrorFormat(Object context, string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogErrorFormat(context, format, args);
#endif
		}

		public static void LogException(System.Exception exception)
		{
#if UNITY_EDITOR
			Debug.LogException(exception);
#endif
		}

		public static void LogException(System.Exception exception, Object context)
		{
#if UNITY_EDITOR
			Debug.LogException(exception, context);
#endif
		}

		public static void LogFormat(Object context, string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogFormat(context, format, args);
#endif
		}

		public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogFormat(logType, logOptions, context, format, args);
#endif
		}

		public static void LogFormat(string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogFormat(format, args);
#endif
		}

		public static void LogWarning(object message, Object context)
		{
#if UNITY_EDITOR
			Debug.LogWarning(message, context);
#endif
		}

		public static void LogWarning(object message)
		{
#if UNITY_EDITOR
			Debug.LogWarning(message);
#endif
		}

		public static void LogWarningFormat(Object context, string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogWarningFormat(context, format, args);
#endif
		}

		public static void LogWarningFormat(string format, params object[] args)
		{
#if UNITY_EDITOR
			Debug.LogWarningFormat(format, args);
#endif
		}
	}
}

