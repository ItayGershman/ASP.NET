using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace demoExercise.Controllers{
    
    [Route("api/[controller]")]
    public class DemoController : Controller{
        //ex1
        // GET: /api/demo/camel_case
        [HttpGet("camel_case")]
        public string camelCaseConvertion(string str){
            if(str == null){
                return "null string";
            }
            TextInfo myTI = new CultureInfo("en-US",false).TextInfo;//convert all other char's into lower case
            string camelStr = myTI.ToTitleCase(str);//make first letter to Capital
            return camelStr.Replace(" ","");//Remove white spaces from string.
        }

        //ex2
        //POST: /api/demo/turn_over
        [HttpPost("turn_over")]
        public string turnOverString(string str){
            if (str == null){
                return "null string";
            }
            string[] opposite = str.Split();//string to array
            int strSize = opposite.Length;
            var turnString = "";
            for(int i = strSize; i > 0 ; --i){
                turnString += opposite[i - 1] + " "; //add opposite from the end to beginning
            }
            return turnString;
        }

        //ex3
        // POST: /api/demo/compute_num_of_words
        [HttpPost("compute_num_of_words")]
        
        public int computeWords(string str){
            if(str == null){
                return 0;
            }
            string[] words = str.Split();
            return words.Length;
        }

        //ex6
        //GET:/api/demo/compute_occurrences
        [HttpGet("compute_occurrences")]
        public int computeOccurrences(string str){
            if (str == null){
                return 0;
            }
            var list = new List<string>(str.Split().ToList());
            int size;
            if((size = list.Count) == 1 ){
                return 1;
            }
            int max = 1,result = 1;
            for(int i = 0; i < size; ++i ){
                for(int j = i + 1 ; j < size; ++j ){
                    if(list[i] == list[j]){
                        max++;
                    }
                }
                if(result < max){
                    result = max;
                }
                max = 1;
            }
            return result;
        }

        //ex9
        //GET /api/demo/replace_characters
        [HttpGet("replace_characters")]
        public string replaceCharacters(string str){
            if(str == null){
                return "null string";
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);//Convert str to Ascii array
            for(int i = 0; i < asciiBytes.Length ; ++i){
                asciiBytes[i]++;
            }
             return Encoding.ASCII.GetString(asciiBytes);//Convert back to string.
        }
    }
}