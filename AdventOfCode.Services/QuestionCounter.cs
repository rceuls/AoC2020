using System;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class QuestionCounter
    {
        public static int CountYes(string groupAnswers)
        {
            var mergedAnswers = groupAnswers.Replace(Environment.NewLine, "");
            return mergedAnswers.Distinct().Count();
        } 
        
        public static long CountUniqueYes(string groupAnswers)
        {
            var peopleCount = groupAnswers.Count(x => x == '\n') + 1;
            var mergedAnswers = groupAnswers.Replace(Environment.NewLine, "").GroupBy(x => x);
            return mergedAnswers.Count(x => x.Count() == peopleCount);
        }    
    }
}