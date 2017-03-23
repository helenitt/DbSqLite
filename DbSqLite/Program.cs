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
            var user = new UserResponse { UserId = 19 }; 
            const string path = "QuizSystem.sqlite";
            const int milliseconds = 1000;
            
            if (!File.Exists(path))
                CreateQuizSystem.CreateQuizSystemDb();
          
            Console.WriteLine("\nQuestions retrieved from JSON string\n");
            const string json = "[ { \"questionNumber\": 1, \"text\": \"What do we do?\", \"answers\": [ { \"option\" : \"g\", \"message\": \"No, We're not gardeners\", \"correct\" : false }, { \"option\" : \"ss\", \"message\": \"Correct Answer\", \"correct\" : true }, { \"option\" : \"Sheltered Accommodation for the Elderly\", \"message\": \"No, No accommodation here!\", \"correct\" : false } ], \"answerText\": \"Aspen Grove builds Property Management Software Solutions\" }, { \"questionNumber\": 2, \"text\": \"Are you interested in a career with Aspen Grove?\", \"answers\": [ { \"option\" : \"y\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"n\", \"message\": \"OK, but...\", \"correct\" : false }, { \"option\" : \"I'm only here for the chocolate biscuits!\", \"message\": \"Have a sweet instead!\", \"correct\" : false } ], \"answerText\": \"This is a perfect opportunity to apply if you are interested\" }, { \"questionNumber\": 3, \"text\": \"What field are you interested in?\", \"answers\": [ { \"option\" : \"dev\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"ba\", \"message\": \"Excellent\", \"correct\" : true }, { \"option\" : \"qa\", \"message\": \"Excellent\", \"correct\" : true } ], \"answerText\": \"We are presently recruiting for Development, QA, BA, Infrastructure/Networking, DB, PM, Tech Lead, Tech Support\" }]";
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

                foreach (var answer in question.Answers) // Change to LINQ-Expression
                {
                    if (response == answer.Option)
                    {
                        Console.WriteLine(answer.Message);
                        FillQuizSystem.InsertToResponseOption(user.UserId, question.QuestionNumber, response);
                    }    
                }

                Console.WriteLine("\n{0}\n\n", question.AnswerText);
                Thread.Sleep(milliseconds);
            }

            Console.WriteLine("Would you like to enter our competition? Just enter your name: ");
            user.Name = Console.ReadLine();
            Console.WriteLine("and your email: ");
            user.Email = Console.ReadLine();
            FillQuizSystem.InsertToUserResponse(user.UserId, user.Name, user.Email);
            
            Console.WriteLine("\n\nThank You " + user.Name);

            Console.WriteLine("\n\nTest Data Retrieval\n");

            var dataReader = FillQuizSystem.SelectResponses(user.UserId);
            while (dataReader.Read())
                Console.WriteLine("Question " + dataReader["questionNumber"] + ".\tResponse: " + dataReader["optionSelected"]);
            DbConnection.ConnectClose();

            var userReader = FillQuizSystem.SelectUserDetails(user.UserId);
            userReader.Read();
            Console.WriteLine("\n\nName: " + userReader["name"] + "\tEmail: " + userReader["email"]);
            DbConnection.ConnectClose();

            Console.WriteLine("\n\nPress any key to exit");
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

    public class UserResponse
    {
        public int UserId { get; set; }
        public IEnumerable<Option> Options { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Option 
    {
        public int QuestionNumber { get; set; } 
        public string OptionSelected { get; set; }
    }
}
