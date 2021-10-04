namespace FactoryMethod
{
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Truck();
    }
}
