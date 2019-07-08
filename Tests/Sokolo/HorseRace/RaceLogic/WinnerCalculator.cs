using System;
using System.Collections.Generic;
using System.Linq;
using HorseRace.Extensions;

namespace HorseRace.RaceLogic
{
    public class WinnerCalculator
    {
        private Random randomizer;

        public WinnerCalculator()
        {
            randomizer = new Random(Guid.NewGuid().GetHashCode());
        }

        public Participant PickWinner(Participant[] participants)
        {
            var odds = participants.Select(el => el.Odd).ToArray();
            var totalMargin = MarginCalculator.Calculate(odds);

            var participantTicketsRangeLength =
                participants.Select(el => (int) Math.Round(el.Odd.ToPercentageOdds() / totalMargin * 10000D)).ToArray();

            var participantTicketsBounds = new List<(int lowerBound, int upperBound)>();
            var lowerBound = 0;
            for (var i = 0; i < participants.Length; i++)
            {
                var upperBound = lowerBound + participantTicketsRangeLength[i];
                participantTicketsBounds.Add((lowerBound, upperBound));
                lowerBound = upperBound + 1;
            }

            var winnerTicket = randomizer.Next(participantTicketsBounds[participants.Length - 1].upperBound);
            var winnerIndex =
                participantTicketsBounds.FindIndex(el =>
                    el.lowerBound <= winnerTicket && el.upperBound >= winnerTicket);

            return participants[winnerIndex];
        }

        public void ResetRandomizer()
        {
            randomizer = new Random(Guid.NewGuid().GetHashCode());
        }
    }
}