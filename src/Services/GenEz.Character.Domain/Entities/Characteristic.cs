using Distrib.Core.Domain;
using Distrib.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenEz.Character.Domain.Entities
{
    public class Characteristic : EntityBase
    {
        public const int NameMaxSize = 20;

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim().ToLower();
                NeutralName = _name.ToNeutral();
            }
        }
        public string NeutralName { get; set; }
        public bool? IsPositive { get; set; }
        public ICollection<Characteristic> CharacteristicsOpposedTo { get; set; }
        public ICollection<Characteristic> CharacteristicsOpposedFrom { get; set; }

        #endregion

        #region Constructors

        public Characteristic(string name, bool? isPositive, Characteristic characteristicOpposedTo)
        {
            Name = name;
            IsPositive = isPositive;
            CharacteristicsOpposedTo = new List<Characteristic> { characteristicOpposedTo };
        }

        // Required for entity framework
        private Characteristic()
        {
        }

        #endregion

        public void InsertOpposedCharacteristics(List<Characteristic> existingCharacteristics, List<string> allOpposedCharacteristics)
        {
            existingCharacteristics.ForEach(x => x.InsertOpposedCharacteristic(this));
            var newCharacteristics = allOpposedCharacteristics.Where(x => !existingCharacteristics.Select(y => y.Name).Contains(x)).Select(x => new Characteristic(x, !IsPositive, this));
            CharacteristicsOpposedTo = existingCharacteristics.Union(newCharacteristics).ToList();
        }

        public void InsertOpposedCharacteristic(Characteristic opposedCharacteristic)
        {
            if (CharacteristicsOpposedTo.Contains(opposedCharacteristic))
            {
                return;
            }

            CharacteristicsOpposedTo.Add(opposedCharacteristic);
        }

        /* bright, brave, smart, gentle, friendly, inspiring, loveable, energetic, stable, generous, creative, entertaining, considerate, exciting, kind */
        /* stingy, unstable, boring, unkind, disloyal, selfish, sneaky, violent, unintelligent, lazy, coward, evil, rude, untrustworthy*/
    }
}