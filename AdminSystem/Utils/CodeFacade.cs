using System;
namespace AdminSystem.Utils
{
	public class CodeFacade
	{
        private string codeGenerationString = "0123456789";

        private string createRandomDigits(int length = 5)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(this.codeGenerationString, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

		public int GenerateCode()
		{
            return int.Parse(this.createRandomDigits());
		}

		public int GenerateCode(int codeLength)
		{
            return int.Parse(new string(this.createRandomDigits(codeLength)));
        }

        public int GenerateCode(int codeLength, int year)
        {
            string generatedCode = this.createRandomDigits(codeLength);

            string code = year.ToString() + generatedCode;
            return int.Parse(code);
        }
	}
}

