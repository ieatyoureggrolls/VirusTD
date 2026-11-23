namespace VirusTD.Interfaces
{
    //File Input.Output
    //Anything that will be saved (the map and user) will implement this
    public interface FileIO
    {
        public int Save(string[] fieldsToSave);
        public int Load(Object objectToLoad);
    }
}
