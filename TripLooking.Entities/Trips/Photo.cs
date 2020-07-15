namespace TripLooking.Entities.Trips
{
    public sealed class Photo : Entity
    {
        public Photo(string name, byte[] photoContent) : base()
        {
            Name = name;
            PhotoContent = photoContent;
        }

        public string Name { get; private set; }

        public byte[] PhotoContent { get; private set; }
    }
}