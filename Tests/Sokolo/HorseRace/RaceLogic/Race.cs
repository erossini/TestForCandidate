using System.Collections.Generic;
using System.Linq;
using HorseRace.Exceptions;

namespace HorseRace.RaceLogic
{
    public class Race
    {
        private readonly Dictionary<string, Participant> _participants;
        private readonly WinnerCalculator _winnerCalculator;
        
        public Race()
        {
            _participants = new Dictionary<string, Participant>();
            _winnerCalculator = new WinnerCalculator();
        }

        public void Reset()
        {
            _participants.Clear();
            _winnerCalculator.ResetRandomizer();
        }

        public void AddParticipant(Participant participant)
        {
            if (_participants.ContainsKey(participant.Name))
                throw new ParticipantAlreadyAddedException();

            var odds = _participants.Values.Select(el => el.Odd).Append(participant.Odd).ToArray();
            var totalMargin = MarginCalculator.Calculate(odds);
            if (totalMargin > 140.00D)
                throw new TotalMarginOverloadException();

            _participants[participant.Name] = participant;
        }

        public Participant DoRace()
        {
            var odds = _participants.Values.Select(el => el.Odd).ToArray();
            var totalMargin = MarginCalculator.Calculate(odds);
            if (totalMargin < 110.00D)
                throw new TotalMarginDeficitException();
            
            return _winnerCalculator.PickWinner(_participants.Values.ToArray());
        }
    }
}