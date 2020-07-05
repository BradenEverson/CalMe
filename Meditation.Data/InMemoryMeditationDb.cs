using Meditation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meditation.Data
{
    public class InMemoryMeditationDb : IMeditationData
    {
        readonly List<Core.Meditation> meditations;
        readonly List<meditationTypes> meditationTypeChangeMemory = new List<meditationTypes>();
        public Dictionary<meditationTypes, double> ratings = new Dictionary<meditationTypes, double>()
        {
            {meditationTypes.breathing, 0.0 },
            {meditationTypes.focus, 0.0 },
            {meditationTypes.mantra, 0.0 },
            {meditationTypes.yoga, 0.0 }
        };
        public void updateDictionary(meditationTypes target, bool positive)
        {
            int countedBefore = 1 + meditationTypeChangeMemory.Where(r => r == target).Count();
            if (positive)
            {
                if(ratings[target] > 0.00)
                {
                    ratings[target] -= 0.1;
                }
            }
            else
            {
                if(ratings[target] < 0.9)
                {
                    ratings[target] += 0.1 * countedBefore;
                }
            }
            foreach(var key in ratings.Keys)
            {
                Console.WriteLine(key.ToString() + " " + ratings[key]);
            }
            meditationTypeChangeMemory.Add(target);
        }
        private int idCount = 0;
        public InMemoryMeditationDb()
        {
            meditations = new List<Core.Meditation>();
        }
        public Core.Meditation add(Core.Meditation newMeditation)
        {
            newMeditation.id = idCount;
            meditations.Add(newMeditation);
            idCount++;
            return newMeditation;
        }
        public Core.Meditation CreateNew()
        {
            List<meditationTypes> meditationTypesAccepted = ratings.Keys.Where(r => ratings[r] <= staticRandom.Instance.NextDouble()).ToList();
            meditationTypes selectedMeditation;
            if(meditationTypesAccepted != null)
            {
                selectedMeditation = meditationTypesAccepted[staticRandom.Instance.Next(0, meditationTypesAccepted.Count() - 1)];
            }
            else
            {
                selectedMeditation = Enum.GetValues(typeof(meditationTypes)).Cast<meditationTypes>().ToList()[staticRandom.Instance.Next(0, Enum.GetValues(typeof(meditationTypes)).Cast<meditationTypes>().Count() - 1)];
            }
            Core.Meditation meditation = new Core.Meditation(selectedMeditation);
            return meditation;
        }
        public Core.Meditation getById(int id)
        {
            Core.Meditation meditation = meditations.FirstOrDefault(r => r.id == id);
            if(meditation == null)
            {
                return null;
            }
            return meditation;
        }
        public int Commit()
        {
            return 0;
        }

        public Core.Meditation delete(int id)
        {
            Core.Meditation deletedMeditation = meditations.FirstOrDefault(r => r.id == id);
            if(deletedMeditation != null)
            {
                meditations.Remove(deletedMeditation);
            }
            return deletedMeditation;
        }

        public int getCount()
        {
            return meditations.Count();
        }

        public Core.Meditation update(Core.Meditation updatedMeditation)
        {
            Core.Meditation updatedLink = meditations.FirstOrDefault(r => r.id == updatedMeditation.id);
            if(updatedLink != null)
            {
                updatedLink.name = updatedMeditation.name;
                updatedLink.content = updatedMeditation.content;
            }
            return updatedLink;
        }
    }
}
