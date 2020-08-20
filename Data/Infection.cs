using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCP008.Data
{
    public class Infection
    {
        public Infection(Player attacker, Player target, DateTime start, float duration)
        {
            StartTime = start;
            Duration = duration;
            Attacker = attacker;
            Target = target;
            Coroutine = Timing.CallDelayed(duration, Infect);
        }
        private readonly CoroutineHandle Coroutine;
        public DateTime StartTime { get; private set; }
        public float Duration { get; private set; }
        public Player Attacker { get; private set; }
        public Player Target { get; private set; }

        public delegate void OnInfecting(InfectingEventArgs args);
        public event OnInfecting Infecting;

        public delegate void OnInfected(InfectedEventArgs args);
        public event OnInfected Infected;

        public delegate void OnCuring(CuringEventArgs args);
        public event OnCuring Curing;

        public delegate void OnCured(CuredEventArgs args);
        public event OnCured Cured;

        public void Infect()
        {
            if(Target.IsAlive)
            {
                try
                {
                    InfectingEventArgs infectingArgs = new InfectingEventArgs(Attacker, Target);
                    Infecting?.Invoke(infectingArgs);
                    if(infectingArgs.IsAllowed)
                    {
                        Target.SetRole(RoleType.Scp0492, true, false);
                    }
                } catch(Exception e)
                {
                    Log.Error($"InfectingEvent Error Thrown: {e}");
                }
                try
                {
                    InfectedEventArgs infectedArgs = new InfectedEventArgs(Attacker, Target);
                    Infected?.Invoke(infectedArgs);
                } catch (Exception e)
                {
                    Log.Error($"InfectedEvent Error Thrown: {e}");
                }
            }
        }

        public void Cure(ItemType item = ItemType.None)
        {
            try
            {
                CuringEventArgs cureArgs = new CuringEventArgs(Target, item);
                Curing?.Invoke(cureArgs);
                if (cureArgs.IsAllowed)
                {
                    Timing.KillCoroutines(Coroutine);
                }
            }
            catch (Exception e)
            {
                Log.Error($"CuringEvent Error Thrown: {e}");
            }

            try
            {
                CuredEventArgs curedArgs = new CuredEventArgs(Target, item);
                Cured?.Invoke(curedArgs);
            }
            catch (Exception e)
            {
                Log.Error($"CuredEvent Error Thrown: {e}");
            }
        }
    }
}
