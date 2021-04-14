#region using

using System;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace XsdTool.Models
{
    public class XsdModel
    {
        private string _dataType;

        private int _maxLength;

        private string _privateName;

        private string _publicName;

        private string _title;

        private string _xmlName;

        public string XmlName
        {
            get => _xmlName;
            set
            {
                if (value != _xmlName)
                {
                    _xmlName = value;
                }
            }
        }

        public string PrivateName
        {
            get => _privateName;
            set
            {
                if (value != _privateName)
                {
                    _privateName = value;
                    char[] delimiterChars = {' ', ',', '.', ':', '_'};
                    var words = _privateName.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Regex.Replace(x, @"(?<!\w)\w", m => m.Value.ToUpper())).ToList();
                    words[0] = words[0].ToLower();
                    _privateName = $"_{string.Join(string.Empty, words)}";
                }
            }
        }

        public string PublicName
        {
            get => _publicName;
            set
            {
                if (value != _publicName)
                {
                    _publicName = value;
                    char[] delimiterChars = {' ', ',', '.', ':', '_'};
                    var words = _publicName.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Regex.Replace(x, @"(?<!\w)\w", m => m.Value.ToUpper())).ToList();
                    _publicName = $"{string.Join(string.Empty, words)}";
                }
            }
        }

        public string DataType
        {
            get => _dataType;
            set
            {
                if (value != _dataType)
                {
                    _dataType = value.ToLower();
                }
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    _title = string.Join("_", Regex.Split(_title, @"(?<!^)(?=[A-Z])"));
                    char[] delimiterChars = {' ', ',', '.', ':', '_'};
                    var words = _title.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Regex.Replace(x, @"(?<!\w)\w", m => m.Value.ToLower())).ToList();
                    words[0] = Regex.Replace(words[0].ToLower(), @"(?<!\w)\w", m => m.Value.ToUpper());
                    _title = $"{string.Join(" ", words)}";
                }
            }
        }

        public int MaxLength
        {
            get => _maxLength;
            set
            {
                if (value != _maxLength)
                {
                    _maxLength = value;
                }
            }
        }
    }
}
