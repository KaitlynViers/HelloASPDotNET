using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        //uses /<controller>
       [HttpGet]
      // [Route("/helloworld/")]
      //moved ^ to made the code dry.
       
        public IActionResult Index()
        {
            //string html = "<h1>Hello World</h1>";
            string html = "<form method='post' action='/helloworld/'>" +
                "<input type='text' name='name' />" +
                "<select name='Language'>" +
                "<option value='English' selected<English</option>" +
                "<option value='Spanish'>Spanish</option>" +
                "<option value='French'>French</option>" +
                "<option value='Italian'>Italian</option>" +
                "<option value='German'>German</option></select>" +
                "<input type='submit' value='Greet Me!'>" +
                "</form>";
            return Content(html, "text/html");
            //Instead of having just hello world, we added a button that user could input their name.
        }
        // Uses /hello/welcome
        // [HttpGet]
        //[Route("/helloworld/welcome/{name}")]
        //We changed Get to Post since we are posting the information and not getting.
        [HttpGet("/welcome/{name?}")]
        [HttpPost]
        //[Route("/helloworld/")]
        //Moved ^ to make the code dry

        public IActionResult Welcome(string name = "World")
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");    
        }

        [HttpGet("")]
        public  static string CreateMessage(string name,string language)
        {
            string helloTranslation = "";
                switch (language)
            {
                case "English":
                    helloTranslation = "Hello";
                    break;

                case "Spanish":
                    helloTranslation = "Hola";
                    break;

                case "French":
                    helloTranslation = "Bonjour";
                    break;

                case "Italian":
                    helloTranslation = "Ciao";
                    break;

                case "German":
                    helloTranslation = "Hallo";
                    break;

            }
            return helloTranslation + name;

        } 
    }
}
