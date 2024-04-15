namespace StudentProfileWebApp
{
    public class EnvironmentLoader
    {
        private readonly string _filePath;

        
        /// Initializes a new instance of the <see cref="EnvironmentLoader"/> class
        
        public EnvironmentLoader() : this(".env")
        {
        }

        
        /// Initializes a new instance of the <see cref="EnvironmentLoader"/> class
       
        public EnvironmentLoader(string filePath)
        {
            _filePath = filePath;
        }

       
        public bool LoadVariables()
        {
            if (!File.Exists(_filePath))
            {
                return false;
            }

            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue; // Skips lines that don't properly split into key and value.
                }

                var (key, value) = (parts[0], parts[1]);
                if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                {
                    Environment.SetEnvironmentVariable(key.Trim(), value.Trim());
                }
            }

            return true;
        }
    }
}
