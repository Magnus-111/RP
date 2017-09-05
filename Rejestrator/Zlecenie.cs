using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejestrator
{
    [Serializable]
    public class Zlecenie
    {
        string nazwa;
        DateTime data;
        TimeSpan czas;

        public Zlecenie(string Nazwa, DateTime Data, TimeSpan Czas)
        {
            nazwa = Nazwa;
            data = Data;
            czas = Czas;
        }

        public TimeSpan Czas
        {
            get
            {
                return czas;
            }
            set
            {
                czas = value;
            }
        }

        public string Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                nazwa = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return data;
            }
            
        }

        public override string ToString()
        {
            return nazwa;
        }
    }
}
