namespace MissingNumbers.Entities
{
    using System.Collections.Generic;

    public class MissingNumbersViewModel
    {
        public int FirstArrayLength { get; set; }

        public int SecondArrayLength { get; set; }

        public string FirstArrayStringNumbers { get; set; }

        public string SecondArrayStringNumbers { get; set; }

        public List<int> FirstArrayNumbers { get; set; }

        public List<int> SecondArrayNumbers { get; set; }

        public string MissingNumbersResult { get; set; }

        public string ErrorMessage { get; set; }
    }
}