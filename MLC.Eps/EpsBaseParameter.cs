namespace MLC.Eps
{
    public abstract class EpsBaseParameter
    {
        public string Code { get; set; }
        public object Value { get; set; }
        public string Subvalue { get; set; }
    }
}