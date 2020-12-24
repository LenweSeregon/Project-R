namespace com.CompanyR.FrameworkR.Core
{
    using System.Collections;
	using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;

	public class DebugLogger
	{
		private static string GetStackInfo()
		{
			System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame(2, true);
			MethodBase method = stackFrame.GetMethod();

			return string.Format("<size=12><b><color=silver>[{0}/{1}:{2}] </color></b></size>",
				method.ReflectedType.FullName, stackFrame.GetMethod().Name, stackFrame.GetFileLineNumber());
		}

		public static void Log(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log(GetStackInfo() + message, context);
			}
		}

		public static void Log(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log(GetStackInfo() + message);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertion(GetStackInfo() + message, context);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertion(GetStackInfo() + message);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertionFormat(context, GetStackInfo() + format, args);
			}
		}

		[System.Diagnostics.Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogAssertionFormat(GetStackInfo() + format, args);
			}
		}

		public static void LogError(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(GetStackInfo() + message);
			}
		}

		public static void LogError(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(GetStackInfo() + message, context);
			}
		}

		public static void LogErrorFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogErrorFormat(GetStackInfo() + format, args);
			}
		}

		public static void LogErrorFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogErrorFormat(context, GetStackInfo() + format, args);
			}
		}

		public static void LogException(System.Exception exception)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(GetStackInfo() + " threw an exception");
				Debug.LogException(exception);
			}
		}

		public static void LogException(System.Exception exception, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(GetStackInfo() + " threw an exception");
				Debug.LogException(exception, context);
			}
		}

		public static void LogFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(context, GetStackInfo() + format, args);
			}
		}

		public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(logType, logOptions, context, GetStackInfo() + format, args);
			}
		}

		public static void LogFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogFormat(GetStackInfo() + format, args);
			}
		}

		public static void LogWarning(object message, Object context)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning(GetStackInfo() + message, context);
			}
		}

		public static void LogWarning(object message)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning(GetStackInfo() + message);
			}
		}

		public static void LogWarningFormat(Object context, string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarningFormat(context, GetStackInfo() + format, args);
			}
		}

		public static void LogWarningFormat(string format, params object[] args)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarningFormat(GetStackInfo() + format, args);
			}
		}
	}
}

