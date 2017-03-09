using System;
using System.Collections.Generic;
using System.IO;
using DbSqLite.Db;
using Newtonsoft.Json;

namespace DbSqLite
{
    class Program
    {
        public static void Main(string[] args)
        {
            //const string path = @"C:\Users\hobrien\Documents\'Visual Studio 2013'\Projects\DbSqLite\DbSqLite\bin\Debug\QuizSystem.sqlite";
            //if (!File.Exists(path))
            //    CreateQuizSystem.CreateQuizSystemDb();

            var sql = "SELECT * FROM Questions";
            DbConnection.ConnectDatareader(sql);
            
            var json = "[ { \"questionNumber\": 1, \"text\": \"What do we do?\", \"answers\": [ { \"option\" : \"Gardening\", \"message\": \"No, We're not gardeners\", \"correct\" : false }, { \"option\" : \"Software Solutions\", \"message\": \"Correct Answer\", \"correct\" : true }, { \"option\" : \"Sheltered Accommodation for the Elderly\", \"message\": \"No, No accommodation here!\", \"correct\" : false } ], \"answerText\": \"Aspen Grove builds Property Management Software Solutions\" }, { \"questionNumber\": 2, \"text\": \"Are you interested in a career with Aspen Grove?\", \"answers\": [ { \"option\" : \"Yes\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"No\", \"message\": \"OK, but...\", \"correct\" : false }, { \"option\" : \"I'm only here for the chocolate biscuits!\", \"message\": \"Have a sweet instead!\", \"correct\" : false } ], \"answerText\": \"This is a perfect opportunity to apply if you are interested\" }, { \"questionNumber\": 3, \"text\": \"What field are you interested in?\", \"answers\": [ { \"option\" : \"Development\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"Business Analysis\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"Technical Support\", \"message\": \"Excellent\", \"correct\" : true } ], \"answerText\": \"We are presently recruiting for Development, QA, BA, Infrastructure/Networking, DB, PM, Tech Lead, Tech Support\" }]";
            var questions = JsonConvert.DeserializeObject<Question[]>(json);
            Console.WriteLine("\n\n" + questions);
            Console.ReadKey();
        }
    }

    public class Question
    {
        public int QuestionNumber { get; set; }
        public string Text { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public string AnswerText { get; set; }
    }

    public class Answer
    {
        public string Option { get; set; }
        public string Message { get; set; }
        public bool Correct { get; set; }
    }
}
