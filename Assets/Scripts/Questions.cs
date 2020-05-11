using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace LoadQuestions
{
	[XmlRoot(ElementName = "Element")]
	public class Element
	{
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Text")]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Elements")]
	public class Elements
	{
		[XmlElement(ElementName = "Element")]
		public List<Element> Element { get; set; }
	}

	[XmlRoot(ElementName = "Question")]
	public class Question
	{
		[XmlElement(ElementName = "QuestionText")]
		public string QuestionText { get; set; }
		[XmlElement(ElementName = "AnswerValue")]
		public int AnswerValue { get; set; }
		[XmlElement(ElementName = "Elements")]
		public Elements Elements { get; set; }
	}

	[XmlRoot(ElementName = "Questions")]
	public class Questions
	{
		[XmlElement(ElementName = "Question")]
		public List<Question> Question { get; set; }
	}
}
