using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meditation.Data
{
    public class InMemoryMeditationDb : IMeditationData
    {
        readonly List<Core.Meditation> meditations;
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
