using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GestionRelationClient.Models
{
    public static class Utilitaire
    {

        // Transforme une énumération en Observable ; le madlad : https://stackoverflow.com/questions/9984594/iqueryablea-to-observablecollectiona-where-a-anonymous-type
        public static ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }
    }
}
