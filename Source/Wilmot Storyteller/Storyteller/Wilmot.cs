using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace WilmotStoryteller.Storyteller
{
    [StaticConstructorOnStartup]
    public static class Wilmot
    {

        private static WilmotBehavior WilmotBehavior { get; set; }

        static Wilmot()
        {
            WilmotBehavior = new WilmotBehavior();
        }

    }
}
