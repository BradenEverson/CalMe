using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meditation.Core;
using Meditation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalMe
{
    public class meditationCenterModel : PageModel
    {
        private readonly IMeditationData meditations;
        public Meditation.Core.Meditation newMeditation;
        public meditationCenterModel(IMeditationData meditations)
        {
            this.meditations = meditations;
        }
        public void OnGet()
        {
            newMeditation = new Meditation.Core.Meditation();
            meditations.add(newMeditation);
        }
    }
}