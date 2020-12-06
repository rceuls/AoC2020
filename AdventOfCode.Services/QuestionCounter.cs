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
            var mergedAnswers = groupAnswers
                .Split(Environment.NewLine)
                .SelectMany(x => x.Distinct())
                .GroupBy(x => x);
            return mergedAnswers
                .Where(x => x.Key != '\n')
                .Count(x => x.Count() == peopleCount);
        }    
    }
}