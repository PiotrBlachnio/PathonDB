using System.Collections.Generic;
using JsonDatabase.Exceptions;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Services {
    public class CreateService {
        private readonly Dictionary<string, dynamic> _storage;
        
        public CreateService(Dictionary<string, dynamic> storage) {
            _storage = storage;
        }

        public void PerformQuery(string query) {
            var arguments = query.Split(" ");

            switch(arguments[1].ToUpper()) {
                case "TABLE":
                    new CreateTableValidator(_storage).Validate(query);
                    break;
                default:
                    throw new InvalidQueryArgumentsException(arguments[1]);
            }
        }
    }
}