using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RandomNameGenerator
{
    public static class NameGenerator
    {
        private static Random _random = new Random();
        private static List<string> _lastNames = new List<string>();
        private static List<string> _dudes = new List<string>();
        private static List<string> _ladies = new List<string>();
        private static FileStream aFile;             
        private static StreamReader sr;

        public static string Generate(Gender gender)
        {
            return string.Format("{0} {1}", GenerateFirstName(gender), GenerateLastName());
        }

        private static void SetupLastName()
        {
            aFile = new FileStream("../../../packages/RandomNameGenerator.1.0.2/lastnames.csv", FileMode.Open);
            sr = new StreamReader(aFile, true);
            while (sr.Peek() >0 )
            {
                _lastNames.Add(sr.ReadLine());
            }
        }

        private static void SetupDudes()
        {
            aFile = new FileStream("../../../packages/RandomNameGenerator.1.0.2/dudes.csv", FileMode.Open);
            sr = new StreamReader(aFile, true);
            while (sr.Peek() > 0)
            {
                _dudes.Add(sr.ReadLine());
            }
        }

        private static void SetupLadies()
        {
            aFile = new FileStream("../../../packages/RandomNameGenerator.1.0.2/ladies.csv", FileMode.Open);
            sr = new StreamReader(aFile, true);
            while (sr.Peek() > 0)
            {
                _ladies.Add(sr.ReadLine());
            }
        }
        
        public static string GenerateLastName()
        {
            if (_lastNames.Count == 0)
                SetupLastName();
            return _lastNames[_random.Next(0, _lastNames.Count)];
        }

        private static string GenerateDudeName()
        {
            if (_dudes.Count == 0)
                SetupDudes();
            return _dudes[_random.Next(0, _dudes.Count)];
        }

        private static string GenerateLadieName()
        {
            if (_ladies.Count == 0)
                SetupLadies();
            return _ladies[_random.Next(0, _ladies.Count)];
        }

        public static string GenerateFirstName(Gender gender)
        {
            if (gender == Gender.Male)
                return GenerateDudeName();
            return GenerateLadieName();
        }

    }
    public enum Gender
    {
        Male,
        Female
    }

    
}
