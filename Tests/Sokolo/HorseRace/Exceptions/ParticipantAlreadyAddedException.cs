namespace HorseRace.Exceptions
{
    public class ParticipantAlreadyAddedException : HorseRaceExceptionBase
    {
        public ParticipantAlreadyAddedException() : base("Participant with this name already added")
        {
        }
    }
}