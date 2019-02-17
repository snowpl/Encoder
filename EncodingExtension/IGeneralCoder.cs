namespace EncodingExtension
{
    public interface IGeneralCoder<TType>
    {
        TType Decode(string itemToDecode);
        string Encode(TType itemToEncode);
    }
}
