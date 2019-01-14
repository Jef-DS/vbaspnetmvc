using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layout01.Services
{
    public class K3Service:IEnumerable<String>
    {
        private List<String> _namen = new List<String> { "Karen", "Kristel", "Kathleen" };

        public void VerwijderNaam(String naam)
        {
            _namen.Remove(naam);
        }
        public void VoegNaamToe(String naam)
        {
            _namen.Add(naam);
        }
         public IEnumerator<string> GetEnumerator()
        {
            return _namen.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _namen.GetEnumerator();
        }
    }
}
