using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class TestUtil
    {
        public static string GetFileContents(string file)
        {
            var assembly = Assembly.GetAssembly(typeof(TestUtil));
            if (assembly == null) throw new ArgumentException("assembly");
            
            var stream = assembly.GetManifestResourceStream($"AdventOfCode.UnitTest.IntegrationTests.Input.{file}");
            if (stream == null) throw new ArgumentException("stream");

            using var reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}