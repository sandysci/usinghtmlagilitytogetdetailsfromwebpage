using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;



namespace usinghtmlagility
{
    class Program
    {
        static void Main(string[] args)
        {
          
            first();// calling the first function
            second();// calling the second function

            Console.ReadLine();
        }
        static void first()
        {

            string mypath = @" C:\Users\USER\Documents\allfilework\newfile1.txt";//creates a txt file in the folder allfletext in my document folder
            HtmlWeb webget = new HtmlWeb();// creates an instance of htmlweb from the htmlagility namespace
            var doc = webget.Load("http://www.nairaland.com");//load the naialand web source code from nairaland
            HtmlAgilityPack.HtmlNode ournode = doc.DocumentNode.SelectSingleNode("//td[@class='featured w']");// selected a particular class in source code this is thhe class holding the list of links

            string me = HtmlRemoval.StripTagsRegex(ournode.InnerHtml);// gets the inner html and calls the class and function that removes the tags 
            Console.WriteLine(HtmlRemoval.StripTagsRegex(me));// prints it out in  a console
            // Console.WriteLine(me);
            File.WriteAllText(mypath,me);// writes it to that paths in my document folder


        }
        static void second() {

            string mypath2 = @" C:\Users\USER\Documents\allfilework\newfile2.txt";//creates a txt file in the folder allfletext in my document folder
            HtmlWeb webget = new HtmlWeb();// creates an instance of htmlweb from the htmlagility namespace
            var doc = webget.Load("http://www.nairaland.com");//load the naialand web source code from nairaland
            HtmlAgilityPack.HtmlNode ournode = doc.DocumentNode.SelectSingleNode("//td[@class='homeuser']");//selected a particular class in source code this is thhe class holding the list of birthday and their age
            string me = HtmlRemoval.StripTagsRegex2(ournode.InnerHtml);// gets the inner html and calls the class and function that removes the tags 
            Console.WriteLine(HtmlRemoval.StripTagsRegex2(me));//prints it out in  a console
            // Console.WriteLine(me);
            File.WriteAllText(mypath2, me);// writes it to that paths in my document folder

        }

    }
    public static class HtmlRemoval
    {
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return HtmlRemoval.StripCustomElement(Regex.Replace(source, "<.*?>", string.Empty));// using  regex replaced <tags> with ""
        }

        public static string StripCustomElement(string whatever)
        {

            return Regex.Replace(whatever, "«»", "\n");//using regex replaces «» with next line 
        }

        public static string StripTagsRegex2(string source)
        {
            return HtmlRemoval.Strip(Regex.Replace(source, "<.*?>", string.Empty));//using the regex replaced <tags> with ""
        }
        public static string Strip(string sou) {
            return Regex.Replace(sou, ",", "\n");//using regex replaces , with next line 
        }
        
        }


    }

