using System;
using System.Collections.Generic;
using static Trustev.Domain.Enums;

namespace Trustev.Domain.Entities
{
    public class KBAResult
    {
        public DateTime Timestamp { get; set; }
        public KBAStatus Status { get; set; }
        public string  Message { get; set; }
        public string AnswerUrl { get; set; }
        /// <summary>
        ///  Questions and Answers
        /// </summary>
        public List<QuestionsResult> Questions { get; set; }
        /// <summary>
        ///  MultiPass Question and Answer
        /// </summary>
        public List<QuestionsResult> MultiPassQuestions { get; set; }
        public MultiPassStatus MultiPassStatus { get; set; }
    }

    public class QuestionsResult
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<ChoicesResult> Choices { get; set; }
    }

    public class ChoicesResult
    {
        public int Id { get; set; }
        public bool Answer { get; set; }
        public string ChoiceText { get; set; }
    }
}
