using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace EncodingExtension
{
    public class GeneralCoder<TType> : IGeneralCoder<TType>
    {
        public TType Decode(string itemToDecode)
        {
            var bytes = new List<byte>();
            for(var i=0; i < itemToDecode.Length; i += 2)
            {
                var oneByte = itemToDecode.Substring(i, 2);
                bytes.Add(byte.Parse(oneByte, System.Globalization.NumberStyles.HexNumber));
            }

            using(var stream = new MemoryStream(bytes.ToArray()))
            {
                return Serializer.Deserialize<TType>(stream);
            }
        }

        public string Encode(TType itemToEncode)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, itemToEncode);
                stream.Seek(0, SeekOrigin.Begin);
                using (var binaryReader = new BinaryReader(stream))
                {
                    var bytes = binaryReader.ReadBytes((int)stream.Length);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }
    }
}
