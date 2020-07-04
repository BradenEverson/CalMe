using Meditation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meditation.Data
{
    public interface IMeditationData
    {
        Core.Meditation add(Core.Meditation newMeditation);
        Core.Meditation delete(int id);
        Core.Meditation update(Core.Meditation updatedMeditation);
        Core.Meditation getById(int id);
        int getCount();
        int Commit();
    }
}
