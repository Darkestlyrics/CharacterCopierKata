using System;
using CharacterCopierKata.Interfaces;

namespace CharacterCopierKata
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(IDestination destination, ISource source)
        {
            _destination = destination;
            _source = source;
        }


        public void Copy()
        {
            //initialise with a default character
            char temp = _source.ReadChar();
            while(temp != '\n')
            {
                _destination.WriteCharacter(temp);
                 temp = _source.ReadChar();
            }
        }
    }
}
