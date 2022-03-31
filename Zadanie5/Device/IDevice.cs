namespace Zadanie5.Device
{
    public interface IDevice
    {
        /// <summary>
        /// Przechowuje możliwe stany urządzeń
        /// </summary>
        public enum State
        {
            ON,
            OFF,
            STANDBY
        };

        /// <summary>
        /// Uruchamia urządzeniem zmienia stan na ON
        /// </summary>
        void PowerOn()
        {
            SetState(State.ON);
        }

        /// <summary>
        /// Wyłącza urządzenie, zmienia stan na OFF
        /// </summary>
        void PowerOff()
        {
            SetState(State.OFF);
        }

        /// <summary>
        /// Uruchamia tryb oszczędzania energii urządzenia
        /// </summary>
        void StandbyOn()
        {
            SetState(State.STANDBY);
        }

        /// <summary>
        /// Wyłącza tryb oszczędzania energii urządzenia
        /// </summary>
        void StandbyOff()
        {
            SetState(State.ON);
        }

        /// <summary>
        /// Przechowuje aktualną liczbę uruchomień urządzenia
        /// </summary>
        int Counter { get; set; }

        /// <summary>
        /// Zwraca aktualny stan urządzenia
        /// </summary>
        State GetState()
        {
            return state;
        }

        /// <summary>
        /// Ustawia stan urządzenia
        /// </summary>
        /// <param name="state"></param>
        abstract protected void SetState(State state);

        State state { get; set; }
    }
}