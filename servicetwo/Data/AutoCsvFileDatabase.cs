using System.Reflection;

namespace servicetwo.Data {
    public class AutoCsvFileDatabase : IAutoDatabase {

        private readonly Dictionary<string, Owner> owners = new Dictionary<string, Owner>();

        public AutoCsvFileDatabase(ILogger<AutoCsvFileDatabase> logger) {
            ReadOwnersFromCsvFile("owners.csv");
        }
        
        private string ResolveCsvFilePath(string filename) {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var csvFilePath = Path.Combine(directory, "csv-data");
            return Path.Combine(csvFilePath, filename);
        }

        
        private void ReadOwnersFromCsvFile(string filename) {
            var filePath = ResolveCsvFilePath(filename);
            foreach (var line in File.ReadAllLines(filePath)) {
                var tokens = line.Split(",");
                var owner = new Owner {
                    OwnerId = tokens[0],
                    Name = tokens[1],
                    SecondName = tokens[2],
                    Mail = tokens[3],
                    PhoneNumber = tokens[4],
                    VehicleRegistration = tokens[5]
                };
                owners.Add(owner.OwnerId, owner);
            }
        }


        public Owner FindOwner(string id) => owners.GetValueOrDefault(id);
        public IEnumerable<Owner> ListOwners() => owners.Select(o => o.Value).ToList();



    }
}