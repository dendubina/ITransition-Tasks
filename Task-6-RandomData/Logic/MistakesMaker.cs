using System;
using System.Linq;
using System.Text;
using Task_6_RandomData.Constants;
using Task_6_RandomData.EF.Entities;
using Task_6_RandomData.Models;

namespace Task_6_RandomData.Logic
{
    public class MistakesMaker
    {
        private const string LatinChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string CyrillicChars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
        private delegate string Errors(string text);
        private static Errors[] AvailableErrors;
        private readonly Random _rnd = new();
        private readonly string _chosenChars;

        public MistakesMaker(Regions region)
        {
            _chosenChars = region == Regions.En ? LatinChars : CyrillicChars;

            AvailableErrors = new Errors[]
            {
                ChangeSymbol,
                AddSymbol,
                RemoveSymbol
            };
        }

        public PersonInfo MakeErrors(PersonInfo person, double count)
        {
            for (int i = 0; i < (int)count; i++)
            {
                MakeError(person);
            }

            if (_rnd.NextDouble() < count - (int)count)
            {
                MakeError(person);
            }

            return person;
        }

        private string ChangeSymbol(string text)
        {
            var builder = new StringBuilder(text);

            if (builder.Length > 0)
            {
                builder[_rnd.Next(text.Length)] = _chosenChars[_rnd.Next(LatinChars.Length)];
            }

            return builder.ToString();
        }

        private string AddSymbol(string text)
        {
            var builder = new StringBuilder(text);

            return builder.Insert(_rnd.Next(text.Length), _chosenChars[_rnd.Next(LatinChars.Length)]).ToString();
        }

        private string RemoveSymbol(string text)
        {
            var builder = new StringBuilder(text);

            if (text.Length > 0)
            {
                builder.Remove(_rnd.Next(0, builder.Length), 1);
                return builder.ToString();
            }

            return builder.ToString();
        }

        private void MakeError(PersonInfo person)
        {
            var props = person.GetType().GetProperties().Where(x => x.PropertyType == typeof(string)).ToArray();

            var current = _rnd.Next(props.Length);
            var value = props[current].GetValue(person).ToString();
            props[current].SetValue(person, AvailableErrors[_rnd.Next(AvailableErrors.Length)](value));
        }
    }
}
