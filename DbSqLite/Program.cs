using System;
using System.Collections.Generic;
using System.IO;
using DbSQLite.Db;
using Newtonsoft.Json;
using System.Threading;

namespace DbSQLite
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Don't want absolute path
            // string path = @"C:\Users\Helen\Documents\Visual Studio 2015\Projects\DbSqLite\DbSqLite\bin\Debug\QuizSystem.sqlite";
            // Useful
            //Console.WriteLine(Environment.CurrentDirectory);

            // Option 1
            // Path.Combine(Environment.CurrentDirectory, "QuizSystem.sqlite");

            // Option 2
            string path = "QuizSystem.sqlite";

            const int milliseconds = 2000;

            //if (!File.Exists(path))
            //    CreateQuizSystem.CreateQuizSystemDb();

            Console.WriteLine(File.Exists(path) ? "File Exists\n" : "File Does Not Exist");
            
            Console.WriteLine("Questions retrieved from Db\n");
            var sql = "SELECT * FROM Questions";
            DbConnection.ConnectDatareader(sql);

            Console.WriteLine("\n\nQuestions retrieved from JSON string\n");
            var json = "[ { \"questionNumber\": 1, \"text\": \"What do we do?\", \"answers\": [ { \"option\" : \"Gardening\", \"message\": \"No, We're not gardeners\", \"correct\" : false }, { \"option\" : \"Software Solutions\", \"message\": \"Correct Answer\", \"correct\" : true }, { \"option\" : \"Sheltered Accommodation for the Elderly\", \"message\": \"No, No accommodation here!\", \"correct\" : false } ], \"answerText\": \"Aspen Grove builds Property Management Software Solutions\" }, { \"questionNumber\": 2, \"text\": \"Are you interested in a career with Aspen Grove?\", \"answers\": [ { \"option\" : \"Yes\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"No\", \"message\": \"OK, but...\", \"correct\" : false }, { \"option\" : \"I'm only here for the chocolate biscuits!\", \"message\": \"Have a sweet instead!\", \"correct\" : false } ], \"answerText\": \"This is a perfect opportunity to apply if you are interested\" }, { \"questionNumber\": 3, \"text\": \"What field are you interested in?\", \"answers\": [ { \"option\" : \"Development\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"Business Analysis\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"Technical Support\", \"message\": \"Excellent\", \"correct\" : true } ], \"answerText\": \"We are presently recruiting for Development, QA, BA, Infrastructure/Networking, DB, PM, Tech Lead, Tech Support\" }]";
            var questions = JsonConvert.DeserializeObject<Question[]>(json);

            foreach (var question in questions)
            {
                Console.WriteLine("{0}. {1}\n", question.QuestionNumber, question.Text);

                foreach (var answer in question.Answers)
                {
                    Console.WriteLine(answer.Option);
                }

                Console.WriteLine("\n");
                var response = Console.ReadLine();

                foreach (var answer in question.Answers)
                {
                    if (response == answer.Option)
                        Console.WriteLine(answer.Message);
                }

                Console.WriteLine("\n{0}\n\n", question.AnswerText);
                Thread.Sleep(milliseconds);
            }


            // Console.WriteLine("\n\n" + json.text); // not on string must be a file.json or .js?

            Console.WriteLine("Press any key to exit");
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
