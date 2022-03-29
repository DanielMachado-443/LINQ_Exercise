using System.Collections.Generic;
using System.Linq;
using Section17_233_ExercicioDeFixacao.Entities;

namespace Section17_233_ExercicioDeFixacao.Services {
    static class Query {
        public static IEnumerable<object> firstQuery(IEnumerable<object> collection, double minSalary) {
            List<Employee> aux = collection as List<Employee>; // downcasting
            var result = aux.Where(p => p.Salary > minSalary).OrderBy(p => p.Email).Select(p => p.Email);
            return result;
        }

        public static double firstLetterSalarySum(IEnumerable<object> collection, char firstLetter) {
            List<Employee> aux = collection as List<Employee>;
            var result = aux.Where(p => p.Name[0] == firstLetter).Sum(p => p.Salary);
            return result;
        }
    }
}
