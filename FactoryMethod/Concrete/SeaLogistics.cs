namespace FactoryMethod
{
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Ship();
    }
}
