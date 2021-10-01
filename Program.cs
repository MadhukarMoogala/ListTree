using Autodesk.Forge;
using Autodesk.Forge.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using static ListTree.DataManagement;

namespace ListTree
{
    public class ForgeConfiguration
    {
        public static readonly HttpRequestOptionsKey<string> ScopeKey;
        public static readonly HttpRequestOptionsKey<int> TimeoutKey;

        public ForgeConfiguration() { }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri AuthenticationAddress { get; set; }
    }
    class Program
    {

        // Constants for drawing lines and spaces
        private const string _cross = " ├─";
        private const string _corner = " └─";
        private const string _vertical = " │ ";
        private const string _space = "   ";
        static void PrintNode(TreeNode node, string indent)
        {
            Console.WriteLine(node.Text);

            // Loop through the children recursively, passing in the
            // indent, and the isLast parameter
            var numberOfChildren = node.Children.Count;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var child = node.Children[i];
                var isLast = (i == (numberOfChildren - 1));
                PrintChildNode(child, indent, isLast);
            }
        }

        static void PrintChildNode(TreeNode node, string indent, bool isLast)
        {
            // Print the provided pipes/spaces indent
            Console.Write(indent);

            // Depending if this node is a last child, print the
            // corner or cross, and calculate the indent that will
            // be passed to its children
            if (isLast)
            {
                Console.Write(_corner);
                indent += _space;
            }
            else
            {
                Console.Write(_cross);
                indent += _vertical;
            }

            PrintNode(node, indent);
        }

        static void Main(string[] args)
        {
           
            var daConfig = new ConfigurationBuilder()                
                .AddJsonFile("appsettings.user.json")
                .Build();

            ForgeConfiguration forgeConfiguration = daConfig.GetSection("Forge").Get<ForgeConfiguration>();
            var oAuthHandler = OAuthHandler.Create(forgeConfiguration);

            //We want to sleep the thread untill we get 3L accessk_token.
            //https://stackoverflow.com/questions/6306168/how-to-sleep-a-thread-until-callback-for-asynchronous-function-is-received
            AutoResetEvent stopWaitHandle = new AutoResetEvent(false);
            oAuthHandler.Invoke3LeggedOAuth(async (bearer) =>
            {
                // This is our application delegate. It is called upon success or failure
                // after the process completed
                if (bearer == null)
                {
                    Console.Error.WriteLine("Sorry, Authentication failed!", "3legged test");
                    return;
                }
                // The call returned successfully and you got a valid access_token.                
                DateTime dt = DateTime.Now;
                dt.AddSeconds(double.Parse(bearer.expires_in.ToString()));
                

                UserProfileApi profileApi = new UserProfileApi();
                profileApi.Configuration.AccessToken = bearer.access_token;
                DynamicJsonResponse userResponse = await profileApi.GetUserProfileAsync();
                UserProfile user = userResponse.ToObject<UserProfile>();
                Console.WriteLine($"Hello {user.FirstName}, You are in!");

                DataManagement management = new DataManagement(forgeConfiguration);
                var TreeNodes = await management.GetList(bearer);
                foreach (var node in TreeNodes)
                {
                    PrintNode(node, indent: "");
                }

                stopWaitHandle.Set();
            });
            stopWaitHandle.WaitOne();
        }
    }
}
