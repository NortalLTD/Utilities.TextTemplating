﻿using System;

namespace Nortal.Utilities.TextTemplating.Parsing
{
	/// <summary>
	/// Represents a command which includes a reference to a value within a model this template is executed on.
	/// </summary>
	public class ModelPathCommand : Command
	{
		public ModelPathCommand() { }
		public ModelPathCommand(CommandType type, TemplateSentence source) : base(type, source) { }

		internal String ModelPath { get; set; }
	}
}
