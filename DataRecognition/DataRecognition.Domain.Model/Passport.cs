using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRecognition.Domain.Model
{
    public class Passport
    {
        //TODO: добавить недостоющие поля
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UFMS { get; set; }
        public int City { get; set; }
    }
}
