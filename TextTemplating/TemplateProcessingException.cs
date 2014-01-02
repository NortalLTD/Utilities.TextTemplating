﻿using System;
using System.Runtime.Serialization;

namespace Nortal.Utilities.TextTemplating
{
	/// <summary>
	/// Exception thrown when text template processing failure occured.
	/// </summary>
	[Serializable]
	public class TemplateProcessingException : Exception
	{
		public TemplateProcessingException() { }
		public TemplateProcessingException(string message) : base(message) { }
		public TemplateProcessingException(string message, Exception inner) : base(message, inner) { }
		protected TemplateProcessingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
