﻿using UnityEngine;

/// <summary>
/// Логирование в консоль Unity.
/// </summary>
public static class Log
{
	/// <summary>
	/// Выведет сообщение message в консоль Unity.
	/// </summary>
	/// <param name="message">Сообщение.</param>
	public static void Message(object message, string color = "green")
	{
		Debug.Log($"<color={color}>{GetMessageInfo()}</color> -> {message}");
	}

	/// <summary>
	/// Выведет предупреждение message в консоль Unity.
	/// </summary>
	/// <param name="message">Сообщение.</param>
	public static void Warning(object message, string color = "yellow")
	{
		Debug.LogWarning($"<color={color}>{GetMessageInfo()}</color> -> {message}");
	}

	/// <summary>
	/// Выведет ошибку с сообщением message в консоль Unity.
	/// </summary>
	/// <param name="message">Сообщение.</param>
	public static void Error(object message, string color = "red")
	{
		Debug.LogError($"<color={color}>{GetMessageInfo()}</color> -> {message}");
	}

	/// <summary>
	/// Выводит в лог заглушку с именем метода
	/// </summary>
	public static void Stub()
    {
		Debug.Log($"<color=aqua>Stub -></color> {GetMessageInfo()}");
	}

	private static string GetMessageInfo()
	{
		//Получение имени вызывающего класса и метода с учетом наследования
		var stacktrace = new System.Diagnostics.StackTrace();
		var frameCount = stacktrace.FrameCount;
		var lastFrame = stacktrace.GetFrame(frameCount - 1);

		var callbackClassName = lastFrame.GetMethod().ReflectedType.Name;
		var methodName = stacktrace.GetFrame(2).GetMethod(); //2 фрейм, т.к. 1 - это один из методов данного класса

		return $"[{callbackClassName} : {methodName}]";
	}
}