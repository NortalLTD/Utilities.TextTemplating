﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nortal.Utilities.TextTemplating.Tests
{
	[TestClass]
	public class SyntaxChangeTests
	{
		private const String TemplateContentPrefix = @"Some document prefix";
		private const String TemplateContentSuffix = @"Some suffix";

		private const String ExpectedValue = @"EXPECTED";

		[TestInitialize]
		public void Initialize()
		{
			SyntaxSettings settings = new SyntaxSettings();
			settings.BeginTag = "<b>";
			settings.EndTag = "</b>";
			settings.ConditionalStartCommand = "kui";
			settings.ConditionalElseCommand = "muidu";
			settings.ConditionalEndCommand = "/kui";
			settings.LoopStartCommand = "tsükkel";
			settings.LoopEndCommand = "/tsükkel";

			this.Engine = new TemplateProcessingEngine(settings);
		}

		private TemplateProcessingEngine Engine { get; set; }

		[TestMethod]
		public void TestCustomSyntax()
		{
			var model = new
			{
				ABoolean = true,
				AField = ExpectedValue,
				Items = "123".ToCharArray()
			};
			const String template = TemplateContentPrefix
				+ "<b>kui(ABoolean)</b>"
					+ ExpectedValue
				+ "<b>/kui(ABoolean)</b>"
				+ "<b>AField</b>"
				+ "<b>tsükkel(Items)</b>"
				+ "X"
				+ "<b>/tsükkel(Items)</b>"
				+ TemplateContentSuffix;

			String expectedResult = TemplateContentPrefix
				+ ExpectedValue
				+ model.AField
				+ "XXX"
				+ TemplateContentSuffix;

			String actual = this.Engine.Process(template, model);
			Assert.AreEqual(expectedResult, actual);
		}
	}
}
